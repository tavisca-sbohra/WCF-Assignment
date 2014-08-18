using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.DataManagementService;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;
namespace Test
{
    [TestClass]
    public class TestService
    {
        AddEmployeeClient _objAdd = new AddEmployeeClient();
        GetEmployeeDetailsClient _objGet = new GetEmployeeDetailsClient();

        [TestMethod]
        public void AddEmployeeToList()
        {
            try
            {
                _objAdd.AddNew(1, "Khalisee", "Mother Of Dragons");
                _objAdd.AddNew(2, "Arya", "Stark");
                _objAdd.AddNew(3, "Khalisee", "");
                _objAdd.AddNew(6, "Nedd", "Stark");
               

            }
            catch (FaultException e)
            {
                Debug.WriteLine("dbfbsdf"+e.Code.Name); 
                if (e.Code.Name == "101")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }
        }

        [TestMethod]
        public void AddEmployeeWithSameEmployeeIdToList()
        {
            try
            {
                _objAdd.AddNew(1, "John", "Snow");
            }
            catch (FaultException e)
            {
                if (e.Code.Name == "102")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }
        }

        [TestMethod]
        public void AddNegativeEmployeeIdToList()
        {
            try
            {
                _objAdd.AddNew(-1, "", "");

            }
            catch (FaultException e)
            {
                if (e.Code.Name == "101")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }

        }

        [TestMethod]
        public void AddZeroEmployeeIdToList()
        {
            try
            {
                _objAdd.AddNew(0, "KK", "PJ");

            }
            catch (FaultException e)
            {
                if (e.Code.Name == "101")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }
        }

        [TestMethod]
        public void ReteiveEmployeListExceptionIfTheListIsEmpty()
        {
            try
            {
                Employee[] empList = _objGet.EmployeeList();
                if (empList.Length > 0)
                {
                    foreach (var employee in empList)
                    {
                        Debug.WriteLine(employee.EmployeeID + ". " + employee.FirstName + " " + employee.LastName);
                    }
                }
            }
            catch (FaultException e)
            {
                if (e.Code.Name == "103")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }
        }

        [TestMethod]
        public void AddRemarkToEmployee()
        {
            _objAdd.AddRemark(1, "This employee is diligent . Top Class");
          
        }

        [TestMethod]
        public void AddRemarkToEmployeeIdthatDoesNotExist()
        {
            _objAdd.AddRemark(1000, "This exmployeeNme doesnt EXIST .");

        }
        [TestMethod]
        public void AppendRemarkToAnExistingRemark()
        {
            _objAdd.AddRemark(1, "Knows c# well");
          
        }

        [TestMethod]
        public void GetRemarksByEmployeeID()
        {
            Remarks remark = _objGet.GetRemark(1);
            Debug.WriteLine("Date and time:" + remark.DateTimeNow + "Remark:" + remark.Remark);
        }

        [TestMethod]
        public void GetRemarksByEmployeeIdThatDoesNotExistThrowsException()
        {
            try
            {
                Remarks remark = _objGet.GetRemark(100);
            }
            catch (FaultException e)
            {
                if (e.Code.Name == "106")
                {
                    Console.WriteLine("{0}",e.Reason);
                }
            }
        }

        [TestMethod]
        public void GetAllRemarksAlsoEThrowsExceptionIfRemarksListIsEmpty()
        {
            try
            {
                Remarks[] remarks = _objGet.GetAllRemarks();

                foreach (var r in remarks)
                {
                    Debug.WriteLine(r.EmployeeID + ". " + r.DateTimeNow + " " + r.Remark);
                }
            }
            catch(FaultException e)
            {
                if (e.Code.Name == "105")
                {
                    Console.WriteLine("{0}",e.Reason);
                }
            }
        }

        [TestMethod]
        public void GetAnEmployeeDetailsForValidInput()
        {
            Employee employee = _objGet.EmployeeDetails(1);
            Debug.WriteLine(employee.EmployeeID + ". " + employee.FirstName + " " + employee.LastName);
        }

        [TestMethod]
        public void DetailsForEmployeeInexistentThrowsException()
        {
            try
            {
                Employee employee = _objGet.EmployeeDetails(0);
            }
            catch (FaultException e)
            {
                if (e.Code.Name == "104")
                {
                    Console.WriteLine("{0}", e.Reason);
                }
            }
        }

    }
}
