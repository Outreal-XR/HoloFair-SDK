using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RoomSettingsProvider : Provider
    {
        public Transform lowerBound, higherBound;
        [Tooltip("Server Render Area for a local user. Good value is usually 25,25,25")]
        public Vector3 AOI = Vector3.one*25f;
        public string venueName;
        public int maxSpectators = 25, maxUsers = 25;
        [Range(5, 20)]
        public int maxVariables = 10;
        public int gameID;

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