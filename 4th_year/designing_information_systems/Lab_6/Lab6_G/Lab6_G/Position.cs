using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Lab6_G
{
    [Table]
    class Position
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string name_position { get; set; }
        [Column]
        public int salary { get; set; }
    }
}
