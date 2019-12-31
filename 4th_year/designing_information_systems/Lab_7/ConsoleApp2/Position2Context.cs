using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Position2Context : DbContext
    {
        public Position2Context() : base("DbConnection")
        {

        }

        public DbSet<Position2> Positions2 { get; set; }
    }
}
