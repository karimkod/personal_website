using System;
using PersonalWebsite.Application.Common.Repositories;
using PersonalWebsite.Domain.Entities;

namespace PersonalWebsite.Core.Tests.ProfileUseCases.TestDoubles;

public class FakeProfileRepository : IProfileRepository
{

    private readonly string _firstName; 
    private readonly string _lastName; 
    private readonly string _bio; 
    private readonly DateTime _birthdate; 
    
    public FakeProfileRepository(string firstName, string lastName,string bio, DateTime birthdate)
    {
        _firstName = firstName;
        _lastName = lastName;
        this._bio = bio;
        _birthdate = birthdate;
    }

    public Profile GetProfile()
    {
        return new Profile()
        {
            FirstName = _firstName,
            LastName = _lastName,
            Bio = _bio,
            Birthdate = _birthdate
        };
    }
}