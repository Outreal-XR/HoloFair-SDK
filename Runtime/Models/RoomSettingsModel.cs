using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RoomSettingsModel : Provider
    {
        public Transform lowerBound, higherBound;
        public Vector3 AOI;
        public int maxSpectators, maxUsers, maxVariables, gameID;

        public override string ModKey => "roomSettings";

        public override JObject ToJObject()
        {
            JObject data = new JObject();
            data.Add("lowerBound", lowerBound.position.ToJObject());
            data.Add("higherBound", higherBound.position.ToJObject());
            data.Add("AOI", AOI.ToJObject());
            data.Add("maxSpectators", maxSpectators);
            data.Add("maxUsers", maxUsers);
            data.Add("maxVariables", maxVariables);
            data.Add("gameID", gameID);
            return data;
        }

        public override void FromJObject(JObject data)
        {

        }
    }
}