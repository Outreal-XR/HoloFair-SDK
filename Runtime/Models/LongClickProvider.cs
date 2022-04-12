using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LongClickProvider : Provider
    {
        public override string ModKey => "longClick";

        public float holdDuration = 0.5f;

        public UnityEvent OnLongClick;
        
        public override JObject ToJObject() => new JObject();
        public override void FromJObject(JObject data) { }
        public override string providerType => GetType().ToString();
    }
}