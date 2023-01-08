using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{
    [Table("OffType")]
    public class OffType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
