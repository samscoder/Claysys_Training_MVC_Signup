using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SignUp.Models;

namespace SignUp.Repository
{
    public class SignupRepository
    {
        private SqlConnection Con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SignupConnection"].ToString();
            Con = new SqlConnection(constr);
        }

        public bool AddSignup(Signup signup)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Register", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", signup.Name);
            cmd.Parameters.AddWithValue("@DOB", signup.DOB);
            cmd.Parameters.AddWithValue("@Email", signup.email);
            cmd.Parameters.AddWithValue("@Address", signup.address);
            cmd.Parameters.AddWithValue("@Password", signup.password);

            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Signup> GetAllSignups()
        {
            Connection();
            List<Signup> Signuplist = new List<Signup>();
            SqlCommand cmd = new SqlCommand("Selectdata", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Con.Open();
            adapter.Fill(dt);
            Con.Close();

            foreach (DataRow dr in dt.Rows)
                Signuplist.Add(
                    new Signup
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        email = dr["Email"].ToString(),
                        address = dr["Address"].ToString(),
                        password = dr["Password"].ToString()
                    }
                );
            return Signuplist;
        }

        public bool EditSignup(Signup signup)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Updatedata", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", signup.Id);
            cmd.Parameters.AddWithValue("@Name", signup.Name);
            cmd.Parameters.AddWithValue("@DOB", signup.DOB);
            cmd.Parameters.AddWithValue("@Email", signup.email);
            cmd.Parameters.AddWithValue("@Address", signup.address);
            cmd.Parameters.AddWithValue("@Password", signup.password);

            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSignup(int Id)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("Deletedata", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            
            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}