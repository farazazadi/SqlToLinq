using System.Collections.Generic;

namespace SqlToLinq.Core.Models
{
    public sealed partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; private set; }
    }
}
