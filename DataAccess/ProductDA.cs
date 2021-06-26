using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DemoWebApi.DataAccess
{
    public class ProductDA
    {
        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<Product> getProductList()
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                SELECT * FROM PRODUCT
            ";
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            var result = new List<Product>();
            while (dr.Read())
            {
                result.Add(new Product
                {
                    productId = (int) dr["productId"],
                    name = dr["name"].ToString(),
                    category = dr["category"].ToString(),
                    price = (decimal) dr["price"]
                });
            }
            dr.Close();

            conn.Close();

            return result;
        }

        public void saveProduct(Product product)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                INSERT INTO Product
                VALUES (
                    @name, @category, @price, @regDate, @regId
                )
            ";
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = product.name;
            cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = product.category;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = product.price;
            cmd.Parameters.Add("@regDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@regId", SqlDbType.VarChar).Value = "SYSTEM";
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}