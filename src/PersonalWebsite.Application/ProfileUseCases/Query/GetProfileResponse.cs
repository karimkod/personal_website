using System;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Application.ProfileUseCases.Query;

public class GetProfileResponse
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Bio { get; set; }

    public static GetProfileResponse FromProfile(Profile profile)
    {
        return new GetProfileResponse()
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Bio = profile.Bio,
            Birthdate = profile.Birthdate
        };
    }
}