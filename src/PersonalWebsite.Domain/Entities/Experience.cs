using System;

namespace PersonalWebsite.Domain.Entities;

public class Experience
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ComanyName { get; set; }
    public string PositionName { get; set; }
    public string Description { get; set; }

    public TimeSpan Period(DateTime todayDate) => (EndDate ?? todayDate) - StartDate;
}