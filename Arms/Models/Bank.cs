using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms.Models
{
    [Table("Bank")]
    public class Bank
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
