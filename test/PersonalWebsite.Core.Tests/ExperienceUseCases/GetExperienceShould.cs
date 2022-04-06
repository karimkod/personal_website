using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentAssertions;
using PersonalWebsite.Application.ExperienceUseCases.Query;
using PersonalWebsite.Core.Tests.Common.TestDoubles;
using PersonalWebsite.Core.Tests.ExperienceUseCases.TestDoubles;
using PersonalWebsite.Domain.Entities;
using Xunit;

namespace PersonalWebsite.Core.Tests.ExperienceUseCases;

public class GetExperienceShould
{
    private readonly List<ExperienceResponse> _expectedExperiences = new List<ExperienceResponse>()
    {
        new ExperienceResponse()
        {
            StartDate = new DateTime(2019, 01, 01),
            EndDate = new DateTime(2019, 05, 01),
            Period = new DateTime(2019, 05, 01) - new DateTime(2019, 01, 01),
            ComanyName = "Company1",
            PositionName = "Position1",
            Description = "This is a description of job 1"
        },
        new ExperienceResponse()
        {
            StartDate = new DateTime(2020, 04, 09),
            EndDate = new DateTime(2021, 05, 01),
            Period = new DateTime(2021, 05, 01) - new DateTime(2020, 04, 09),
            ComanyName = "Company2",
            PositionName = "Position2",
            Description = "This is a description of job 2"
        },
        new ExperienceResponse()
        {
            StartDate = new DateTime(2023, 04, 09),
            EndDate = new DateTime(2025, 05, 14),
            Period = new DateTime(2025, 05, 14) - new DateTime(2023, 04, 09),
            ComanyName = "Company3",
            PositionName = "Position3",
            Description = "This is a description of job 3"
        },
    };

    private readonly FakeExperienceRepository _experienceRepository;
    private readonly StubDateTimeService _dateTimeService; 
    private readonly GetExperienceHandler _getExperienceHandler;
    private readonly GetExperience _getExperience;
    
    public GetExperienceShould()
    {
        _experienceRepository = new FakeExperienceRepository();
        _dateTimeService = new StubDateTimeService();
        _getExperienceHandler = new GetExperienceHandler(_experienceRepository, _dateTimeService);
        _getExperience = new GetExperience();
    }

    [Fact]
    public void ReturnEmptyArrays_When_ThereAreNoExperiences()
    {
        var experiences = _getExperienceHandler.Handle(_getExperience);

        experiences.Should().BeEquivalentTo(new List<ExperienceResponse>());
    }

    [Fact]
    public void ReturnExperiences_When_ThereAreExperiences()
    {
        _experienceRepository.Add(ExperienceFromExperienceResponse(_expectedExperiences[0]));
        _experienceRepository.Add(ExperienceFromExperienceResponse(_expectedExperiences[1]));
        _experienceRepository.Add(ExperienceFromExperienceResponse(_expectedExperiences[2]));


        var experienceResponses = _getExperienceHandler.Handle(_getExperience);

        experienceResponses.Should().BeEquivalentTo(_expectedExperiences);
    }


    [Fact]
    public void ReturnExperienceWithRightDuration_When_StillOnGoing()
    {
        var startDate = new DateTime(2022, 06, 01);
        var supposedTodayDate = new DateTime(2022, 06, 05);

        _dateTimeService.Today = supposedTodayDate;
        
        _experienceRepository.Add(new Experience
        {
            StartDate = startDate,
            EndDate = null, // ongoing experience
            ComanyName = "Whatever",
            PositionName = "Whatever",
            Description = "Description"
        });

        List<ExperienceResponse> experienceResponses = _getExperienceHandler.Handle(_getExperience);

        experienceResponses.Should().HaveCount(1);
        experienceResponses.First().Period.Should().Be(TimeSpan.FromDays(4));
    }


    private Experience ExperienceFromExperienceResponse(ExperienceResponse experienceResponse)
    {
        return new Experience()
        {
            StartDate = experienceResponse.StartDate,
            EndDate = experienceResponse.EndDate,
            ComanyName = experienceResponse.ComanyName,
            PositionName = experienceResponse.PositionName,
            Description = experienceResponse.Description
        };
    }
}