using System;
using PersonalWebsite.Application.Profile.Query;
using FluentAssertions;
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
    
    [Fact]
    public void GetProfile()
    {
        
        var getProfileCommand = new GetProfile();
        var getProfileHandler = new GetProfileHandler();

        GetProfileResponse response = getProfileHandler.Handle(getProfileCommand);

        response.Should().Be(EXPECTED_RESPONSE);
    }
        
}