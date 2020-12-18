using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseFirst();
            //CodeFirst();
            Console.ReadLine();
        }
        public static void DataBaseFirst()
        {
            using (var db = new Laba4Database2Entities())
            {

                //Console.Write("Input data for id of position: ");
                //var Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input data for name of position: ");
                var name = Console.ReadLine();
                Console.Write("Input data for salary of position: ");
                var salar = Convert.ToInt32(Console.ReadLine());


                var position = new Position { Name_position = name, Salary = salar };
                db.Positions.Add(position);
                db.SaveChanges();


                var query = from b in db.Positions
                            orderby b.Id
                            select b;

                Console.WriteLine("All positions in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Id + " " + item.Name_position + " " + item.Salary);
                }


                Console.ReadKey();
            }
        }

        public static void CodeFirst()
        {
            using (Position2Context db = new Position2Context())
            {
                //Position2 employee1 = new Position2 { Name_position = "Anna", Salary = 700 };
                //db.Positions2.Add(employee1);
                //db.SaveChanges();

                var employees = db.Positions2;
                Console.WriteLine("Employees list:");
                foreach (Position2 u in employees)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name_position, u.Salary);
                }

            }
        }
    }
}
