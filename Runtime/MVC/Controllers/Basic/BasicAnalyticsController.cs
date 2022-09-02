using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BasicAnalyticsController : Controller
    {
        public abstract string UuId { get; }
        public abstract string RoomName { get; }
        
        public override void Handle() {
            
        }
    }
}