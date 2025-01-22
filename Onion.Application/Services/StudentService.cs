using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddStudentAsync(student);
    }

    public async Task RemoveStudentAsync(Student student)
    {
        await _studentRepository.RemoveStudentAsync(student);
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllStudentsAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateStudentAsync(student);
    }

    public async Task<Student> GetStudentByIdAsync(int? id)
    {
        return await _studentRepository.GetStudentByIdAsync(id);
    }
}