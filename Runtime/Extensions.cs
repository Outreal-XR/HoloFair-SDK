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
                new JProperty("position", transform.position.ToJObject()),
                new JProperty("localPosition", transform.localPosition.ToJObject()),
                new JProperty("localEulerAngles", transform.localEulerAngles.ToJObject()),
                new JProperty("localScale", transform.localScale.ToJObject())
            };
            return data;
        }

        public static void ToTransform(this JObject jobject)
        {
            Transform transform = null;
            if (jobject.ContainsKey("localPosition")) transform.localPosition = jobject.GetValue("localPosition").ToObject<JObject>().ToVector3();
            //else if (model.reportMissingKeys) Debug.Log("[Extensions] Missing locationPosition key");
            if (jobject.ContainsKey("localEulerAngles")) transform.localEulerAngles = jobject.GetValue("localEulerAngles").ToObject<JObject>().ToVector3();
            //else if (model.reportMissingKeys) Debug.Log("[Extensions] Missing localEulerAngles key");
            if (jobject.ContainsKey("localScale")) transform.localScale = jobject.GetValue("localScale").ToObject<JObject>().ToVector3();
            //else if (model.reportMissingKeys) Debug.Log("[Extensions] Missing localScale key");
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

        public static Vector3 ToVector3(this JObject jobject)
        {
            return new Vector3(jobject.GetValue("x").ToObject<float>(), jobject.GetValue("y").ToObject<float>(), jobject.GetValue("z").ToObject<float>());
        }
    }
}