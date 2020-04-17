using Data.Models.Contacts;
using Data.Models.Identity;

namespace Data.Models
{
    public class UserContact : UserContact<int>
    {
        public virtual SiteUser User { get; set; }
        public virtual Contact Contact { get; set; }
    }

    public class UserContact<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual TKey ContactId { get; set; }
    }
}