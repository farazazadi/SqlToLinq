using System.Collections.Generic;

namespace SqlToLinq.Core.Models
{
    public sealed partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Stocks = new HashSet<Stock>();
            Staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Order> Orders { get; private set; }
        public ICollection<Stock> Stocks { get; private set; }
        public ICollection<Staff> Staff { get; private set; }
    }
}
