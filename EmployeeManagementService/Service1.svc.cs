﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AddEmployee : IAddEmployee, IGetEmployeeDetails
    {
        static List<Employee> _employeeList = new List<Employee>();
        static List<Remarks> _remarksList = new List<Remarks>();

        public void AddNew(int employeeId, string firstName, string lastName)
        {
            if (employeeId <= 0 || employeeId==null)
            {
                throw new FaultException(new FaultReason("Id should be a positive number"), new FaultCode("101"));
            }
            if (employeeId <= int.MaxValue)
            {
                if (_employeeList.Exists(x => x.EmployeeID == employeeId))
                {
                    throw new FaultException(new FaultReason("Employee Id already exists"), new FaultCode("102"));
                }
                Employee employee = new Employee();
                employee.EmployeeID = employeeId;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                _employeeList.Add(employee);
            }

        }

        public List<Employee> EmployeeList()
        {
            if (_employeeList.Count <= 0)
            {
                throw new FaultException(new FaultReason("Employee list is empty.Add employees to it  "), new FaultCode("103"));
            }
                Console.WriteLine(_employeeList);
                return _employeeList;
        }

        public void AddRemark(int empID, string remarkText)
        {
            if (empID!=null)
            {
                if (!_remarksList.Exists(x => x.EmployeeID == empID))
                {
                    Remarks remark = new Remarks();
                    remark.EmployeeID = empID;
                    remark.DateTimeNow = DateTime.UtcNow;
                    remark.Remark = remarkText;
                    _remarksList.Add(remark);
                }
                ///If the Remark on Employee already exists then append to the previous remark
                else
                {
                    Remarks remark = _remarksList.Find(x => x.EmployeeID == empID);
                    remark.Remark += remarkText;
                }
            }
        }

        public Remarks GetRemark(int empID)
        {
                if (_remarksList.Exists(x => x.EmployeeID == empID))
                {
                    Remarks remark = _remarksList.Find(x => x.EmployeeID == empID);
                    return remark;
                }
                throw new FaultException(new FaultReason("That employee ID does not exist in the database"), new FaultCode("106"));
        }

        public List<Remarks> GetAllRemarks()
        {
            if (_remarksList.Count > 0)
            {
                return _remarksList;
            }
            else
            {
                throw new FaultException(new FaultReason("The remarks list is empty!!!!"),new FaultCode("105"));
            }
        }

        public Employee EmployeeDetails(int employeeId)
        {
            if (_employeeList.Exists(x => x.EmployeeID == employeeId))
            {
                Employee employee = _employeeList.Find(x => x.EmployeeID == employeeId);
                return employee;
            }
            throw new FaultException(new FaultReason("That Employee Id does not exist!!! :O "), new FaultCode("104"));
        }
       
    }
}