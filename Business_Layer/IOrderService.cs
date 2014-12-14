﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Commonlayer.Views;

namespace Business_Layer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void AddOrderDetails(int orderid, int productid, int quantity);

        [OperationContract]
        void AddOrder(string username, decimal number);

        [OperationContract]
        OrderView LastOrder();

        [OperationContract]
        OrderView GetOrder(int id);

        [OperationContract]
        int GetOrderID(int productID, string username);
    }
}
