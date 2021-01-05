using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorker;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using Microsoft.SqlServer.Server;

namespace DotNetRemoting
{
    public class WorkerServer : MarshalByRefObject, IWorker
    {
        
        public Worker find()
        {
            return new Worker { Id = 1, Name = "a", Surname = "d", Salary = 1200, Address = "g" };
            //throw new NotImplementedException();
        }

        public List<Worker> findAll()
        {

            List<Worker> listWorkers = new List<Worker>();

            listWorkers.Add(new Worker { Id = 1, Name = "a", Surname = "d", Salary = 1200, Address = "g" });
            listWorkers.Add(new Worker { Id = 2, Name = "b", Surname = "e", Salary = 100, Address = "h" });
            listWorkers.Add(new Worker { Id = 3, Name = "c", Surname = "f", Salary = 600, Address = "i" });

            return listWorkers;
            //throw new NotImplementedException();
        }
    }
}
