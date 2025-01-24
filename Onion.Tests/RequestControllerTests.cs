using Microsoft.AspNetCore.Mvc;
using Moq;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.Controllers;
using OnionArhitectura.ViewModels;
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

    [Fact]
    public async Task CreateRequestReturnsViewWithRequestToAllRequests()
    {
        RequestViewModel validModel = new RequestViewModel()
        {
            FirstName = "Eldos",
            LastName = "Yksanov",
            PhoneNumber = "123456789",
            GroupTypeId = 1,
            LessonNameId = 1,
            PreferredTime = DateTime.Now,
        };
        
        var result = await _controller.CreateRequest(validModel);
        
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllRequests", redirectResult.ActionName);
    }

    [Fact]
    public async Task CreateRequestInValidModelReturnsViewWithModel()
    {
        _controller.ModelState.AddModelError("FirstName", "Необходимо заполнить это поле");
        var invalidModel = new RequestViewModel();

        var result = await _controller.CreateRequest(invalidModel);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(invalidModel, viewResult.Model);
    }

    [Fact]
    public async Task RemoveRequestValidIdRedirectsToAllRequests()
    {
        var requestId = 1;
        var mockRequest = new Request { Id = requestId, FirstName = "Daniel", LastName = "Tom" };
        _requestServiceMock.Setup(service => service.GetRequestByIdAsync(requestId)).ReturnsAsync(mockRequest);

        var result = await _controller.RemoveRequest(requestId);
        
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllRequests", redirectResult.ActionName);
        _requestServiceMock.Verify(service => service.RemoveRequestAsync(mockRequest), Times.Once);
    }

    [Fact]
    public async Task RemoveRequestInValidIdReturnsNotFound()
    {
        var result = await _controller.RemoveRequest(null);
        
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task RemoveRequestNonExistentRequestReturnsNotFound()
    {
        var requestId = 1;
        _requestServiceMock.Setup(service => service.GetRequestByIdAsync(requestId)).ReturnsAsync((Request)null);
        
        var result = await _controller.RemoveRequest(requestId);
        
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }
}