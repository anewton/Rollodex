using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models.Identity
{
    public class SiteUser : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}
