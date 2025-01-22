using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;

    public RequestService(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task AddRequestAsync(Request request)
    {
        await _requestRepository.AddRequestAsync(request);
    }

    public async Task RemoveRequestAsync(Request request)
    {
        await _requestRepository.RemoveRequestAsync(request);
    }

    public async Task<List<Request>> GetAllRequestsAsync()
    {
        return await _requestRepository.GetAllRequestsAsync();
    }

    public async Task UpdateRequestAsync(Request request)
    {
        await _requestRepository.UpdateRequestAsync(request);
    }

    public async Task<Request> GetRequestByIdAsync(int id)
    {
        return await _requestRepository.GetRequestByIdAsync(id);
    }
}