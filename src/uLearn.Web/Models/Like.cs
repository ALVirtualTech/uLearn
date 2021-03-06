﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uLearn.Web.Models
{
	public class Like
	{
		[Key]
		public int Id { get; set; }

		public virtual UserSolution UserSolution { get; set; }
		
		[Required]
		[Index("UserAndSolution", 2)]
		public int UserSolutionId { get; set; }

		[Required]
		[StringLength(64)]
		[Index("UserAndSolution", 1)]
		public string UserId { get; set; }

		public virtual ApplicationUser User { get; set; }

		[Required]
		public DateTime Timestamp { get; set; }
	}
}