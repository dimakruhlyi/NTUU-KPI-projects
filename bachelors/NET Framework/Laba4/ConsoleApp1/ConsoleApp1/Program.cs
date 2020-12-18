using System;
using Deque;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<string> usersDeck = new Deque<string>();


            usersDeck.Count += (obj, events) => {
                Console.WriteLine(((Deque<string>)obj).count + " " + events.Data);
            };
            
            usersDeck.AddFirst("Alis");
            usersDeck.AddFirst("Mary");
            usersDeck.AddFirst("Alex");

            foreach (string s in usersDeck)
                Console.WriteLine(s);
           

            string removedItem = usersDeck.RemoveLast();
            Console.WriteLine("\n Удален: {0} \n", removedItem);
           
            foreach (string s in usersDeck)
                Console.WriteLine(s);
            Console.ReadKey();



            ////////////////////////////////////

            // Deque<Student> studentsDeck = new Deque<Student>();

            // Student Pavlik = new Student("Vlad", "Koshmak");
            // Student Masha = new Student("Misha", "Novak");

            // studentsDeck.AddFirst(Pavlik);
            // studentsDeck.AddLast(Masha);
            // foreach (Student s in studentsDeck)
            //     Console.WriteLine("\n" + s.name + " " + s.surname );

        }
        
        /// <summary>
        /// Событие подсчета элементов в деке
        /// </summary>
        
    }

    

    //class Student {
    //    public Student(string name, string surname)
    //    {
    //        this.name = name;
    //        this.surname = surname;
    //    }

    //    public string name { get; set; }
    //    public string surname { get; set; }
    //}
}
 