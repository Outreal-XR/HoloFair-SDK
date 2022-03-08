using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class AnimationProvider : Provider
    {

        public string emoteName;
        [Tooltip("This is where pivot of user avatar must be snapped to when animation is activated. Shouldn't be null")]
        public Transform avatarPivot;
        [Tooltip("This is where avatar is respawned when animation stops")]
        public Transform respawnPoint;

        public override string ModKey => "animation";

        public override string providerType => GetType().Name;

        public void SetEmoteName(string val)
        {
            emoteName = val;
        }

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