using System.Collections.Generic;

namespace SignalR.Core.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Connection> Connections { get; set; }
        
        public virtual ICollection<Group> Groups { get; set; }
    }
}
