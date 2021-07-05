using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SignalR.Core.Entities
{
    public class Connection : BaseEntity
    {
        public string ConnectionId { get; set; }
        
        public string UserAgent { get; set; }
        
        public bool Connected { get; set; }

    }
}
