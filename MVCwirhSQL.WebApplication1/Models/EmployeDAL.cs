using MVCwirhSQL.WebApplication1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCwirhSQL.Models
{
    public class EmployeDAL
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        public EmployeDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employe> GetAllEmployee()
        {
            List<Employe> list = new List<Employe>();
            string str = "select * from EmpInfo";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employe E = new Employe();
                    E.Id = Convert.ToInt32(dr["id"]);
                    E.Emp_Name = dr["Emp Name"].ToString();
                    E.Dep_Name = dr["Emp Dep"].ToString();
                    E.Emp_Salary = Convert.ToDecimal(dr["Emp Salary"]);
                    list.Add(E);
                }
                con.Close();
                return list;
            }
            con.Close();
            return list;
        }

        internal Employe GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Employe GetEmployeById(int id)
        {
            Employe E = new Employe();
            string str = "select * from EmpInfo where id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    E.Id = Convert.ToInt32(dr["id"]);
                    E.Emp_Name = dr["Emp Name"].ToString();
                    E.Dep_Name = dr["Emp Dep"].ToString();
                    E.Emp_Salary = Convert.ToDecimal(dr["Emp Salary"]);


                }
                con.Close();
                return E;
            }
            con.Close();
            return E;

        }
        public int Save(Employe emp)
        {
            string str = "insert into EmpInfo values (@Emp Name,@Emp Dep,@Emp Salary)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Emp Name", emp.Emp_Name);
            cmd.Parameters.AddWithValue("@Emp Dep", emp.Dep_Name);
            cmd.Parameters.AddWithValue("@Emp Salary", emp.Emp_Salary);

            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }



        public int update(Employe emp)
        {
            string str = "update EmpInfo set Emp_Name=@Emp Name,Dep_Name=@Emp Dep,Emp_Salary=@Emp Salary where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@Emp Name", emp.Emp_Name);
            cmd.Parameters.AddWithValue("@Emp Dep", emp.Dep_Name);
            cmd.Parameters.AddWithValue("@Emp Salary", emp.Emp_Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from EmpInfo where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }
}
