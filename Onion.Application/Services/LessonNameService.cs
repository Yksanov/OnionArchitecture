using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class LessonNameService : ILessonNameService
{
    private readonly ILessonNameRepository _lessonNameRepository;

    public LessonNameService(ILessonNameRepository lessonNameRepository)
    {
        _lessonNameRepository = lessonNameRepository;
    }

    public async Task AddLessonNameAsync(LessonName lessonName)
    {
        await _lessonNameRepository.AddLessonNameAsync(lessonName);
    }

    public async Task RemoveLessonNameAsync(LessonName lessonName)
    {
        await _lessonNameRepository.RemoveLessonNameAsync(lessonName);
    }

    public async Task<List<LessonName>> GetAllLessonNamesAsync()
    {
        return await _lessonNameRepository.GetAllLessonNamesAsync();
    }

    public async Task UpdateLessonNameAsync(LessonName lessonName)
    {
        await _lessonNameRepository.UpdateLessonNameAsync(lessonName);
    }

    public async Task<LessonName?> GetLessonNameByIdAsync(int? id)
    {
        return await _lessonNameRepository.GetLessonNameByIdAsync(id);
    }
}