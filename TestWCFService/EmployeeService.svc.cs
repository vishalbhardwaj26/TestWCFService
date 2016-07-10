using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeService

    {
        IList<Employee> listEmployee;
        public EmployeeService()
        {
            listEmployee = new List<Employee>() { new TestWCFService.Employee { ID=101,EmpName="Vishal",Salary=2000},
            new Employee { ID=201,EmpName="Vikram",Salary=4000}};

        }
        public void AddEmployee(Employee Emp)
        {
            listEmployee.Add(Emp);
        }

        public void DeleteEmployee(string empId)
        {
            Employee emp = listEmployee.FirstOrDefault(o => o.ID == Convert.ToInt32(empId));
            if (emp != null)
                listEmployee.Remove(emp);
        }

        public Employee GetEmployee(int ID)
        {
            Employee emp = listEmployee.FirstOrDefault(o => o.ID == ID);
            return emp;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return listEmployee;
        }

        public int GetEmployeeSalary(int ID)
        {
            Employee emp = listEmployee.FirstOrDefault(o => o.ID == ID);
            if (emp != null)
                return emp.Salary;
            return -1;

        }
    }
}
