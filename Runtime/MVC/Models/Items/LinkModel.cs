using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LinkModel : Model
    {

        public string url;
        public UnityEvent OnMissingUrl, OnUrlSet;

        public override string type => "link";

        public void SetURL(string val)
        {
            url = val;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            if (data.ContainsKey("url"))
            {
                url = data.GetValue("url").Value<string>();
                if (!string.IsNullOrWhiteSpace(url))
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
            JObject data = base.ToJObject();
            data.Merge(new JObject
            {
                new JProperty("url", url)
            });
            return data;
        }
    }
}