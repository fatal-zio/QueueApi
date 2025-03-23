using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueueApi.Entities
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<Entry> Entries { get; set; } = [];
    }
}
