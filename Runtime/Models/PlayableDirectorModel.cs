using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace outrealxr.holomod
{
    public class PlayableDirectorModel : Provider
    {
        public PlayableDirector director;
        public double startTimestamp;

        public override string ModKey => "playableDirector";

        public override JObject ToJObject()
        {
            JObject data = new JObject();
            data.Add("startTimestamp", startTimestamp);
            return data;
        }

        public override void FromJObject(JObject data)
        {
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
        }
    }
}