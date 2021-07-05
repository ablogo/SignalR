using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Core.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
