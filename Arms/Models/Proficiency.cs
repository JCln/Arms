using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{    
    [Table("Proficiency")]
    public class Proficiency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
