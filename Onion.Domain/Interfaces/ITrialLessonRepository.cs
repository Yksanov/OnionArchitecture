using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface ITrialLessonRepository
{
    Task AddTrialLesson(TrialLesson trialLesson);
    Task<IEnumerable<TrialLesson>> GetTrialLessons();
    Task UpdateTrialLesson(TrialLesson trialLesson);
    Task RemoveTrialLesson(TrialLesson trialLesson);
    Task<TrialLesson> GetTrialLessonById(int? id);
}