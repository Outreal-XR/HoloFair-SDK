using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BasicTalkZoneController : BasicStringController
    {
        public abstract void SetRoomName(string val);
        public abstract void Join();
        public abstract void Leave();
    }
}