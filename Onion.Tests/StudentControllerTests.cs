using Microsoft.AspNetCore.Mvc;
using Moq;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.Controllers;
using OnionArhitectura.ViewModels;
using Xunit;

namespace Onion.Tests;

public class StudentControllerTests
{
    private readonly Mock<IStudentService> _mockStudentService;
    private readonly StudentController _controller;

    public StudentControllerTests()
    {
        _mockStudentService = new Mock<IStudentService>();
        _controller = new StudentController(_mockStudentService.Object);
    }

    [Fact]
    public async Task AllStudentsReturnsViewWithStudents()
    {
        List<Student> students = new List<Student>
        {
            new Student(){Id = 1, FirstName = "John", LastName = "Doe", Phone = "123456789", Email = "john.doe@gmail.com", Description = "10 %", StudentType = true, GroupId = 5},
            new Student(){Id = 1, FirstName = "Jack", LastName = "Tom", Phone = "987123456", Email = "jack.tom@gmail.com", Description = "5 %", StudentType = true, GroupId = 4}
        };
        _mockStudentService.Setup(service => service.GetAllStudentsAsync()).ReturnsAsync(students);
        
        var result = await _controller.AllStudents();
        var viewResult = Assert.IsType <ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(students, viewResult.Model);
        var model = viewResult.Model as List<Student>;
        Assert.Equal(students.Count, model.Count);
    }

    [Fact]
    public async Task CreateStudentValidModelRedirectsToAllStudents()
    {
        StudentViewModel validModel = new StudentViewModel
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "123456789",
            GroupId = 5,
            Description = "10 %",
        };
        
        var result = await _controller.CreateStudent(validModel);
        
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectToActionResult);
        Assert.Equal("AllStudents", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task CreateStudentInvalidModelReturnsViewWithModel()
    {
        _controller.ModelState.AddModelError("FirstName", "Необходимо заполнить это поле");
        var invalidModel = new StudentViewModel();
        
        var result = await _controller.CreateStudent(invalidModel);
        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(invalidModel, viewResult.Model);
    }

    [Fact]
    public async Task RemoveStudentValidIdRedirectsToAllStudents()
    {
        var studentId = 1;
        var mockStudent = new Student
        {
            Id = studentId,
            FirstName = "John",
            LastName = "Doe",
            Phone = "123456789",
            Email = "john.doe@gmail.com",
            Description = "10 %",
            StudentType = true,
            GroupId = 4
        };
        _mockStudentService.Setup(service => service.GetStudentByIdAsync(studentId)).ReturnsAsync(mockStudent);

        var result = await _controller.RemoveStudent(studentId);
        
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectResult);
        Assert.Equal("AllStudents", redirectResult.ActionName);
        _mockStudentService.Verify(service => service.RemoveStudentAsync(mockStudent), Times.Once);
    }

    [Fact]
    public async Task RemoveStudentInvalidStudentIdReturnsNotFound()
    {
        var result = await _controller.RemoveStudent(0);
        
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task RemoveStudentNonExistentIdReturnsNotFound()
    {
        var studentId = 1;
        _mockStudentService.Setup(service => service.GetStudentByIdAsync(studentId)).ReturnsAsync((Student)null);
        
        var result = await _controller.RemoveStudent(studentId);
        
        Assert.NotNull(result);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task EditStudentValidIdReturnsViewWithStudent()
    {
        int studentId = 4;
        Student student = new Student
        {
            Id = studentId,
            FirstName = "John",
            LastName = "Doe",
            Phone = "123456789",
            Email = "john.doe@gmail.com",
            Description = "10 %",
            StudentType = true,
            GroupId = 5
        };
        _mockStudentService.Setup(service => service.GetStudentByIdAsync(studentId)).ReturnsAsync(student);
        
        var result = await _controller.EditStudent(studentId);
        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        var model = Assert.IsType<StudentViewModel>(viewResult.Model);
        Assert.Equal(student.FirstName, model.FirstName);
        Assert.Equal(student.LastName, model.LastName);
    }

    [Fact]
    public async Task EditStudentInvalidIdReturnsNotFound()
    {
        int studentId = 4;
        var result = await _controller.EditStudent(studentId);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task EditStudentPostValidModelRedirectsToAllStudentsResult()
    {
        int studentId = 5;
        StudentViewModel model = new StudentViewModel
        {
            FirstName = "John",
            LastName = "Doe",
            Description = "100 %",
            Phone = "987123456",
            GroupId = 5
        };

        Student student = new Student
        {
            Id = studentId,
            FirstName = "John",
            LastName = "Doe2",
            Phone = model.Phone,
            Description = "new Student",
            GroupId = model.GroupId,
        };
        
        _mockStudentService.Setup(service => service.GetStudentByIdAsync(studentId)).ReturnsAsync(student);

        var result = await _controller.EditStudent(studentId);
        var redirectToResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(redirectToResult);
        Assert.Equal("AllStudents", redirectToResult.ActionName);
    }

    [Fact]
    public async Task EditStudentPostInvalidModelReturnsViewWithModelResult()
    {
        int studentId = 5;
        StudentViewModel model = new StudentViewModel
        {
            FirstName = "",
            LastName = "Update Last Name",
            Phone = "987123456",
            Description = "Updated Description",
            GroupId = 3
        };
        _controller.ModelState.AddModelError("FirstName","Поле обязательно к заполнению");
        
        var result = await _controller.EditStudent(model, studentId);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult);
        Assert.Equal(model, viewResult.Model);
    }

    [Fact]
    public async Task EditStudentGetNonExistentStudentReturnsNotFoundResult()
    {
        int studentId = 4;
        StudentViewModel model = new StudentViewModel()
        {
            FirstName = "New First Name",
            LastName = "New Last Name",
            Phone = "987123456",
            Description = "New Description",
            GroupId = 5
        };
        _mockStudentService.Setup(service => service.GetStudentByIdAsync(studentId)).ReturnsAsync((Student)null);

        var result = await _controller.EditStudent(studentId);
        Assert.IsType<NotFoundResult>(result);
    }
}