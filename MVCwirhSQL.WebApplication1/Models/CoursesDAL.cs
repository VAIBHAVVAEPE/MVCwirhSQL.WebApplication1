using MVCwirhSQL.WebApplication1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCwirhSQL.Models
{
    public class CoursesDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CoursesDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Courses>GetAllCoursess()
        {
            List<Courses> list = new List<Courses>();
            string str = "select * from info";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Courses c = new Courses();
                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.Name = dr["Name"].ToString();
                    c.Price = Convert.ToDecimal(dr["Price"]);
                    list.Add(c);

                }
                con.Close();
                return list;

            }
            else
            {
                con.Close();
                return list;
            }

        }
        public Courses GetCoursesById(int id)
        {
            Courses c = new Courses();
            string str = "select * from info where Id=@Id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.Name = dr["Name"].ToString();
                    c.Price = Convert.ToDecimal(dr["Price"]);

                }
                con.Close();
                return c;
            }
            else
            {
                con.Close();
                return c;
            }

        }
        public int Save(Courses cour)
        {
            string str = "insert into info values (@Name,@Price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name",cour.Name);
            cmd.Parameters.AddWithValue("@Price", cour.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Courses cour)
        {

            string str = "update info set Name=@Name,Price=@Price where Id=@Id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", cour.Id);
            cmd.Parameters.AddWithValue("@Name", cour.Name);
            cmd.Parameters.AddWithValue("@Price", cour.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

            
        }
        public int Delete(int id)
        {
            string str = "delete from info where Id=@Id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}
