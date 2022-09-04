using DatabaseLayer.OrdersModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class OrderRL : IOrderRL
    {
        private readonly string connetionString;
        public OrderRL(IConfiguration configuration)
        {
            connetionString = configuration.GetConnectionString("StoreBook");
        }
        public string AddOrder(int UserId, OrderPostModel orderPostModel)
        {
            SqlConnection connection = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@BookId",orderPostModel.BookId);
                cmd.Parameters.AddWithValue("@OrderBookQuantity", orderPostModel.Quantity);
                cmd.Parameters.AddWithValue("@AddressId",orderPostModel.AddressId);

                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return "Added";
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewOrder> GetAllOrder(int userId)
        {
            SqlConnection connection=new SqlConnection(connetionString);
            List<ViewOrder> order = new List<ViewOrder>();
            try
            {
                SqlCommand cmd = new SqlCommand("spGetOrders", connection);
                cmd.CommandType= CommandType.StoredProcedure;   
                cmd.Parameters.AddWithValue("@UserId", userId);

                ViewOrder orderModel = new ViewOrder();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();             
                    while (reader.Read())
                    {           
                        orderModel.OrdersId = Convert.ToInt32(reader["OrderId"]);
                       orderModel.UserId = Convert.ToInt32(reader["UserId"]);
                       orderModel.BookId = Convert.ToInt32(reader["BookId"]);
                        orderModel.AddressId = Convert.ToInt32(reader["AddressId"]);
                        orderModel.TotalPrice = Convert.ToInt32(reader["TotalPrice"]);
                        orderModel.Quantity = Convert.ToInt32(reader["OrderBookQuantity"]);
                        orderModel.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                        orderModel.BookName = reader["BookName"].ToString();
                        orderModel.AuthorName = reader["AuthorName"].ToString();
                        orderModel.BookImage = reader["BookImage"].ToString();

                        order.Add(orderModel);
                    }
                    connection.Close();

                    if (order.Count > 0)
                    {
                        return order;
                    }
                    else
                    {
                        return null;
                    }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
