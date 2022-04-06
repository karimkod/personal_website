using System.Collections.Generic;
using PersonalWebsite.Application.Common.Repositories;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Core.Tests.ExperienceUseCases.TestDoubles;

public class FakeExperienceRepository : IExperienceRepository
{
    private List<Experience> _experiences = new List<Experience>();

    public void Add(Experience experience)
    {
        _experiences.Add(experience);
    }

    public IEnumerable<Experience> GetAll()
    {
        return _experiences;
    }
}