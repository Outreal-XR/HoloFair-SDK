using Newtonsoft.Json.Linq;
using UnityEngine.Playables;

namespace outrealxr.holomod
{
    public class PlayableDirectorModel : BaseModel
    {
        public PlayableDirector director;
        public double startTimestamp;

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add("startTimestamp", startTimestamp);
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
        }
    }
}