namespace outrealxr.holomod
{
    public abstract class UniversalTimeModel
    {
        public static double Now => ClientNow + ServerTimeDifference;
        public static double ServerTimeDifference { get; set; } = 0;
        public static double ClientNow => System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}