using System;
using PersonalWebsite.Application.Profile.Query;
using FluentAssertions;
using PersonalWebsite.Application.Common.Repositories;
using Xunit;

namespace PersonalWebsite.Core.Tests.Profile;

public class GetProfileShould
{
    private const string FIRST_NAME = "firstName";
    private const string LAST_NAME = "lastName";
    private static readonly DateTime BIRTHDATE = new DateTime(1995, 11, 25);
    private const string BIO = "This is my bio";
    private readonly GetProfileResponse EXPECTED_RESPONSE = 
         new GetProfileResponse()
        {
            FirstName = FIRST_NAME,
            LastName = LAST_NAME, 
            Birthdate = BIRTHDATE,
            Bio = BIO
        };

    private readonly IProfileRepository _profileRepository; 
    
    public GetProfileShould()
    {
        _profileRepository = new FakeProfileRepository();
    }

    [Fact]
    public void GetProfile_Should_ReturnExpectedProfile()
    {
        var getProfileCommand = new GetProfile();
        var getProfileHandler = new GetProfileHandler(_profileRepository);

        GetProfileResponse response = getProfileHandler.Handle(getProfileCommand);

        response.Should().Be(EXPECTED_RESPONSE);
    }
        
}

public class FakeProfileRepository : IProfileRepository
{

    private readonly string FirstName; 
    private readonly string LastName; 
    private readonly string Bio; 
    private readonly string Birthdate; 
    
    public FakeProfileRepository(string firstName, string lastName, string Bio, DateTime birthdate, string bio, string birthdate1)
    {
        FirstName = firstName;
        LastName = lastName;
        this.Bio = bio;
        Birthdate = birthdate1;
    }

    public Domain.Entities.Profile GetProfile()
    {
        return new Profile()
        {
            FirstName = 
        }
    }
}