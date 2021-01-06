using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Text;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service1), new Uri("http://localhost:8000/"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "");
                host.Open();
                using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    IService1 channel = cf.CreateChannel();

                    string s;

                    Console.WriteLine("Викликаємо EchoWithGet через HTTP GET: ");
                    s = channel.EchoWithGet("Hello, world");
                    Console.WriteLine("   Вивід: {0}", s);

                    Console.WriteLine("");
                    Console.WriteLine("Це також можна виконати, перейшовши до");
                    Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("у веб-браузері, доки це рішення запущено.");

                    Console.WriteLine("");

                    Console.WriteLine("Викликаємо EchoWithPost через HTTP POST: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine("   Вивід: {0}", s);
                    Console.WriteLine("");
                }

                Console.WriteLine("Натисніть <ENTER> для припинення");
                Console.ReadLine();

                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("Виникла помилка: {0}", cex.Message);
                host.Abort();
            }
        }
    }



}
