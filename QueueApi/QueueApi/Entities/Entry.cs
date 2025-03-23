using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QueueApi.Entities
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int Order { get; set; } 
    }
}
