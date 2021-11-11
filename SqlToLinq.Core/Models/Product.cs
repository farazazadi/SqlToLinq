using System.Collections.Generic;

namespace SqlToLinq.Core.Models
{
    public sealed partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal Price { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
        public ICollection<Stock> Stocks { get; private set; }
    }
}
