using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{
    [Table("UserCourse")]
    public class UserCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NationalId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public int IsDeleted { get; set; }
    }
}
