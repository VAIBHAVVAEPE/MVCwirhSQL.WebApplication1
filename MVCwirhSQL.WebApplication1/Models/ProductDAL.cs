using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCwirhSQL.WebApplication1.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string str = "select * from TableProduct";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    list.Add(p);

                }
                con.Close();
                return list;
            }
            
            return list;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from TableProduct where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    

                }
                con.Close();
                return p;
            }
            con.Close();
            return p;

        }
        public int Save(Product prod)
        {
            string str = "insert into TableProduct values (@Name,@Price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name",prod.Name);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
            
        }

        

        public int update(Product prod)
        {
            string str = "update TableProduct set Name=@Name,Price=@Price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@Name", prod.Name);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from TableProduct where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }
}
