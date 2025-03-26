using QueueApi.Entities;

namespace QueueApi.Services
{
    public interface IQueueRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync();
        Task<Session?> GetSessionAsync(int sessionId, bool includeEntries);
        Task<IEnumerable<Entry>> GetEntriesAsync(int sessionId);
        Task<Entry?> GetEntryAsync(int sessionId, int entryId);
        Task<IEnumerable<Status>> GetStatusesAsync();
        Task<Status?> GetStatusAsync(int statusId);
        Task<bool> SessionExistsAsync(int sessionId);
        Task<bool> EntryExistsAsync(int sessionId, int entryId);
        Task<bool> StatusExistsAsync(int statusId);
        Task<bool> SaveAsync();
        Task AddSessionAsync(Session session);
        Task AddEntryAsync(int sessionId, Entry entry);
        Task AddStatusAsync(Status status);
        void DeleteSession(Session session);
        void DeleteEntry(Entry entry);
        void DeleteStatus(Status status);
    }
}
