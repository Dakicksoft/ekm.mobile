using System;
using System.Collections.Generic;
using System.Text;

namespace Ekm.Mobile.Extensions
{
  public static class DatetimeExtensions
  {
    public static bool IsWeekend(this DateTime value)
    {
      return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
    }

    /// <summary>
    /// Compute dateTime difference precisely
    /// Alex-LEWIS, 2015-08-11
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    /// <returns></returns>
    public static double GetTotalMonthDiff(this DateTime dt1, DateTime dt2)
    {
      var l = dt1 < dt2 ? dt1 : dt2;
      var r = dt1 >= dt2 ? dt1 : dt2;
      var lDfM = DateTime.DaysInMonth(l.Year, l.Month);
      var rDfM = DateTime.DaysInMonth(r.Year, r.Month);

      var dayFixOne = l.Day == r.Day
      ? 0d
      : l.Day > r.Day
      ? r.Day * 1d / rDfM - l.Day * 1d / lDfM
      : (r.Day - l.Day) * 1d / rDfM;

      return dayFixOne
      + (l.Month == r.Month ? 0 : r.Month - l.Month)
      + (l.Year == r.Year ? 0 : (r.Year - l.Year) * 12);
    }

    public static string NullDateToString(this DateTime? dt, string format = "M/d/yyyy", string nullResult = "")
    {
      if (dt.HasValue)
        return dt.Value.ToString(format);
      else
        return nullResult;
    }

    /// <summary>
    /// Returns a formatted date or emtpy string
    /// </summary>
    /// <param name="t">DateTime instance or null</param>
    /// <param name="format">datetime formatstring </param>
    /// <returns></returns>
    public static string ToString(this DateTime? t, string format)
    {
      if (t != null)
      {
        return t.Value.ToString(format);
      }

      return "";
    }

    public static string ToFriendlyDateString(this DateTime Date)
    {
      string FormattedDate = "";
      if (Date.Date == DateTime.Today)
      {
        FormattedDate = "Today";
      }
      else if (Date.Date == DateTime.Today.AddDays(-1))
      {
        FormattedDate = "Yesterday";
      }
      else if (Date.Date > DateTime.Today.AddDays(-6))
      {
        // *** Show the Day of the week
        FormattedDate = Date.ToString("dddd").ToString();
      }
      else
      {
        FormattedDate = Date.ToString("MMMM dd, yyyy");
      }

      //append the time portion to the output
      FormattedDate += " @ " + Date.ToString("t").ToLower();
      return FormattedDate;
    }

    public static DateTime? ToDateTime(this string s)
    {
      DateTime dtr;
      var tryDtr = DateTime.TryParse(s, out dtr);
      return (tryDtr) ? dtr : new DateTime?();
    }

    /// <summary>
    /// DateDiff in SQL style. 
    /// Datepart implemented: 
    ///     "year" (abbr. "yy", "yyyy"), 
    ///     "quarter" (abbr. "qq", "q"), 
    ///     "month" (abbr. "mm", "m"), 
    ///     "day" (abbr. "dd", "d"), 
    ///     "week" (abbr. "wk", "ww"), 
    ///     "hour" (abbr. "hh"), 
    ///     "minute" (abbr. "mi", "n"), 
    ///     "second" (abbr. "ss", "s"), 
    ///     "millisecond" (abbr. "ms").
    /// </summary>
    /// <param name="DatePart"></param>
    /// <param name="EndDate"></param>
    /// <returns></returns>
    public static Int64 DateDiff(this DateTime StartDate, String DatePart, DateTime EndDate)
    {
      Int64 DateDiffVal = 0;
      System.Globalization.Calendar cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
      TimeSpan ts = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
      switch (DatePart.ToLower().Trim())
      {
        #region year
        case "year":
        case "yy":
        case "yyyy":
          DateDiffVal = (Int64)(cal.GetYear(EndDate) - cal.GetYear(StartDate));
          break;
        #endregion

        #region quarter
        case "quarter":
        case "qq":
        case "q":
          DateDiffVal = (Int64)((((cal.GetYear(EndDate)
                              - cal.GetYear(StartDate)) * 4)
                              + ((cal.GetMonth(EndDate) - 1) / 3))
                              - ((cal.GetMonth(StartDate) - 1) / 3));
          break;
        #endregion

        #region month
        case "month":
        case "mm":
        case "m":
          DateDiffVal = (Int64)(((cal.GetYear(EndDate)
                              - cal.GetYear(StartDate)) * 12
                              + cal.GetMonth(EndDate))
                              - cal.GetMonth(StartDate));
          break;
        #endregion

        #region day
        case "day":
        case "d":
        case "dd":
          DateDiffVal = (Int64)ts.TotalDays;
          break;
        #endregion

        #region week
        case "week":
        case "wk":
        case "ww":
          DateDiffVal = (Int64)(ts.TotalDays / 7);
          break;
        #endregion

        #region hour
        case "hour":
        case "hh":
          DateDiffVal = (Int64)ts.TotalHours;
          break;
        #endregion

        #region minute
        case "minute":
        case "mi":
        case "n":
          DateDiffVal = (Int64)ts.TotalMinutes;
          break;
        #endregion

        #region second
        case "second":
        case "ss":
        case "s":
          DateDiffVal = (Int64)ts.TotalSeconds;
          break;
        #endregion

        #region millisecond
        case "millisecond":
        case "ms":
          DateDiffVal = (Int64)ts.TotalMilliseconds;
          break;
        #endregion

        default:
          throw new Exception(String.Format("DatePart \"{0}\" is unknown", DatePart));
      }
      return DateDiffVal;
    }

    public static bool IsWeekend(this DayOfWeek d)
    {
      return !d.IsWeekday();
    }

    public static bool IsWeekday(this DayOfWeek d)
    {
      switch (d)
      {
        case DayOfWeek.Sunday:
        case DayOfWeek.Saturday: return false;

        default: return true;
      }
    }

    public static DateTime AddWorkdays(this DateTime d, int days)
    {
      // start from a weekday
      while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
      for (int i = 0; i < days; ++i)
      {
        d = d.AddDays(1.0);
        while (d.DayOfWeek.IsWeekday()) d = d.AddDays(1.0);
      }
      return d;
    }

    // This presumes that weeks start with Monday.
    // Week 1 is the 1st week of the year with a Thursday in it.
    public static int GetIso8601WeekOfYear(this DateTime time)
    {
      // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
      // be the same week# as whatever Thursday, Friday or Saturday are,
      // and we always get those right
      DayOfWeek day = System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
      if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
      {
        time = time.AddDays(3);
      }

      // Return the week of our adjusted day
      return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

  }
}
