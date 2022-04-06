using System;

namespace PersonalWebsite.Application.Common.Services;

public interface IDateTimeService
{
    public DateTime Today { get; }
}