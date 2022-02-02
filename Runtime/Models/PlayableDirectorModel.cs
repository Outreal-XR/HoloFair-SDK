using System;
using Newtonsoft.Json.Linq;
using UnityEngine.Playables;

namespace outrealxr.holomod
{
    public class PlayableDirectorModel : Provider
    {
        public PlayableDirector director;
        public double startDelay;
        public double startTimestamp;
        
        public override string ModKey => "playableDirector";

        public void Start() {
            startTimestamp =
                DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                    .TotalMilliseconds + startDelay;
        }
        
        public override JObject ToJObject()
        {
            var data = new JObject {{"startTimestamp", startTimestamp}};
            return data;
        }

        public override void FromJObject(JObject data)
        {
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
        }
    }
}