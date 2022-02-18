using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ZoneTalkProvider : Provider
    {

        public string zoneName;

        [Header("Visuals")]
        public GameObject success;
        public GameObject connecting;
        public GameObject error;

        public override string ModKey => "zonetalk";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            zoneName = data.GetValue("zoneName").Value<string>();
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                new JProperty("zoneName", zoneName)
            };
            return data;
        }
    }
}