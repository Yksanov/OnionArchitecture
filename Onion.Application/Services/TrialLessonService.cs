using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class TrialLessonService : ITrialLessonService
{
    private readonly ITrialLessonRepository _repository;

    public TrialLessonService(ITrialLessonRepository repository)
    {
        _repository = repository;
    }

    public async Task AddTrialLesson(TrialLesson trialLesson)
    {
        await _repository.AddTrialLesson(trialLesson);
    }

    public async Task<IEnumerable<TrialLesson>> GetTrialLessons()
    {
        return await _repository.GetTrialLessons();
    }

    public async Task UpdateTrialLesson(TrialLesson trialLesson)
    {
        await _repository.UpdateTrialLesson(trialLesson);
    }

    public async Task RemoveTrialLesson(TrialLesson trialLesson)
    {
        await _repository.RemoveTrialLesson(trialLesson);
    }

    public async Task<TrialLesson> GetTrialLessonById(int? id)
    {
        return await _repository.GetTrialLessonById(id);
    }
}