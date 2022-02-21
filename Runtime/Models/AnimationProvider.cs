using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class AnimationProvider : Provider
    {

        public string emoteName;
        public Transform avatarPivot, respawnPoint;

        public override string ModKey => "animation";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            emoteName = data.GetValue("emoteName").Value<string>();
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
                new JProperty("emoteName", emoteName)
            };
            return data;
        }
    }
}