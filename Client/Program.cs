using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataManagementService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AddEmployeeClient objAdd = new AddEmployeeClient();
            GetEmployeeDetailsClient objGet = new GetEmployeeDetailsClient();
            string answer = "YES";
            do
            {
                Console.WriteLine("\n1. Add an employee \n2. Retrieve the Employee list\n3. Add remark to an employee\n4. Get an employee details \n5. Get Remarks By EmployeeID \n6. Get all Remarks");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the Employee ID");
                        Console.WriteLine("Enter the First Name");
                        Console.WriteLine("Enter the Last Name");
                        string EmpNo = Console.ReadLine();
                        int id;
                        bool result = Int32.TryParse(EmpNo, out id);
                        string FirstName = Console.ReadLine();
                        string LastName = Console.ReadLine();
                        int EmployeeID = id;
                        objAdd.AddNew(id, FirstName, LastName);
                        break;
                    case "2":
                        Employee[] empList = objGet.EmployeeList();
                        foreach (var employee in empList)
                        {
                            Console.WriteLine(employee.EmployeeID + ". " + employee.FirstName + " " + employee.LastName);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the Employee ID");
                        EmpNo = Console.ReadLine();
                        result = Int32.TryParse(EmpNo, out id);
                        Console.WriteLine("Remark:");
                        string remarkText = Console.ReadLine();
                        objAdd.AddRemark(id, remarkText);
                        break;
                    case "4":
                        Console.WriteLine("Enter the Employee ID");
                        EmpNo = Console.ReadLine();
                        result = Int32.TryParse(EmpNo, out id);
                        Employee employeeBuff = objGet.EmployeeDetails(id);
                        Console.WriteLine("Employee:" + employeeBuff.EmployeeID + " " + employeeBuff.FirstName + " " + employeeBuff.LastName);
                        break;
                    case "5":
                        Console.WriteLine("Enter the Employee ID");
                        EmpNo = Console.ReadLine();
                        result = Int32.TryParse(EmpNo, out id);
                        Remarks remark = objGet.GetRemark(id);
                        Console.WriteLine("Date and time:" + remark.DateTimeNow + "Remark:" + remark.Remark);
                        break;
                    case "6":
                        Remarks[] remarks = objGet.GetAllRemarks();
                        foreach (var r in remarks)
                        {
                            Console.WriteLine(r.EmployeeID + ". " + r.DateTimeNow + " " + r.Remark);
                        }
                        break;
                    default:
                        Console.WriteLine("\nPlease Enter a valid choice!");
                        break;

                }
                Console.WriteLine("Press E to Exit");
                answer = Console.ReadLine().ToUpper();
            } while (!answer.Equals("E"));

        }
    }
}
