using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public static class Extensions
    {
        public static JObject ToJObject(this Transform transform)
        {
            var data = new JObject
            {
                new JProperty("name", transform.name),
                new JProperty("localPosition", transform.localPosition.ToJObject()),
                new JProperty("localEulerAngles", transform.localEulerAngles.ToJObject()),
                new JProperty("localScale", transform.localScale.ToJObject())
            };
            return data;
        }

        public static JObject ToJObject(this Vector3 vector3)
        {
            var data = new JObject
            {
                { "x", vector3.x },
                { "y", vector3.y },
                { "z", vector3.z }
            };
            return data;
        }

        public static Vector3 FromJObject(this JObject jobject)
        {
            return new Vector3(jobject.GetValue("x").ToObject<float>(), jobject.GetValue("y").ToObject<float>(), jobject.GetValue("z").ToObject<float>());
        }
    }
}