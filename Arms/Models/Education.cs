using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{    
    [Table("Education")]
    public class Education
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
