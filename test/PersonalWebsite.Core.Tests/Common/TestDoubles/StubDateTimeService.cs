using System;
using PersonalWebsite.Application.Common.Services;

namespace PersonalWebsite.Core.Tests.Common.TestDoubles;

internal class StubDateTimeService : IDateTimeService
{
    public DateTime Today { get; set; } 
    
}