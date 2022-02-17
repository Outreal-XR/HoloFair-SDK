using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RoomSettingsProvider : Provider
    {
        public Transform lowerBound, higherBound;
        public Vector3 AOI;
        public string venueName;
        public int maxSpectators, maxUsers, maxVariables, gameID;

        public override string ModKey => "roomSettings";

        public override string providerType => GetType().Name;

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "lowerBound", lowerBound.position.ToJObject() },
                { "higherBound", higherBound.position.ToJObject() },
                { "AOI", AOI.ToJObject() },
                { "maxSpectators", maxSpectators },
                { "maxUsers", maxUsers },
                { "maxVariables", maxVariables },
                { "venueName", venueName },
                { "gameID", gameID }
            };
            return data;
        }

        public override void FromJObject(JObject data)
        {

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