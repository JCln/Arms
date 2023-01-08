using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{
    [Table("Loan")]
    public class Loan
    {        
        public int Id { get; set; }
        public string Code { get; set; }
        public string UserTitle { get; set; }
        public string PersonnelId { get; set; }
        public int Amount { get; set; }
        public string DayRegister { get; set; }
        public string DayReceive { get; set; }
        public string Description { get; set; }
        public int IsDeleted { get; set; }
    }
}
