using QueueApi.Entities;

namespace QueueApi.Services
{
    public interface IQueueRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync();
        Task<Session?> GetSessionAsync(int sessionId, bool includeEntries);
        Task<IEnumerable<Entry>> GetEntriesAsync(int sessionId);
        Task<Entry?> GetEntryAsync(int sessionId, int entryId);
        Task<Status?> GetStatusAsync(int statusId);
        Task<bool> SessionExistsAsync(int sessionId);
        Task<bool> EntryExistsAsync(int sessionId, int entryId);
        Task<bool> StatusExistsAsync(int statusId);
        Task<bool> SaveAsync();
        Task AddSessionAsync(Session session);
        Task AddEntryAsync(int sessionId, Entry entry);
        void DeleteSessionAsync(Session session);
        void DeleteEntryAsync(Entry entry);
    }
}
