using Newtonsoft.Json.Linq;
using System;
using UnityEngine.Playables;
using UnityEngine;

namespace outrealxr.holomod
{
    public class PlayableDirectorModel : Model
    {
        public PlayableDirector director;
        [Tooltip("Don't touch it. It is used only for debugging")]
        public double startTimestamp;
        [Tooltip("Don't touch it. It is used only for debugging")]
        public double difference;

        public override string type => "playableDirector";

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject { { "startTimestamp", startTimestamp } });
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
            var now = DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            difference = (now - startTimestamp) / 1000;

            if (director.time == 0) director.Play();
            if (now >= startTimestamp) director.time = difference;
        }
    }
}