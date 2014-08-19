using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.DataManagementService;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
namespace Test
{
    [TestClass]
    public class TestService
    {
        AddEmployeeClient _objAdd = new AddEmployeeClient();
        GetEmployeeDetailsClient _objGet = new GetEmployeeDetailsClient();

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddEmployeeToList()
        {
            _objAdd.AddNew(2, "Nedd", "Stark");
            Assert.IsTrue(_objAdd.AddNew(1, "Khalisee", "Mother Of Dragons"), "Added Khalisee");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddEmployeeEntryWithNullValueInName()
        {
            Assert.IsTrue(_objAdd.AddNew(90, "", ""), "This should throw an exception Yo");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddEmployeeWithSameEmployeeIdToList()
        {
            Assert.IsTrue(_objAdd.AddNew(1, "John", "Snow"), "This should throw an exception Yo");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddNegativeEmployeeIdToList()
        {
            Assert.IsTrue(_objAdd.AddNew(-1, "", ""), "This should throw an exception Yo");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddZeroEmployeeIdToList()
        {
            Assert.IsTrue(_objAdd.AddNew(0, "KK", "PJ"), "This should throw an exception Yo");
        }

        [TestMethod]
        public void ReteiveEmployeListExceptionIfTheListIsEmpty()
        {
            Employee[] empList = _objGet.EmployeeList();
            Assert.IsNotNull(empList, "Employee List is not empty");
            foreach (var employee in empList)
            {
                Debug.WriteLine(employee.EmployeeID + ". " + employee.FirstName + " " + employee.LastName);
            }
        }

        [TestMethod]
        public void AddRemarkToEmployee()
        {
            Assert.IsTrue(_objAdd.AddRemark(1, "This employee is diligent . Top Class"), "Added Remark To Employee");
        }

        [TestMethod]
        public void AddRemarkToEmployeeIdthatDoesNotExist()
        {
            Assert.IsTrue(_objAdd.AddRemark(1000, "This exmployeeName doesnt EXIST ."), "Addeed remark for employee that does not exist :P");
        }

        [TestMethod]
        public void AppendRemarkToAnExistingRemark()
        {
            Assert.IsTrue(_objAdd.AddRemark(1, "Knows c# well"), "appended remark on employee with employee id 1");
        }

        [TestMethod]
        public void GetRemarksByEmployeeID()
        {
            Remarks remark = _objGet.GetRemark(1);
            Assert.IsNotNull(remark, "Date and time:" + remark.DateTimeNow + "Remark:" + remark.Remark);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetRemarksByEmployeeIdThatDoesNotExistThrowsException()
        {
            Remarks remark = _objGet.GetRemark(100);
            Assert.IsNull(remark, "Remark on this employee Id deos nto exist");
        }

        [TestMethod]
        public void GetAllRemarksAlsoEThrowsExceptionIfRemarksListIsEmpty()
        {
            Remarks[] remarks = _objGet.GetAllRemarks();
            Assert.IsNotNull(remarks, "The remarks list is not empty.the reamrks are:");
            foreach (var r in remarks)
            {
                Debug.WriteLine(r.EmployeeID + ". " + r.DateTimeNow + " " + r.Remark);
            }
        }

        [TestMethod]
        public void GetAnEmployeeDetailsByEmpIdForValidInput()
        {
            Employee employee = _objGet.EmployeeDetails(1);
            Assert.IsNotNull(employee, employee.EmployeeID + ". " + employee.FirstName + " " + employee.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void DetailsForEmployeeInexistentThrowsExceptionSearchById()
        {
            Employee employee = _objGet.EmployeeDetails(0);
            Assert.IsNull(employee, "Told you ,this was null but there should have been an exception :/");
        }

        [TestMethod]
        public void GetAnEmployeeDetailsByFirstNameForValidInput()
        {
            Employee[] employee = _objGet.EmployeeDetailsByName("nedd");
            Assert.IsNotNull(employee, "employee with the name nedd exisits");
            foreach (var r in employee)
            {
                Debug.WriteLine(r.EmployeeID + ". " + r.FirstName + " " + r.LastName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetAnEmployeeDetailsByFirstNameFoInNValidInputThrowsException()
        {
            Employee[] employee = _objGet.EmployeeDetailsByName("Dumbledore");
            Assert.IsNull(employee, "dumbledore is not im employee list");
        }

        [TestMethod]
        public void GetAllEmployeeWithRemarks()
        {
            List<Remarks> remarks = new List<Remarks>(_objGet.GetAllRemarks());
            List<Employee> employees = new List<Employee>(_objGet.EmployeeList());
            foreach (Employee e in employees)
            {
                
                if (remarks.Exists(x => x.EmployeeID == e.EmployeeID))
                {
                    Debug.WriteLine(e.EmployeeID + " " + e.FirstName + " " + e.LastName);
                    Remarks remark = remarks.Find(x => x.EmployeeID == e.EmployeeID);
                    Debug.WriteLine(remark.DateTimeNow+ " "+remark.Remark+"\n");
                }
            }
        }
    }
}
