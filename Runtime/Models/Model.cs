using UnityEngine;
using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class Model: MonoBehaviour
    {

        public Provider provider;

        public virtual JObject ToJObject()
        {
            JObject data = transform.ToJObject();
            data.Add(new JProperty("other", "provider"));
            return transform.ToJObject();
        }

        public virtual void FromJObject(JObject data)
        {
            transform.localPosition = data.GetValue("localPosition").ToObject<JObject>().FromJObject();
            transform.localEulerAngles = data.GetValue("localEulerAngles").ToObject<JObject>().FromJObject();
            transform.localScale = data.GetValue("localScale").ToObject<JObject>().FromJObject();
            provider.FromJObject(data.GetValue("other").Value<JObject>());
        } 
    }
}