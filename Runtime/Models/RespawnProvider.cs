using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RespawnProvider : Provider
    {
        public float radius;

        public override string ModKey => "respawn";

        public override string providerType => GetType().Name;

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "radius", radius }
            };
            return data;
        }

        public override void FromJObject(JObject data)
        {
            radius = data.GetValue("radius").Value<float>();
        }

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