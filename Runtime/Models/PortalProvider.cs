using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class PortalProvider : Provider
    {
        public string sceneName;

        public override string ModKey => "portal";
        
        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "sceneName", sceneName }
            };
            return data;
        }

        public override void FromJObject(JObject data)
        {
            sceneName = data.GetValue("sceneName").Value<string>();
        }

        bool isDirty = true;

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override bool IsDirty()
        {
            return isDirty;
        }
    }
}