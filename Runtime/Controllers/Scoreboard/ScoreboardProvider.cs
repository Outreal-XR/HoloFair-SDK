using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreboardProvider : Provider
    {
        public bool isDebugging;
        public Scoreboard scoreboard;

        public override string ModKey => "scoreBoard";

        public override string providerType => GetType().Name;

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override void FromJObject(JObject data)
        {
            if (isDebugging) Debug.Log("[ScoreboardProvider] Updating scoreboard: " + data.ToString());
            scoreboard.UpdateModels(new JObject() {
                new JProperty ("models", data.GetValue("scoreboard"))
            });
        }

        public override JObject ToJObject()
        {
            return new JObject();
        }
    }
}