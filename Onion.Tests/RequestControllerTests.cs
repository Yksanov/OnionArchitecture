using Microsoft.AspNetCore.Mvc;
using Moq;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.Controllers;
using Xunit;

namespace Onion.Tests;

public class RequestControllerTests
{
    private readonly Mock<IRequestService> _requestServiceMock;
    private readonly RequestController _controller;

    public RequestControllerTests()
    {
        _requestServiceMock = new Mock<IRequestService>();
        _controller = new RequestController(_requestServiceMock.Object);
    }

    [Fact]
    public async Task AllRequestReturnsViewWithRequests()
    {
        List<Request> requests = new List<Request>
        {
            new Request {Id = 1, FirstName = "Eldos", LastName = "Yksanov", PreferredTime = DateTime.Now},
            new Request {Id = 2, FirstName = "Tom", LastName = "Safonov", PreferredTime = DateTime.Now.AddDays(10)}
        };
        _requestServiceMock.Setup(service => service.GetAllRequestsAsync()).ReturnsAsync(requests);
        
        var result = await _controller.AllRequests();
        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(requests, viewResult.Model);
        var model = viewResult.Model as List<Request>;
        Assert.Equal(requests.Count, model.Count);
    }
}