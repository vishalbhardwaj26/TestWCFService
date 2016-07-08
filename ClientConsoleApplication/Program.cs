using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            Console.WriteLine(client.GetData(428));

            Console.ReadLine();
        }
    }
}
