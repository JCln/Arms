using System.ComponentModel.DataAnnotations.Schema;
namespace Arms.Models
{
    [Table("TanbihiTashviqi")]
    public class TanbihiTashviqi
    {
        public int Id { get; set; }
        public string UserTitle { get; set; }
        public string PersonnelId { get; set; }
        public string AmrieCode { get; set; }
        public string AmrieDay { get; set; }
        public string Description { get; set; }
        public int IsUsed { get; set; }
        public int IsTanbihi { get; set; }
        public int IsDeleted { get; set; }
    }
}
