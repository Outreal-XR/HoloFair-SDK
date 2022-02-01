using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace outrealxr.holomod
{
    public class PlayableDirectorModel : MonoBehaviour, IProvider
    {
        public PlayableDirector director;
        public double startTimestamp;

        public JObject ToJObject()
        {
            JObject data = new JObject();
            data.Add("startTimestamp", startTimestamp);
            return data;
        }

        public void FromJObject(JObject data)
        {
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
        }
    }
}