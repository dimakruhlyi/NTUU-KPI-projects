using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorker;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                IWorker iWorker = (IWorker)(Activator.GetObject(typeof(IWorker), "tcp://localhost:9999/IWorker"));
                Console.WriteLine("Worker Information");
                Worker worker = iWorker.find();
                Console.WriteLine("Id: " + worker.Id);
                Console.WriteLine("Name: " + worker.Name);
                Console.WriteLine("Surname: " + worker.Surname);
                Console.WriteLine("Salary: " + worker.Salary);
                Console.WriteLine("Address: " + worker.Address);
                Console.WriteLine("Workers Information");
                foreach (Worker w in iWorker.findAll())
                {
                    Console.WriteLine("Id: " + w.Id);
                    Console.WriteLine("Name: " + w.Name);
                    Console.WriteLine("Surname: " + w.Surname);
                    Console.WriteLine("Salary: " + w.Salary);
                    Console.WriteLine("Address: " + w.Address);
                    Console.WriteLine("++++++++++++++++++++++++++");
                }
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("No connection to server");
            }
        }
    }
}
