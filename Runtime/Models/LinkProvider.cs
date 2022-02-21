using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class LinkProvider : Provider
    {

        public string url;

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
            if (data.ContainsKey("url")) url = data.GetValue("url").Value<string>();
            else Debug.Log("[LinkProvider] Missing url key");
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