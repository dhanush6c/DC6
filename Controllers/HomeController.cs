using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Http;

namespace AngulerJsExamples.Controllers
{
    public class HomeController : ApiController
    {

        public void Registration(string Name, string Email, string Password, string City, string country, string Mobile)
        {
            int result;
            // create and open a connection object
            SqlConnection con = new SqlConnection("Server=192.168.1.133,49300;Database=Sample;User Id=sa ;Password=Smart@2013;");
            con.Open();
            // 1. create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("InsertRegistration_Sp", con);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.Value = Name;
            cmd.Parameters.Add(paramName);

            SqlParameter paramEmail = new SqlParameter();
            paramEmail.ParameterName = "@Email";
            paramEmail.Value = Email;
            cmd.Parameters.Add(paramEmail);

            SqlParameter paramCity = new SqlParameter();
            paramCity.ParameterName = "@City";
            paramCity.Value = City;
            cmd.Parameters.Add(paramCity);

            SqlParameter paramMobile = new SqlParameter();
            paramMobile.ParameterName = "@Mobile";
            paramMobile.Value = Mobile;
            cmd.Parameters.Add(paramMobile);

            SqlParameter paramcountry = new SqlParameter();
            paramcountry.ParameterName = "@country";
            paramcountry.Value = country;
            cmd.Parameters.Add(paramcountry);

            SqlParameter paramPassword = new SqlParameter();
            paramPassword.ParameterName = "@Password";
            paramPassword.Value = Password;
            cmd.Parameters.Add(paramPassword);

            result = cmd.ExecuteNonQuery();         
        }

        [System.Web.Mvc.HttpPost]
        public DataSet RegistrationReport(string Action, int Id)
        {
            DataSet ds = new DataSet();
            // create and open a connection object
            SqlConnection con = new SqlConnection("Server=192.168.1.133,49300;Database=Sample;User Id=sa ;Password=Smart@2013;");
            con.Open();
            // 1. create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("GetRegistrationDetails", con);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;            

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "@Action";
            paramName.Value = Action;
            cmd.Parameters.Add(paramName);

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@RegistrationId";
            paramId.Value = Id;
            cmd.Parameters.Add(paramId);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
                 
        }
        [System.Web.Mvc.HttpPost]
        public DataSet GetRegistrations(string Action, int RegistrationId)
        {
            DataSet ds = new DataSet();
            // create and open a connection object
            SqlConnection con = new SqlConnection("Server=192.168.1.133,49300;Database=Sample;User Id=sa ;Password=Smart@2013;");
            con.Open();
            // 1. create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("GetRegistration", con);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "@Action";
            paramName.Value = Action;
            cmd.Parameters.Add(paramName);

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@RegistrationId";
            paramId.Value = RegistrationId;
            cmd.Parameters.Add(paramId);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;

        }
    }
}
