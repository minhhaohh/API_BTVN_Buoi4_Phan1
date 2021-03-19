using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TranMinhHao_5951071021.Models
{
    public class Db
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-92V95VD\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");

        //Select
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        //Insert and Update
        public string Empdml(Employee emp, out string msg)
        {
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                msg = ex.Message;
                return msg;
            }
        }

    }

}
