using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface ILessonNameRepository
{
    Task AddLessonNameAsync(LessonName lessonName);
    Task RemoveLessonNameAsync(LessonName lessonName);
    Task<List<LessonName>> GetAllLessonNamesAsync();
    Task UpdateLessonNameAsync(LessonName lessonName);
    Task<LessonName?> GetLessonNameByIdAsync(int? id);
}