using Microsoft.AspNetCore.Mvc;
using Moq;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.Controllers;
using OnionArhitectura.ViewModels;
using Xunit;

namespace Onion.Tests;

public class TeacherControllerTests
{
    private readonly Mock<ITeacherService> _mockTeacherService;
    private readonly TeacherController _controller;

    public TeacherControllerTests()
    {
        _mockTeacherService = new Mock<ITeacherService>();
        _controller = new TeacherController(_mockTeacherService.Object);
    }

    [Fact]
    public async Task AllTeacherReturnsViewWithTeachersResult()
    {
        List<Teacher> teachers = new List<Teacher>
        {

            new Teacher
            {
                Id = 1, FirstName = "Oleg", LastName = "Mayami", LessonNameId = 1,
                LessonName = new LessonName { Id = 1, Name = "Math" }, BranchId = 1,
                Branch = new Branch { Id = 1, Name = "Center city", Location = "New street" }, Groups = null
            },
            new Teacher
            {
                Id = 2, FirstName = "Ivan", LastName = "Pavlov", LessonNameId = 2,
                LessonName = new LessonName { Id = 2, Name = "Bio" }, BranchId = 2,
                Branch = new Branch { Id = 2, Name = "North city", Location = "New street" }, Groups = null
            },
        };
        _mockTeacherService.Setup(service => service.GetTeachersAsync()).ReturnsAsync(teachers);
        
        var result = await _controller.AllTeachers();
        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(teachers, viewResult.Model);
        var model = viewResult.Model as List<Teacher>;
        Assert.Equal(teachers.Count, model.Count);
    }

    [Fact]
    public async Task AddTeacherValidModelRedirectsToAllTeachersResult()
    {
        TeacherViewModel validModel = new TeacherViewModel
        {
            FirstName = "Oleg",
            LastName = "Mayami",
            BranchId = 1,
            LessonNameId = 2
        };

        var result = await _controller.AddTeacher(validModel);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllTeachers", redirectResult.ActionName);
    }

    [Fact]
    public async Task DeleteTeacherValidIdReturnsViewResult()
    {
        int teacherId = 1;
        Teacher teacher = new Teacher
        {
            Id = teacherId,
            FirstName = "John",
            LastName = "Oliver",
            BranchId = 1,
            LessonNameId = 2
        };

        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(teacherId)).ReturnsAsync(teacher);
        
        var result = await _controller.DeleteTeacher(teacherId);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(teacher, viewResult.Model);
    }

    [Fact]
    public async Task DeleteTeacherInvalidTeacherIdReturnsNotFoundResult()
    {
        var result = await _controller.DeleteTeacher(null);
        
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteTeacherNonExistentTeacherReturnsNotFoundResult()
    {
        int teacherId = 1;
        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(teacherId)).ReturnsAsync((Teacher)null);

        var result = await _controller.DeleteTeacher(teacherId);

        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteTeacherConfirmedValidIdRedirectsToAllTeachersResult()
    {
        int teacherId = 1;
        Teacher teacher = new Teacher
        {
            Id = teacherId,
            FirstName = "Ivan",
            LastName = "Ivanov",
            BranchId = 1,
            LessonNameId = 4
        };
        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(teacherId)).ReturnsAsync(teacher);

        var result = await _controller.DeleteTeacher(teacherId);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllTeachers", redirectResult.ActionName);
        _mockTeacherService.Verify(service => service.DeleteTeacherAsync(teacher), Times.Once);
    }

    [Fact]
    public async Task EditTeacherValidIdReturnsViewWithModelResult()
    {
        int teacherId = 3;
        Teacher teacher = new Teacher
        {
            Id = teacherId,
            FirstName = "Ivan",
            LastName = "Ivanov",
            BranchId = 1,
            LessonNameId = 2 
        };
        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(teacherId)).ReturnsAsync(teacher);

        var result = await _controller.EditTeacher(teacherId);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        var model = Assert.IsType<EditTeacherViewModel>(viewResult.Model);
        Assert.Equal(teacher.Id, model.Id);
        Assert.Equal(teacher.FirstName, model.FirstName);
        Assert.Equal(teacher.LastName, model.LastName);
        Assert.Equal(teacher.BranchId, model.BranchId);
        Assert.Equal(teacher.LessonNameId, model.LessonNameId);
    }

    [Fact]
    public async Task EditTeacherInvalidIdReturnsNotFoundResult()
    {
        int? teacherId = null;
        
        var result = await _controller.EditTeacher(teacherId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task EditTeacherNonExistentTeacherReturnsNotFoundResult()
    {
        int teacherId = 4;
        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(teacherId)).ReturnsAsync((Teacher)null);

        var result = await _controller.EditTeacher(teacherId);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task EditTeacherPostValidRedirectsToAllTeachersResult()
    {
        EditTeacherViewModel model = new EditTeacherViewModel
        {
            Id = 1,
            FirstName = "origin FirstName",
            LastName = "origin LastName",
            BranchId = 1,
            LessonNameId = 3
        };

        Teacher teacher = new Teacher
        {
            Id = model.Id,
            FirstName = "origin FirstName",
            LastName = model.LastName,
            BranchId = 1,
            LessonNameId = model.LessonNameId,
        };

        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(model.Id)).ReturnsAsync(teacher);
        
        var result = await _controller.EditTeacher(model);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllTeachers", redirectResult.ActionName);
    }

    [Fact]
    public async Task EditTeacherPostInvalidModelReturnsViewWithModelResult()
    {
        EditTeacherViewModel model = new EditTeacherViewModel
        {
            Id = 1,
            FirstName = "",
            LastName = "",
            BranchId = 2,
            LessonNameId = 4
        };
        _controller.ModelState.AddModelError("FirstName", "Поле обязательно к заполнению");

        var result = await _controller.EditTeacher(model);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(model, viewResult.Model);
    }

    [Fact]
    public async Task EditTeacherPostNonExistentTeacherReturnsNotFoundResult()
    {
        EditTeacherViewModel model = new EditTeacherViewModel
        {
            Id = 1,
            FirstName = "Updated FirstName",
            LastName = "Updated LastName",
            BranchId = 4,
            LessonNameId = 3
        };

        _mockTeacherService.Setup(service => service.GetTeacherByIdAsync(model.Id)).ReturnsAsync((Teacher)null);

        var result = await _controller.EditTeacher(model);
        Assert.IsType<NotFoundResult>(result);
    }
}