namespace uLearn.Web.Models
{
	public class UserSearchQueryModel
	{
		public string NamePrefix { get; set; }
		public string Role { get; set; }
		public CourseRole? CourseRole { get; set; }
		public string CourseId { get; set; }
		public bool OnlyPrivileged { get; set; }
	}
}