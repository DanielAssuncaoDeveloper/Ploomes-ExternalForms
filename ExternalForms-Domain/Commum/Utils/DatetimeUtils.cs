namespace ExternalForms_Domain.Commum.Utils
{
    public static class DatetimeUtils
    {
        public static DateTime GetDateTime() =>
            DateTime.UtcNow.AddHours(3);
    }
}
