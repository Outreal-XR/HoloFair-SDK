using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class LinkProvider : Provider
    {

        public string url;

        public override string ModKey => "link";

        public override string providerType => GetType().Name;

        public bool isDirty = false;

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
            url = data.GetValue("url").Value<string>();
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