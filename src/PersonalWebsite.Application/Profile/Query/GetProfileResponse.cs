using System;

namespace PersonalWebsite.Application.Profile.Query;

public class GetProfileResponse : IEquatable<GetProfileResponse>
{

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Bio { get; set; }
    
    public bool Equals(GetProfileResponse? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return LastName == other.LastName && FirstName == other.FirstName && Birthdate.Equals(other.Birthdate) &&
               Bio == other.Bio;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GetProfileResponse) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LastName, FirstName, Birthdate, Bio);
    }

    public static bool operator ==(GetProfileResponse? left, GetProfileResponse? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(GetProfileResponse? left, GetProfileResponse? right)
    {
        return !Equals(left, right);
    }
}