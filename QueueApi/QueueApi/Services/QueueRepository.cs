using Microsoft.EntityFrameworkCore;
using QueueApi.DbContexts;
using QueueApi.Entities;

namespace QueueApi.Services
{
    public class QueueRepository(QueueContext context) : IQueueRepository
    {
        private readonly QueueContext _context =
            context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddEntryAsync(int sessionId, Entry entry)
        {
            var session = await GetSessionAsync(sessionId, false);

            session?.Entries.Add(entry);
        }

        public async Task AddSessionAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
        }

        public async Task AddStatusAsync(Status status)
        {
            await _context.Statuses.AddAsync(status);
        }

        public void DeleteEntry(Entry entry)
        {
            _context.Entries.Remove(entry);
        }

        public void DeleteSession(Session session)
        {
            _context.Sessions.Remove(session);
        }

        public void DeleteStatus(Status status)
        {
            _context.Statuses.Remove(status);
        }

        public Task<bool> EntryExistsAsync(int sessionId, int entryId)
        {
            return _context.Entries.AnyAsync(e => e.Id == entryId && e.SessionId == sessionId);
        }

        public async Task<IEnumerable<Entry>> GetEntriesAsync(int sessionId)
        {
            return await _context.Entries.Where(e => e.SessionId == sessionId).ToListAsync();
        }

        public async Task<Entry?> GetEntryAsync(int sessionId, int entryId)
        {
            return await _context.Entries.FirstOrDefaultAsync(e => e.Id == entryId && e.SessionId == sessionId);
        }

        public Task<Session?> GetSessionAsync(int sessionId, bool includeEntries)
        {
            return includeEntries ? _context.Sessions.Include(s => s.Entries).FirstOrDefaultAsync(s => s.Id == sessionId) :
               _context.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId);
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<Status?> GetStatusAsync(int statusId)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.Id == statusId);
        }

        public async Task<IEnumerable<Status>> GetStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> SessionExistsAsync(int sessionId)
        {
            return await _context.Sessions.AnyAsync(s => s.Id == sessionId);
        }

        public async Task<bool> StatusExistsAsync(int statusId)
        {
            return await _context.Statuses.AnyAsync(s => s.Id == statusId);
        }
    }
}
