using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class RequestController : Controller
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    public async Task<IActionResult> AllRequests()
    {
        return View(await _requestService.GetAllRequestsAsync());
    }

    [HttpGet]
    public async Task<IActionResult> CreateRequest()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(RequestViewModel model)
    {
        if (ModelState.IsValid)
        {
            Request request = new Request()
            {   
                FirstName = model.FirstName,
                LastName = model.LastName,
                PreferredTime = model.PreferredTime,
                Phone = model.PhoneNumber,
                GroupTypeId = model.GroupTypeId,
                LessonNameId = model.LessonNameId
            };
            await _requestService.AddRequestAsync(request);
            return RedirectToAction("AllRequests");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> RemoveRequest()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveRequest(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Request request = await _requestService.GetRequestByIdAsync(id.Value);
        if (request == null)
        {
            return NotFound();
        }
        await _requestService.RemoveRequestAsync(request);
        return RedirectToAction("AllRequests");
    }
}