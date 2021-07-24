using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsEmployee
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmployeeService : IEmployeeService
    {
        public static String MyConnectionString = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;

        public string AddEmployyeeRecord(Employee emp)
        {
            string result = "";
            try
            {

                SqlConnection con = new SqlConnection(MyConnectionString);
                SqlCommand cmd = new SqlCommand();

                string Query = @"INSERT INTO tblEmployee (EmpID,Name,Email,Phone,Gender)  
                                               Values(@EmpID,@Name,@Email,@Phone,@Gender)";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Added Successfully !";
            }
            catch (FaultException fex)
            {
                result = "Error";
            }

            return result;
        }

        public string DeleteRecords(Employee emp)
        {
            string result = "";
            SqlConnection con = new SqlConnection(MyConnectionString);
            SqlCommand cmd = new SqlCommand();
            string Query = "DELETE FROM tblEmployee Where EmpID=@EmpID";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            result = "Record Deleted Successfully!";
            return result;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public DataSet GetEmployeeRecords()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(MyConnectionString);
                string Query = "SELECT * FROM tblEmployee";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error: " + fex);
            }

            return ds;
        }

        public DataSet SearchEmployeeRecord(Employee emp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(MyConnectionString);
                string Query = "SELECT * FROM tblEmployee WHERE EmpID=@EmpID";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@EmpID", emp.EmpID);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error:  " + fex);
            }
            return ds;
        }

        public string UpdateEmployeeContact(Employee emp)
        {
            string result = "";
            SqlConnection con = new SqlConnection(MyConnectionString);
            SqlCommand cmd = new SqlCommand();

            string Query = "UPDATE tblEmployee SET Email=@Email,Phone=@Phone WHERE EmpID=@EmpID";

            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Phone", emp.Phone);
            con.Open();
            cmd.ExecuteNonQuery();
            result = "Record Updated Successfully !";
            con.Close();

            return result;
        }
 
    } 
}
    

