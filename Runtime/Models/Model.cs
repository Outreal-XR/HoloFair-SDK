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
            if (data.ContainsKey("localPosition")) transform.localPosition = data.GetValue("localPosition").ToObject<JObject>().FromJObject();
            else Debug.Log("[Model] Missing locationPosition key");
            if (data.ContainsKey("localEulerAngles")) transform.localEulerAngles = data.GetValue("localEulerAngles").ToObject<JObject>().FromJObject();
            else Debug.Log("[Model] Missing localEulerAngles key");
            if (data.ContainsKey("localScale")) transform.localScale = data.GetValue("localScale").ToObject<JObject>().FromJObject();
            else Debug.Log("[Model] Missing localScale key");
            provider.FromJObject(data.Value<JObject>());
        } 
    }
}