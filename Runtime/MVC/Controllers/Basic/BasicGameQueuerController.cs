using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public abstract class BasicGameQueuerController : Controller
    {
        public override void Handle() { }
        public abstract void QueueUp(int maxQueueSize, float startDelayInSeconds, string guid, Vector3 aoi);
        public abstract void DeQueue(string guid);
    }
}