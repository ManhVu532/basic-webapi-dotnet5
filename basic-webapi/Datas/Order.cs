using System;
using System.Collections;
using System.Collections.Generic;

namespace basic_webapi.Datas
{
    public enum OrderState
    {
        New = 0,
        Pament = 1,
        Complete = 2,
        Cancel = -1,
    }
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? TransferAt { get; set; }
        public OrderState State { get; set; }

        public string ReceiverName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
