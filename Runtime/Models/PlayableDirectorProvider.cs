using Newtonsoft.Json.Linq;
using System;
using UnityEngine.Playables;
using UnityEngine;

namespace outrealxr.holomod
{
    public class PlayableDirectorProvider : Provider
    {
        public PlayableDirector director;
        [Tooltip("Don't touch it. It is used only for debugging")]
        public double startTimestamp;
        [Tooltip("Don't touch it. It is used only for debugging")]
        public double difference;

        public override string ModKey => "playableDirector";

        public override string providerType => GetType().Name;

        public override JObject ToJObject()
        {
            return new JObject { { "startTimestamp", startTimestamp } };
        }

        public override void FromJObject(JObject data)
        {
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
            var now = DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            difference = (now - startTimestamp) / 1000;

            if (director.time == 0) director.Play();
            if (now >= startTimestamp) director.time = difference;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override bool IsDirty()
        {
            return isDirty;
        }
    }
}