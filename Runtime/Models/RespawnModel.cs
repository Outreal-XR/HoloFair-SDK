using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RespawnModel : MonoBehaviour, IProvider
    {
        public float radius;

        public JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "radius", radius }
            };
            return data;
        }

        public void FromJObject(JObject data)
        {
            radius = data.GetValue("radius").Value<float>();
        }
    }
}