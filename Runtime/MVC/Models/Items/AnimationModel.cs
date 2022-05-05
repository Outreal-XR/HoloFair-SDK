using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class AnimationModel : Model
    {

        public string emoteName;
        [Tooltip("This is where pivot of user avatar must be snapped to when animation is activated. Shouldn't be null")]
        public Transform avatarPivot;
        [Tooltip("This is where avatar is respawned when animation stops")]
        public Transform respawnPoint;

        public override string type => "animation";

        public void SetEmoteName(string val)
        {
            emoteName = val;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            emoteName = data.GetValue("emoteName").Value<string>();
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                new JProperty("emoteName", emoteName)
            });
            return data;
        }
    }
}