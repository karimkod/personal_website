using System;
using PersonalWebsite.Application.Common.Repositories;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Core.Tests.TestDoubles.ProfileUseCases;

public class FakeProfileRepository : IProfileRepository
{

    private readonly string FirstName; 
    private readonly string LastName; 
    private readonly string Bio; 
    private readonly DateTime Birthdate; 
    
    public FakeProfileRepository(string firstName, string lastName,string bio, DateTime birthdate)
    {
        FirstName = firstName;
        LastName = lastName;
        this.Bio = bio;
        Birthdate = birthdate;
    }

    public Profile GetProfile()
    {
        return new Profile()
        {
            FirstName = FirstName,
            LastName = LastName,
            Bio = Bio,
            Birthdate = Birthdate
        };
    }
}