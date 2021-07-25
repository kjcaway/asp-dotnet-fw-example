using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Reflection;
using DemoWebApi.Exceptions;

namespace DemoWebApi.DataAccess
{
    public class ProductDA: IProductDA
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        public Product getProduct(int productId)
        {
            var result = new List<Product>();

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT * FROM PRODUCT WHERE productId = @productId
                ";
                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = productId;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result.Add(new Product
                    {
                        productId = (int)dr["productId"],
                        name = dr["name"].ToString(),
                        category = dr["category"].ToString(),
                        price = (decimal)dr["price"]
                    });
                }
                dr.Close();

                conn.Close();

                if (result.Count != 1) throw new NotFoundProductException();
                return result[0];
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
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

        public void updateProduct(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"
                    UPDATE Product
                    SET (
                        name = @name, category = @category, price = @price
                    )
                    WHERE productId = @productId
                ";
                cmd.Parameters.Add("@productId", SqlDbType.Int).Value = product.productId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = product.name;
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = product.category;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = product.price;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}