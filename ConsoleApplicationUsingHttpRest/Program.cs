using Newtonsoft.Json;
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
            AddEmployee();
            Console.ReadLine();
            WriteEmployeeList();
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
                Console.WriteLine("***************************");
            }
            
        }

        static async void AddEmployee()
        {
            employee e = new employee();
            e.ID = 901;
            e.EmpName = "Kavansh";

            Uri geturi = new Uri("http://192.168.1.3/TestWCFService/EmployeeService.svc/AddEmployee"); //replace your url  
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            //we dont have PostAsJsonAsync ; so write it our self the code; otherwise
            // you can use PostAsJsonAsync; part of System.Net.Http.Fomratting extension and can ne found with NewtonSoft
            var response = await client.PostAsync(geturi, new StringContent(
                   Newtonsoft.Json.JsonConvert.SerializeObject(e),
                   Encoding.UTF8, "application/json"));


            Console.WriteLine("Added Employee");
            Console.WriteLine("Now getting same Employee");

            geturi = new Uri("http://192.168.1.3/TestWCFService/EmployeeService.svc/GetEmployee?ID=" + e.ID); //replace your url  
            System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
            var response1 = await responseGet.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(response1);
            Console.WriteLine(obj["EmpName"] + " " + obj["ID"] + " " + obj["Salary"]);

            Console.WriteLine("***************************");
        }

        //This one the extension for httpclient if needed
        //static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string addr, object obj)
        //{
        //    var response = await client.PostAsync(addr, new StringContent(
        //            Newtonsoft.Json.JsonConvert.SerializeObject(obj),
        //            Encoding.UTF8, "application/json"));

        //    return response;
        //}
        static async void WriteEmployeeList()
        {
            Console.WriteLine("ListingEmployee");
            Uri geturi = new Uri("http://192.168.1.3/TestWCFService/EmployeeService.svc/GetEmployeeList?"); //replace your url  
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                System.Net.Http.HttpResponseMessage responseGet = await client.GetAsync(geturi);
                var response = await responseGet.Content.ReadAsStringAsync();

                dynamic objArray = JsonConvert.DeserializeObject(response);
                foreach (var obj in objArray)
                {
                    Console.WriteLine(obj["EmpName"]);
                }
            }

           
            
        }

        struct employee
        {
            public int ID;
            public string EmpName;
        }
    }
}
