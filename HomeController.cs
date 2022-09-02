using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace SampleJs.Controllers
{
    public class HomeController : ApiController
    {
         public void Registration(string Name, string Email, string Password, string City, string country, string Mobile, string Pincode)
 {
  int result;

  SqlConnection con = new
  SqlConnection("Server=192.168.1.133;Database=Sample;User Id=sa ;Password=Smart@2013;");

  con.Open();

 SqlCommand cmd = new SqlCommand("InsertRegistration_Sp", con);

 cmd.CommandType = CommandType.StoredProcedure;

 SqlParameter paramName = new SqlParameter();
 paramName.ParameterName = "@Name";
 paramName.Value = Name;
 cmd.Parameters.Add(paramName);

 SqlParameter paramEmail = new SqlParameter();
 paramEmail.ParameterName = "@Email";
 paramEmail.Value = Email;
 cmd.Parameters.Add(paramEmail);

 SqlParameter paramAddress = new SqlParameter();
 paramAddress.ParameterName = "@Address";
 paramAddress.Value = City;
 cmd.Parameters.Add(paramAddress);

 SqlParameter paramMobile = new SqlParameter();
 paramMobile.ParameterName = "@Mobile";
 paramMobile.Value = Mobile;
 cmd.Parameters.Add(paramMobile);

 SqlParameter paramPincode = new SqlParameter();
 paramPincode.ParameterName = "@Pincode";
 paramPincode.Value = Pincode;
 cmd.Parameters.Add(paramPincode);
 

 result = cmd.ExecuteNonQuery(); 
 }

 [System.Web.Mvc.HttpPost]
 public DataSet RegistrationReport(string Action, int Id)
 {
 DataSet ds = new DataSet();

 SqlConnection con = new
 SqlConnection("Server=192.168.1.133,49300;Database=Sample;User Id=sa ;Password=Smart@2013;");
 con.Open();

 SqlCommand cmd = new SqlCommand("GetRegistrationDetails", con);

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
    }
}


