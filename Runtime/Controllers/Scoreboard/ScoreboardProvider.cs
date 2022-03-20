using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class ScoreboardProvider : Provider
    {
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