using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LinkProvider : Provider
    {

        public string url;
        public UnityEvent OnMissingUrl, OnUrlSet;

        public override string ModKey => "link";

        public override string providerType => GetType().Name;

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override void FromJObject(JObject data)
        {
            if (data.ContainsKey("url"))
            {
                url = data.GetValue("url").Value<string>();
                if (string.IsNullOrWhiteSpace(url))
                {
                    OnUrlSet.Invoke();
                }
                else
                {
                    Debug.LogWarning("[LinkProvider] Empty url key");
                    OnMissingUrl.Invoke();
                }
            }
            else
            {
                Debug.LogWarning("[LinkProvider] Missing url key");
                OnMissingUrl.Invoke();
            }
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                new JProperty("url", url)
            };
            return data;
        }
    }
}