﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uLearn.Quizes;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class UserQuizzesRepo
	{
		private readonly ULearnDb db;

		public UserQuizzesRepo() : this(new ULearnDb())
		{
			
		}

		public UserQuizzesRepo(ULearnDb db)
		{
			this.db = db;
		}

		public async Task<UserQuiz> AddUserQuiz(string courseId, bool isRightAnswer, string itemId, string quizId, string slideId, string text, string userId, DateTime time, bool isRightQuizBlock)
		{
			var userQuiz = new UserQuiz
			{
				CourseId = courseId,
				IsRightAnswer = isRightAnswer,
				ItemId = itemId,
				QuizId = quizId,
				SlideId = slideId,
				Text = text,
				Timestamp = time,
				UserId = userId,
				IsRightQuizBlock = isRightQuizBlock
			};
			db.UserQuizzes.Add(userQuiz);
			await db.SaveChangesAsync();
			return userQuiz;
		}

		public bool IsQuizSlidePassed(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes.Any(x => x.UserId == userId && x.SlideId == slideId && !x.isDropped);
		}

		public IEnumerable<bool> GetQuizDropStates(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes
				.Where(x => x.UserId == userId && x.SlideId == slideId)
				.DistinctBy(q => q.Timestamp)
				.Select(q => q.isDropped);
		}

		public HashSet<string> GetIdOfQuizPassedSlides(string courseId, string userId)
		{
			return new HashSet<string>(db.UserQuizzes.Where(x => x.CourseId == courseId && x.UserId == userId).Select(x => x.SlideId).Distinct());
		}

		public Dictionary<string, List<string>> GetAnswersForShowOnSlide(string courseId, QuizSlide slide, string userId)
		{
			if (slide == null)
				return null;
			var answer = new Dictionary<string, List<string>>();
			foreach (var block in slide.Blocks.OfType<AbstractQuestionBlock>())
			{
				var ans = db.UserQuizzes
					.Where(x => x.UserId == userId && x.SlideId == slide.Id && x.QuizId == block.Id && !x.isDropped).ToList();
				if (block is ChoiceBlock)
					answer[block.Id] = ans.Select(x => x.ItemId).ToList();
				else if (block is IsTrueBlock)
					answer[block.Id] = ans.Select(x => x.Text).ToList();
				else if(block is FillInBlock)
					answer[block.Id] = new List<string>
					{
						ans.Select(x => x.Text).FirstOrDefault(),
						ans.Select(x => x.IsRightAnswer).FirstOrDefault().ToString()
					};
			}
			return answer;
		}

		public int GetAverageStatistics(string slideId, string courseId)
		{
			var newA = db.UserQuizzes
				.Where(x => x.SlideId == slideId)
				.GroupBy(x => x.UserId)
				.Select(x => x
					.GroupBy(y => y.QuizId)
					.Select(y => y.All(z => z.IsRightQuizBlock))
					.Select(y => y ? 1 : 0)
					.DefaultIfEmpty()
					.Average())
				.DefaultIfEmpty()
				.Average() * 100;
			return (int) newA;
		}

		public int GetSubmitQuizCount(string slideId, string courseId)
		{
			return db.UserQuizzes.Where(x => x.SlideId == slideId).Select(x => x.User).Distinct().Count();
		}

		public int GetQuizSuccessful(string courseId, string slideId, string userId)
		{
			return (int)(db.UserQuizzes
				.Where(x => x.SlideId == slideId && x.UserId == userId)
				.GroupBy(y => y.QuizId)
				.Select(y => y.All(z => z.IsRightQuizBlock))
				.Select(y => y ? 1 : 0)
				.DefaultIfEmpty()
				.Average() * 100);
		}

		public async Task RemoveAnswers(string userId, string slideId)
		{
			var answersToRemove = db.UserQuizzes.Where(q => q.UserId == userId && q.SlideId == slideId).ToList();
			db.UserQuizzes.RemoveRange(answersToRemove);
			await db.SaveChangesAsync();
		}

		public async Task DropQuiz(string userId, string slideId)
		{
			var quizzes = db.UserQuizzes.Where(q => q.UserId == userId && q.SlideId == slideId).ToList();
			foreach (var q in quizzes)
			{
				q.isDropped = true;
			}
			await db.SaveChangesAsync();
		}

		public Dictionary<string, bool> GetQuizBlocksTruth(string courseId, string userId, string slideId)
		{
			return db.UserQuizzes
				.Where(q => q.UserId == userId && q.SlideId == slideId && !q.isDropped)
				.DistinctBy(q => q.QuizId)
				.ToDictionary(q => q.QuizId, q => q.IsRightQuizBlock);
		}

		public Dictionary<string, List<UserQuiz>> GetAnswersForUser(string slideId, string userId)
		{
			return db.UserQuizzes
				.Where(ans => ans.UserId == userId && ans.SlideId == slideId && !ans.isDropped)
				.ToLookup(ans => ans.QuizId)
				.ToDictionary(g => g.Key, g => g.ToList());
		}
	}
}