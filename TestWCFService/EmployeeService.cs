//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace TestWCFService
//{
//    public class EmployeeService : IEmployeeService

//    {
//        IList<Employee> listEmployee;
//        public EmployeeService()
//        {
//            listEmployee = new List<Employee>() { new TestWCFService.Employee { ID=101,EmpName="Vishal",Salary=2000},
//            new Employee { ID=201,EmpName="Vikram",Salary=4000}};
            
//        }
//        public void AddEmployee(Employee Emp)
//        {
//            listEmployee.Add(Emp);
//        }

//        public void DeleteEmployee(int empId)
//        {
//            Employee emp = listEmployee.FirstOrDefault(o => o.ID == empId);
//            if(emp !=null)
//            listEmployee.Remove(emp);
//        }

//        public Employee GetEmployee(int ID)
//        {
//            Employee emp = listEmployee.FirstOrDefault(o => o.ID == ID);
//            return emp;
//        }

//        public IEnumerable<Employee> GetEmployeeList()
//        {
//            return listEmployee;
//        }

//        public int GetEmployeeSalary(int ID)
//        {
//            Employee emp = listEmployee.FirstOrDefault(o => o.ID == ID);
//            if (emp != null)
//                return emp.Salary;
//            return -1;

//        }
//    }
//}