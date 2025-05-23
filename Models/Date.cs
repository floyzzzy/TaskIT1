using System;

public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public class Date
{
    private DateTime _dateTime;

    public int Day => _dateTime.Day;
    public int Month => _dateTime.Month;
    public int Year => _dateTime.Year;
    public DayOfWeek DayOfWeek => (DayOfWeek)_dateTime.DayOfWeek;

    public Date(int year, int month, int day)
    {
        _dateTime = new DateTime(year, month, day);
    }

    public int DaysInMonth()
    {
        return DateTime.DaysInMonth(Year, Month);
    }

    public bool IsValidDate()
    {
        try
        {
            new DateTime(Year, Month, Day);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void AddDays(int days)
    {
        if (!IsValidDate())
            throw new ArgumentException("Invalid date.");
        _dateTime = _dateTime.AddDays(days);
    }

    public void AddMonths(int months)
    {
        if (!IsValidDate())
            throw new ArgumentException("Invalid date.");
        _dateTime = _dateTime.AddMonths(months);
    }

    public void AddYears(int years)
    {
        if (!IsValidDate())
            throw new ArgumentException("Invalid date.");
        _dateTime = _dateTime.AddYears(years);
    }

    public override string ToString()
    {
        return _dateTime.ToString("dd.MM.yyyy");
    }
}