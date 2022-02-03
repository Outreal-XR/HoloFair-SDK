using Newtonsoft.Json.Linq;
using UnityEngine.Playables;

namespace outrealxr.holomod
{
    public class PlayableDirectorProvider : Provider
    {
        public PlayableDirector director;
        public double startDelay;
        public double startTimestamp;

        public override string ModKey => "playableDirector";
        
        public override JObject ToJObject()
        {
            return new JObject { { "startTimestamp", startTimestamp } };
        }

        public override void FromJObject(JObject data)
        {
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
        }

        bool isDirty = true;

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