using System.Collections.Generic;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Application.Common.Repositories;

public interface IExperienceRepository
{
    IEnumerable<Experience> GetAll();
}