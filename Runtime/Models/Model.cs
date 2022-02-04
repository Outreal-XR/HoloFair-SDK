using UnityEngine;
using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class Model: MonoBehaviour
    {

        public Provider provider;
        public View view;

        private void Awake()
        {
            if (view == null) view = GetComponent<View>();
        }

        public virtual JObject ToJObject()
        {
            var data = transform.ToJObject();
            data.Add(new JProperty("type", provider.providerType));
            return data;
        }

        public virtual void FromJObject(JObject data)
        {
            transform.localPosition = data.GetValue("localPosition").ToObject<JObject>().FromJObject();
            transform.localEulerAngles = data.GetValue("localEulerAngles").ToObject<JObject>().FromJObject();
            transform.localScale = data.GetValue("localScale").ToObject<JObject>().FromJObject();
            provider.FromJObject(data.Value<JObject>());
        } 
    }
}