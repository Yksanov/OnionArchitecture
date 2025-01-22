using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly Context _context;

    public RequestRepository(Context context)
    {
        _context = context;
    }

    public async Task AddRequestAsync(Request request)
    {
        _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRequestAsync(Request request)
    {
        _context.Requests.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Request>> GetAllRequestsAsync()
    {
        return await _context.Requests
            .Include(r => r.GroupType)
            .Include(r => r.LessonName)
            .ToListAsync();
    }

    public async Task UpdateRequestAsync(Request request)
    {
        _context.Requests.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Request> GetRequestByIdAsync(int id)
    {
        return await _context.Requests
            .Include(r => r.GroupType)
            .Include(r => r.LessonName)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}