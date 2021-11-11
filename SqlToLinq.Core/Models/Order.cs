using System;
using System.Collections.Generic;

namespace SqlToLinq.Core.Models
{
    public sealed partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }

        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
    }
}
