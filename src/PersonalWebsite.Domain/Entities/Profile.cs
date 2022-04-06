using System;

namespace PersonalWebsite.Domain.Entities;

public class Profile
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public DateTime Birthdate { get; set; }
}