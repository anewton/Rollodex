using System.Collections.Generic;

namespace Data.Models.Domain
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}