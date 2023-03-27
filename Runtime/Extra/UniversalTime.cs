using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class UniversalTime
    {
        public static double SentTimestamp = 0;
        public static double RecievedTimestamp = 0;
        public static double ClientNow => Time.unscaledTime * 1000f;
        public static double TimeSinceLastRequest => ClientNow - RecievedTimestamp;
        public static double TotalRequestDuration => RecievedTimestamp - SentTimestamp;
        public static double ServerTime = 0;
        public static double MillisecondsNow => ServerTime + TotalRequestDuration + TimeSinceLastRequest;
        public static double SecondsNow => MillisecondsNow / 1000f;
    }   
}