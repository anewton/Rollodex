using System.Collections.Generic;

namespace Data.Models.Domain
{
    public class SiteUser : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}
