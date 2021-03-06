﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class UserRolesRepo
	{
		private readonly ULearnDb db;

		public UserRolesRepo()
			: this(new ULearnDb())
		{

		}

		public UserRolesRepo(ULearnDb db)
		{
			this.db = db;
		}

		public Dictionary<string, CourseRole> GetRoles(string userId)
		{
			return db.UserRoles
				.Where(role => role.UserId == userId)
				.GroupBy(role => role.CourseId)
				.ToDictionary(g => g.Key, g => g.Select(role => role.Role).Min());
		}

		public async Task ToggleRole(string courseId, string userId, CourseRole role)
		{
			var userRole = db.UserRoles.FirstOrDefault(u => u.UserId == userId && u.Role == role && u.CourseId == courseId);
			if (userRole == null)
				db.UserRoles.Add(new UserRole
				{
					UserId = userId,
					CourseId = courseId,
					Role = role
				});
			else
				db.UserRoles.Remove(userRole);
			await db.SaveChangesAsync();
		}

		public List<string> GetListOfUsersWithCourseRole(CourseRole? courseRole, string courseId)
		{
			if (!courseRole.HasValue)
				return null;

			var usersQuery = db.UserRoles.Where(userRole => userRole.Role == courseRole);
			if (!string.IsNullOrEmpty(courseId))
				usersQuery = usersQuery.Where(userRole => userRole.CourseId == courseId);
			return usersQuery.Select(user => user.UserId).Distinct().ToList();
		}

		public List<string> GetListOfUsersByPrivilege(bool onlyPrivileged, string courseId)
		{
			if (!onlyPrivileged)
				return null;

			IQueryable<UserRole> usersQuery = db.UserRoles;
			if (courseId != null)
				usersQuery = usersQuery.Where(userRole => userRole.CourseId == courseId);
			return usersQuery.Select(userRole => userRole.UserId).Distinct().ToList();
		}
	}
}