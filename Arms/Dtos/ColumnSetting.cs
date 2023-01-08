using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms.Dtos
{
    public class ColumnSetting
    {
        public string ColumnName { get; set; }
        public string ColumnHeader { get; set; }
        public bool Show { get; set; }
        public int Order { get; set; }
    }
}
