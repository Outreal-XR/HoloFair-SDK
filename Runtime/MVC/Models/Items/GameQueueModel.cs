using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class GameQueueModel : Model
    {
        public override string type => "game queue";

        public int maxQueueSize;
        public float startDelayInSeconds;
        public Vector3 areaOfInterest;
    }
}