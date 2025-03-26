using QueueApi.Entities;

namespace QueueApi.Models
{
    public class SessionWithoutEntriesDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
