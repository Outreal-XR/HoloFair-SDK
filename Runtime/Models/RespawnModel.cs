using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RespawnModel : Provider
    {
        public float radius;

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
    }
}