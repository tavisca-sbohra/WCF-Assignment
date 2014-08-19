using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace EmployeeManagementService
{
    public class InputValidation : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "AddNew")
            {
                Int32 employeeId = (Int32)inputs[0];
                string firstName = (string)inputs[1];
                if(employeeId <= 0)
                {
                    throw new FaultException(new FaultReason("Employee Id should be positive"), new FaultCode("101"));
                }
                if (firstName == null && firstName =="")
                {
                    throw new FaultException(new FaultReason("Employee entry should contain a name"), new FaultCode("108"));
                }
            }
            if (operationName == "EmployeeDetails")
            {
                Int32 employeeId = (Int32)inputs[0];
                if(employeeId <= 0)
                {
                    throw new FaultException(new FaultReason("Employee Id should be positive"), new FaultCode("101"));
                }
            }

            if (operationName == "EmployeeDetailsByName")
            {
                string firstName = (string)inputs[0];
                if (string.IsNullOrEmpty(firstName))
                {
                    throw new FaultException(new FaultReason("Employee entry should contain a name"), new FaultCode("108"));
                }
            }
            if (operationName == "AddRemark")
            {
               Int32 employeeId = (Int32)inputs[0];
                if (employeeId<=0)
                {
                     throw new FaultException(new FaultReason("Employee Id should be positive"), new FaultCode("101"));
                }
                string remark=(string)inputs[1];
                if(string.IsNullOrEmpty(remark))
                {
                    throw new FaultException(new FaultReason("Remark is null"), new FaultCode("109"));
                }
            }
            if (operationName == "GetRemark")
            {
               Int32 employeeId = (Int32)inputs[0];
                if (employeeId<=0)
                {
                     throw new FaultException(new FaultReason("Employee Id should be positive"), new FaultCode("101"));
                }
            }
            
            return null;
        }
    }
}