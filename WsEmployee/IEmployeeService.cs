using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsEmployee
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmployeeService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string AddEmployyeeRecord(Employee emp);

        [OperationContract]
        DataSet GetEmployeeRecords();

        [OperationContract]
        string DeleteRecords(Employee emp);

        [OperationContract]
        DataSet SearchEmployeeRecord(Employee emp);

        [OperationContract]
        string UpdateEmployeeContact(Employee emp);

    }

    [DataContract]
    public class Employee
    {

        string _empID = "";
        string _name = "";
        string _email = "";
        string _phone = "";
        string _gender = "";

        [DataMember]
        public string EmpID
        {
            get { return _empID; }
            set { _empID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        [DataMember]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
    }

}
