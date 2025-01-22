using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly Context _context;

    public StudentRepository(Context context)
    {
        _context = context;
    }

    public async Task AddStudentAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveStudentAsync(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.Include(g => g.Group).ToListAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int? id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }
}