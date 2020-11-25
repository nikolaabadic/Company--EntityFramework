using System;
using System.Collections.Generic;
using System.Linq;
using Company.Data.UnitOfWork;
using Company.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.ConsoleApp
{
    class Program
    {
        static CompanyContext context = new CompanyContext();

        #region Department
        //create
        public static void AddDepartments()
        {
            context.Add(new Department { Name = "Marketing"});
            context.Add(new Department { Name = "IT" });
            context.Add(new Department { Name = "Sales" });
            context.Add(new Department { Name = "Logistics" });
            context.Add(new Department { Name = "Production" });
            context.Add(new Department { Name = "Research and Development" });
            context.SaveChanges();
        }
        //read
        public static void GetAllDepartments()
        {
            List<Department> departments = context.Departments.ToList();
            departments.ForEach(d => Console.WriteLine(d));
        }
        public static void GetDepartmentsWhere()
        {
            List<Department> departments = context.Departments.Where(d => d.DepartmentID > 2).ToList();
            departments.ForEach(d => Console.WriteLine(d));
        }
        //update
        public static void UpdateDepartmentTracking()
        {
            Department department = context.Departments.ToList()[0];
            department.Name = "Marketing & PR";
            context.SaveChanges();
        }
        public static void UpdateDepartmentNoTracking()
        {
            Department department = new Department { DepartmentID = 2, Name = "IT" };
            department.Name = "Information technology";
            context.Update(department);
            context.SaveChanges();

        }
        #endregion

        #region Employee
        //create
        public static void AddEmployees()
        {
            context.Add(new Employee { Name = "Xavier", Lastname = "Hansen", Birthday = new DateTime(1998,8,8), DepartmentID = 1});
            context.Add(new Employee { Name = "Anabelle", Lastname = "Moses", Birthday = new DateTime(1989, 5, 12), DepartmentID = 2 });
            context.Add(new Employee { Name = "Kole", Lastname = "Flores", Birthday = new DateTime(1996, 7, 11), DepartmentID = 2 });
            context.Add(new Employee { Name = "Jim", Lastname = "Carroll", Birthday = new DateTime(1985, 5, 5), DepartmentID = 3 });
            context.Add(new Employee { Name = "Byron", Lastname = "Brennan", Birthday = new DateTime(1991, 1, 14), DepartmentID = 4 });
            context.SaveChanges();
        }
        //read
        public static void GetAllEmployees()
        {
            context.Employees.Include(e => e.Department).ToList().ForEach(e => Console.WriteLine(e));
        }
        public static void GetEmployeesWhere()
        {
            context.Employees.Include(e => e.Department).Where(e => e.Name.Contains("l")).ToList().ForEach(e => Console.WriteLine(e));
        }
        //update
        public static void UpdateEmployeeTracking()
        {
            Employee employee = context.Employees.ToList()[0];
            employee.Name = "Mark";
            context.SaveChanges();
        }
        public static void UpdateEmployeeNoTracking()
        {
            Employee employee = new Employee { EmployeeID = 3, Name = "Kole", Lastname = "Flores", Birthday = new DateTime(1996, 7, 11), DepartmentID = 2 };
            employee.Lastname = "Jones";
            context.Update(employee);
            context.SaveChanges();
        }
        public static void UpdateEmployeesDepartmentTracking()
        {
            Employee employee = context.Employees.Include(e => e.Department).ToList()[0];
            employee.Department.Name = "Marketing";
            context.SaveChanges();
        }
        public static void UpdateEmplyeesDepartmentNoTracking()
        {
            Employee employee = context.Employees.Include(e => e.Department).ToList()[0];
            using CompanyContext newContext = new CompanyContext();

            employee.Department.Name = "Marketing & PR";
            newContext.Update(employee);
            newContext.SaveChanges();
        }
        public static void UpdateOnlyDepartmentsNoTracking()
        {
            Employee employee = context.Employees.Include(e => e.Department).ToList()[0];
            using CompanyContext newContext = new CompanyContext();

            newContext.Attach(employee);
            employee.Department.Name = "Marketing";
            newContext.Entry(employee.Department).State = EntityState.Modified;
            newContext.SaveChanges();
        }
        #endregion

        #region Payments
        //create
        public static void AddEmployeeWithPayments()
        {
            context.Employees.Add(
                new Employee
                {
                    Name = "Chandler",
                    Lastname = "Bing",
                    Birthday = new DateTime(1980, 6, 17),
                    DepartmentID = 5,
                    Payments = new List<Payment>
                    {
                        new Payment{ Amount = 1000, DateOfPayment = new DateTime(2020,10,1)},
                        new Payment{ Amount = 1000, DateOfPayment = new DateTime(2020,11,1)},
                        new Payment{ Amount = 200, DateOfPayment = new DateTime(2020,11,20)}
                    }
                });
            context.SaveChanges();
        }
        public static void AddPaymentToEmployeeTracking()
        {
            Employee employee = context.Employees.Include(e => e.Payments).ToList()[1];
            employee.Payments.Add(new Payment { Amount = 1200, DateOfPayment = new DateTime(2020, 11, 10) });
            context.SaveChanges();
        }
        public static void AddPaymentToEmployeeNoTracking()
        {
            Employee employee = context.Employees.First();
            employee.Payments.Add(new Payment { Amount = 750, DateOfPayment = new DateTime(2020, 11, 4) });
            
            using CompanyContext newContext = new CompanyContext();
                       
            newContext.Update(employee);
            newContext.Entry(employee.Payments.Single(p => p.Amount == 750 && p.DateOfPayment == new DateTime(2020, 11, 4))).State = EntityState.Added;
            newContext.SaveChanges();            
        }
        //read

        //update
        #endregion

        #region Tasks
        //create
        public static void AddResponsibilities()
        {
            context.Add(new Responsibility { EmployeeID = 11, TaskID = 1 });
            context.Add(new Responsibility { EmployeeID = 20, TaskID = 2 });
            context.SaveChanges();
        }
        //read
        public static void SelectEmployeesWithTasks()
        {
            var employees = context.Employees.Select(e => new {
                e.Name,
                e.Lastname,
                Tasks = e.Tasks.Select(t => t.Task)
            }).ToList();
            foreach(var employee in employees)
            {
                foreach(var task in employee.Tasks)
                {
                    Console.WriteLine($"{employee.Name} {employee.Lastname} {task}");
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            //AddDepartments();
            //GetAllDepartments();
            //GetDepartmentsWhere();
            //UpdateDepartmentTracking();
            //UpdateDepartmentNoTracking();

            //AddEmployees();
            //GetAllEmployees();
            //GetEmployeesWhere();
            //UpdateEmployeeTracking();
            //UpdateEmployeeNoTracking();
            //UpdateEmployeesDepartmentTracking();
            //UpdateEmplyeesDepartmentNoTracking();
            //UpdateOnlyDepartmentsNoTracking();

            //AddEmployeeWithPayments();
            //AddPaymentToEmployeeTracking();
            //AddPaymentToEmployeeNoTracking();

            //AddResponsibilities();
            //SelectEmployeesWithTasks();
            //context.Dispose();

            using IUnitOfWork uow = new CompanyUnitOfWork(new CompanyContext());
            uow.Employee.Add(new Employee { Name = "Severous", Lastname = "Snape", Birthday = new DateTime(1970, 5, 5), DepartmentID = 1 });
            uow.Task.Add(new Task { Name = "Budget presentation" });
            uow.Commit();
        }
    }
}
