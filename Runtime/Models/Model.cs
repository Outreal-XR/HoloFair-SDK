using UnityEngine;
using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    [RequireComponent(typeof(View))]
    public class Model: MonoBehaviour
    {

        [Tooltip("Addressable Path to a GameObject (Optional)")]
        public string Addressable;
        public Provider provider;
        public View view;
        public bool reportMissingKeys;

        private void Reset () {
            view = GetComponent<View>();
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
            data.ToTransform(this);
            if (data.ContainsKey("Addressable")) Addressable = data.GetValue("Addressable").Value<string>();
            else if(reportMissingKeys) Debug.Log("[Model] Missing Addressable key");
            provider.FromJObject(data.Value<JObject>());
        } 
    }
}