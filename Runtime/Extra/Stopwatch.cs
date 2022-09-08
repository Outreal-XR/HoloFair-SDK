using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class Stopwatch : MonoBehaviour
    {
        [SerializeField] private double start = 0;
        
        public void StartTimer() => start = Time.realtimeSinceStartupAsDouble;
        
        /// <returns> How long the stopwatch was ticking for in seconds. </returns>
        public double StopTimer() => start - Time.realtimeSinceStartupAsDouble;
    }
}