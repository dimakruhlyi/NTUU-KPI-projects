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


namespace DotNetRemoting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpServerChannel channel = new TcpServerChannel(9999);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(WorkerServer), "IWorker", WellKnownObjectMode.SingleCall);
                Console.WriteLine("Server's running....");
                Console.ReadLine();
                

            }
            catch
            {
                Console.WriteLine("Can't start server");
            }
        }
    }
}
