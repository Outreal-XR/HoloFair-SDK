using UnityEngine;
using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class Model: MonoBehaviour
    {

        [Tooltip("Addressable Path to a GameObject (Optional)")]
        public string Addressable;
        public Provider provider;
        public View view;
        public bool reportMissingKeys;

        private void Awake()
        {
            if (view == null) view = GetComponent<View>();
        }

        public virtual JObject ToJObject()
        {
            var data = transform.ToJObject();
            data.Add(new JProperty("type", provider.providerType));
            if (!string.IsNullOrWhiteSpace(Addressable)) data.Add(new JProperty("Addressable", Addressable));
            data.Merge(provider.ToJObject());
            return data;
        }

        public virtual void FromJObject(JObject data)
        {
            if (data.ContainsKey("localPosition")) transform.localPosition = data.GetValue("localPosition").ToObject<JObject>().FromJObject();
            else if(reportMissingKeys) Debug.Log("[Model] Missing locationPosition key");
            if (data.ContainsKey("localEulerAngles")) transform.localEulerAngles = data.GetValue("localEulerAngles").ToObject<JObject>().FromJObject();
            else if (reportMissingKeys) Debug.Log("[Model] Missing localEulerAngles key");
            if (data.ContainsKey("localScale")) transform.localScale = data.GetValue("localScale").ToObject<JObject>().FromJObject();
            else if (reportMissingKeys) Debug.Log("[Model] Missing localScale key");
            if (data.ContainsKey("Addressable")) {
                Addressable = data.GetValue("Addressable").Value<string>();
            } else if(reportMissingKeys) Debug.Log("[Model] Missing reportMissingKeys key");
            provider.FromJObject(data.Value<JObject>());
        } 
    }
}