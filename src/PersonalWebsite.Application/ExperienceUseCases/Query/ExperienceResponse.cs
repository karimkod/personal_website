using System;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Application.ExperienceUseCases.Query;

public class ExperienceResponse
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ComanyName { get; set; }
    public string PositionName { get; set; }
    public string Description { get; set; }
    public TimeSpan Period { get; set; }

    public static ExperienceResponse FromExperience(Experience experience)
    {
        return new ExperienceResponse()
        {
            StartDate = experience.StartDate,
            EndDate = experience.EndDate,
            Description = experience.Description,
            ComanyName = experience.ComanyName,
            PositionName = experience.PositionName
        };
    }
}