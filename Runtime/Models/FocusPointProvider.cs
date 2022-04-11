using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class FocusPointProvider : Provider
    {
        public Transform focusPoint;
        
        public override string ModKey => "focusPoint";
        public override void SetIsDirty(bool val) => isDirty = val;

        public override bool IsDirty() => isDirty;

        public override JObject ToJObject() => new JObject();

        public override void FromJObject(JObject data) { }

        public override string providerType => GetType().Name;

    }
}