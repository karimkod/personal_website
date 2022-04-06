using System.Collections.Generic;
using System.Linq;
using PersonalWebsite.Application.Common.Repositories;
using PersonalWebsite.Application.Common.Services;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Application.ExperienceUseCases.Query;

public class GetExperienceHandler
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly IDateTimeService _dateTimeService;

    public GetExperienceHandler(IExperienceRepository experienceRepository, IDateTimeService dateTimeService)
    {
        _experienceRepository = experienceRepository;
        _dateTimeService = dateTimeService;
    }

    public List<ExperienceResponse> Handle(GetExperience getExperienceQuery)
    {
        var experiences = _experienceRepository.GetAll();
        return experiences.Select(ExperienceResponseFrom).ToList();
    }

    private ExperienceResponse ExperienceResponseFrom(Experience e)
    {
        var experienceResponse = ExperienceResponse.FromExperience(e);
        experienceResponse.Period = e.Period(_dateTimeService.Today);
        return experienceResponse;
    }
}