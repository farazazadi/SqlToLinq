using System.Collections.Generic;

namespace SqlToLinq.Core.Models
{
    public sealed partial class Staff
    {
        public Staff()
        {
            InverseManager = new HashSet<Staff>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public Staff Manager { get; set; }
        public Store Store { get; set; }
        public ICollection<Staff> InverseManager { get; private set; }
        public ICollection<Order> Orders { get; private set; }
    }
}
