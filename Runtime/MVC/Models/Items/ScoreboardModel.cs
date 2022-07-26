using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreboardModel : Model
    {
        public bool isDebugging;
        public Scoreboard scoreboard;

        public override string type => "scoreBoard";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            if (isDebugging) Debug.Log("[ScoreboardProvider] Updating scoreboard: " + data.ToString());
            scoreboard.UpdateModels(new JObject() {
                new JProperty ("models", data.GetValue("scoreboard"))
            });
        }
    }
}