using System;

namespace PersonalWebsite.Application.Profile.Query;

public class GetProfileHandler
{
    public GetProfileResponse Handle(GetProfile getProfileCommand)
    {
        return new GetProfileResponse()
        {
            FirstName = "firstName",
            LastName = "lastName",
            Birthdate = new DateTime(1995, 11, 25), 
            Bio = "This is my bio"
        };
    }
}