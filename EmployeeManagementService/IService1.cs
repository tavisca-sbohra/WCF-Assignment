using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagementService
{
    [ServiceContract]
    public interface IAddEmployee
    {
        [OperationContract]
        void  AddNew(int EmployeeID,string FirstName,string LastName);

        [OperationContract]
        void AddRemark(int EmployeeID,string Remark);
    }

    [ServiceContract]
    public interface IGetEmployeeDetails
    {
        [OperationContract]
        List<Employee> EmployeeList();
        [OperationContract]
        Employee EmployeeDetails(int EmployeeID);
        [OperationContract]
        Remarks GetRemark(int EmployeeID);
        [OperationContract]
        List<Remarks> GetAllRemarks();
    }
    [DataContract]
    public class EmployeeIdentity
    {
        [DataMember]
        public int EmployeeID { get; set; }
    }
    [DataContract]
    public class Employee :EmployeeIdentity
    {
        
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
    [DataContract]
    public class Remarks : EmployeeIdentity
    {
        [DataMember]
        public string Remark{ get ; set; }
        [DataMember]
        public DateTime DateTimeNow { get; set; }
    }
}
