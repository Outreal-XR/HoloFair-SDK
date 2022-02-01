using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public static class Extensions
    {
        public static JObject ToJObject(this Transform transform)
        {
            JObject data = new JObject
            {
                "localPosition", new JObject {
                    transform.localPosition.ToJObject()
                },
                "localEulerAngles", new JObject {
                    transform.localEulerAngles.ToJObject()
                },
                "localScale", new JObject {
                    transform.localScale.ToJObject()
                }
            };
            return data;
        }

        public static JObject ToJObject(this Vector3 vector3)
        {
            JObject data = new JObject
            {
                { "x", JToken.FromObject(vector3.x) },
                { "y", JToken.FromObject(vector3.y) },
                { "z", JToken.FromObject(vector3.z) }
            };
            return data;
        }

        public static Vector3 FromJObject(this JObject jobject)
        {
            return new Vector3(jobject.GetValue("x").ToObject<float>(), jobject.GetValue("y").ToObject<float>(), jobject.GetValue("z").ToObject<float>());
        }
    }
}