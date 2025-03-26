using QueueApi.Entities;

namespace QueueApi.Models
{
    public class SessionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public int NumberOfEntries => Entries.Count;
        public ICollection<Entry> Entries { get; set; } = [];
    }
}
