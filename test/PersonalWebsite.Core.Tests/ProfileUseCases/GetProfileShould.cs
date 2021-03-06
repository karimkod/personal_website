using System;
using FluentAssertions;
using PersonalWebsite.Application.Common.Repositories;
using PersonalWebsite.Application.ProfileUseCases.Query;
using PersonalWebsite.Core.Tests.ProfileUseCases.TestDoubles;
using Xunit;

namespace PersonalWebsite.Core.Tests.ProfileUseCases;

public class GetProfileShould
{
    private const string FIRST_NAME = "firstName";
    private const string LAST_NAME = "lastName";
    private static readonly DateTime Birthdate = new DateTime(1995, 11, 25);
    private const string BIO = "This is my bio";
    private readonly GetProfileResponse _expectedResponse = 
         new GetProfileResponse()
        {
            FirstName = FIRST_NAME,
            LastName = LAST_NAME, 
            Birthdate = Birthdate,
            Bio = BIO
        };

    private readonly IProfileRepository _profileRepository; 
    
    public GetProfileShould()
    {
        _profileRepository = new FakeProfileRepository(FIRST_NAME, LAST_NAME, BIO, Birthdate);
    }

    [Fact]
    public void ReturnExpectedProfile()
    {
        var getProfileCommand = new GetProfile();
        var getProfileHandler = new GetProfileHandler(_profileRepository);

        GetProfileResponse response = getProfileHandler.Handle(getProfileCommand);

        AssertGetProfileEqualsExpected(response, _expectedResponse);
    }


    private void AssertGetProfileEqualsExpected(GetProfileResponse expected, GetProfileResponse actual)
    {
        actual.FirstName.Should().Be(expected.FirstName);
        actual.LastName.Should().Be(expected.LastName);
        actual.Bio.Should().Be(expected.Bio);
        actual.Birthdate.Should().Be(expected.Birthdate);
    }
        
}