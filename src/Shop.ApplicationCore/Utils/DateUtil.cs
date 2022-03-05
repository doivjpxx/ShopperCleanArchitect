namespace Shop.ApplicationCore.Utils;

public class DateUtil
{
    public static DateTime GetCurrentDate()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);
    }
}
