using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{
    [Table("UserFamily")]
    public class UserFamily
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserNationalId { get; set; }
        public string NationalId { get; set; }
        public string FirstSureName { get; set; }
        public int RelationId { get; set; }
        public string RelationTitle { get; set; }//همسر- فرزند ذکور - فرزند اناث
        public int IsDeleted { get; set; }
    }
}
