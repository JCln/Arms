using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{    
    [Table("Job")]
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
