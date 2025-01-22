using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IRequestRepository
{
    Task AddRequestAsync(Request request);
    Task RemoveRequestAsync(Request request);
    Task<List<Request>> GetAllRequestsAsync();
    Task UpdateRequestAsync(Request request);
    Task<Request> GetRequestByIdAsync(int id);
}