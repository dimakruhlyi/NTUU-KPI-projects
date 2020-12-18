using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Linq;

namespace Lab6_G
{
    class Program
    {
        static SqlConnection conn;

        static void Main(string[] args)
        {
            try
            {
                Array_Query();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadKey();
        }


        static public void Array_Query()
        {
            int[] mas = new int[] { 10, 20, 30, 40, 50, 60 };

            var query = from u in mas
                        where u > 30
                        select new { p = u + 37, q = u*u };
                        //select u*u + 37;
            
            foreach (var user in query)
            {
                Console.WriteLine(user.p + " "+user.q);
            }
        }



        static public void Query_DB()
        {
            //conn = DBUtils.GetDBConnection();

            //conn.Open();
            //Console.WriteLine("Connect to DB");

            string datasource = @"IT-PROGER\SQLEXPRESS";
            string database = "Laba4Database2";
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security = True";

            DataContext db = new DataContext(connString);

            var query = from u in db.GetTable<Position>()
                        where u.salary > 60
                        orderby u.name_position
                        select u;

            Console.WriteLine("\t\t\t Query syntax");
            Console.WriteLine("------------------------------------------------------------------------\n");
            Console.WriteLine("Id \tPosition \tSalary");
            foreach (var user in query)
            {
                Console.WriteLine("{0} \t{1} \t\t{2}", user.id, user.name_position, user.salary);
            }


            var query1 = db.GetTable<Position>().Where(u => u.salary > 60).OrderBy(u => u.name_position);
           
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t Method Syntax");
            Console.WriteLine("------------------------------------------------------------------------\n");
            Console.WriteLine("Id \tPosition \tSalary");
            foreach (var user2 in query1)
            {
                Console.WriteLine("{0} \t{1} \t\t{2}", user2.id, user2.name_position, user2.salary);
                
            }
        }
    }

    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"IT-PROGER\SQLEXPRESS";
            string database = "Laba4Database2";

            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security = True";

            return new SqlConnection(connString);
        }
    }
}
