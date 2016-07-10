using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TestWCFService;

namespace ConsoleApplicationUsingHttpWcfRest
{
    /// <summary>
    /// We have added TestWCFService as reference to access IEmployeeService and Employee data.
    /// because we are using WebChannelFactory here which need shared dll of contracts but dont have any so we directly added 
    /// Service project :)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            fun();

            Console.ReadLine();
        }
        static void fun()
        {
            
            WebChannelFactory<IEmployeeService> cf = 
                new WebChannelFactory<IEmployeeService>(new Uri("http://192.168.1.3/TestWCFService/EmployeeService.svc"));

            IEmployeeService client = cf.CreateChannel();
            
            
            client.AddEmployee(new Employee { ID = 301, EmpName = "Reyansh", Salary = 5000 });
            var v = client.GetEmployee(301);
            if(v !=null)
            Console.WriteLine(v.EmpName);

            Console.WriteLine("***************************");

            //Employee e = JsonConvert.DeserializeObject<Employee>(v);
            var Obj = client.GetEmployeeList();
            foreach(Employee emp in Obj)
            {
                Console.WriteLine(emp.ID + " " + emp.EmpName + " " + emp.Salary);
            }


            Console.WriteLine("***************************");
            client.DeleteEmployee("101");
            
            Obj = client.GetEmployeeList();
            foreach (Employee emp in Obj)
            {
                Console.WriteLine(emp.ID + " " + emp.EmpName + " " + emp.Salary);
            }
        }
    }
}
