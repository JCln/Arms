using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms.Models
{    
    [Table("Badge")]
    public class Badge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IsDeleted { get; set; }
    }
}
