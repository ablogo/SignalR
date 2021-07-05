using System.ComponentModel.DataAnnotations;

namespace SignalR.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
