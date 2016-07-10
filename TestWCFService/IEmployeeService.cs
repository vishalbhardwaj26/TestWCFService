using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {

        //http://192.168.1.3/TestWCFService/EmployeeService.svc/GetEmployee?ID=101
        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployee?ID={ID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Employee GetEmployee(int ID);

        //http://192.168.1.3/TestWCFService/EmployeeService.svc/GetEmployeeSalary?ID=101
        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployeeSalary?ID={ID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int GetEmployeeSalary(int ID);

        //http://192.168.1.3/TestWCFService/EmployeeService.svc/GetEmployeeList
        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployeeList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Employee> GetEmployeeList();

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddEmployee(Employee Emp);

        //http://192.168.1.3/TestWCFService/EmployeeService.svc/DeleteEmployee/101
        [WebInvoke(Method = "POST", UriTemplate = "/DeleteEmployee/{empId}")]
        [OperationContract]
        void DeleteEmployee(string empId);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public string EmpName
        {
            get;
            set;
        }

        [DataMember]
        public int Salary
        {
            get;
            set;
        }

    }
}
