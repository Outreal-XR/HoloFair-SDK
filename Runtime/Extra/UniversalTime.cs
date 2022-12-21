using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class UniversalTime
    {
        public static double SentTimestamp = 0;
        public static double RecievedTimestamp = 0;
        public static double ClientNow => UnityEngine.Time.unscaledTime;
        public static double TimeSinceLastRequest => ClientNow - RecievedTimestamp;
        public static double TotalRequestDuration => RecievedTimestamp - SentTimestamp;
        public static double ServerTime = 0;
        /// <summary>
        /// Seconds
        /// </summary>
        public static double Now => (ServerTime / 1000) + TotalRequestDuration + TimeSinceLastRequest;
    }   
}