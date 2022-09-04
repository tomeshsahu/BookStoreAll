using BusinessLayer.Interface;
using DatabaseLayer.OrdersModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public string AddOrder(int UserId, OrderPostModel orderPostModel)
        {
            try
            {
                return this.orderRL.AddOrder(UserId, orderPostModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewOrder> GetAllOrder(int userId)
        {
            try
            {
                return this.orderRL.GetAllOrder(userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
