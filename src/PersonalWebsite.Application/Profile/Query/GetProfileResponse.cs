using System;

namespace PersonalWebsite.Application.Profile.Query;

public class GetProfileResponse
{
    public string LastName { get; set; }
    public string  FirstName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Bio { get; set; }
    
}