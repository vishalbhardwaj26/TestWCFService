using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationUsingHttpRest
{
    class Program
    {
        static void Main(string[] args)
        {
            Fun();
            Console.ReadLine();

        }

        static async void Fun()
        {
            var uri = new Uri("http://192.168.1.3/TestWCFService/Service1.svc/GetData?value=989");
            using (HttpClient client = new HttpClient())
            {
                var res = await client.GetAsync(uri);
                string str = await res.Content.ReadAsStringAsync();

                Console.WriteLine(str);
            }
        }
    }
}
