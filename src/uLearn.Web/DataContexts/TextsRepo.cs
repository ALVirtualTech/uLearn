﻿using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using uLearn.Web.Models;

namespace uLearn.Web.DataContexts
{
	public class TextsRepo
	{
		private readonly ULearnDb db;
		public const int MaxTextSize = 4000;

		public TextsRepo() : this(new ULearnDb())
		{
			
		}

		public TextsRepo(ULearnDb db)
		{
			this.db = db;
		}

		public async Task<TextBlob> AddText(string text)
		{
			if (text == null)
				return new TextBlob
				{
					Hash = null,
					Text = null
				};

			if (text.Length > MaxTextSize)
				text = text.Substring(0, MaxTextSize);

			var hash = GetHash(text);
			var blob = db.Texts.Find(hash);
			if (blob != null)
				return blob;

			blob = new TextBlob
			{
				Hash = hash,
				Text = text
			};
			db.Texts.AddOrUpdate(blob);

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbEntityValidationException e)
			{
				throw new Exception(
					string.Join("\r\n",
					e.EntityValidationErrors.SelectMany(v => v.ValidationErrors).Select(err => err.PropertyName + " " + err.ErrorMessage)));
			}
			return blob;
		}

		private static string GetHash(string text)
		{
			var byteArray = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(text));
			return BitConverter.ToString(byteArray).Replace("-", "");
		}

		public TextBlob GetText(string hash)
		{
			if (hash == null)
				return new TextBlob
				{
					Hash = null, 
					Text = null
				};
			return db.Texts.Find(hash);
		}
	}
}