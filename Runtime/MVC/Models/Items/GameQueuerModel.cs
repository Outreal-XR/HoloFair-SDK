using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class GameQueuerModel : Model
    {
        public string sceneName;
        public int portalID;
        public float startDelay;
        public int gameLimit;
        
        public override JObject ToJObject() {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                { "sceneName", sceneName },
                { "portalID", portalID },
                { "startDelay", startDelay },
                { "gameLimit", gameLimit}
            });
            return data;
        }

        public override void FromJObject(JObject data) {
            base.FromJObject(data);
            sceneName = (data.GetValue("sceneName") ?? sceneName).Value<string>();
            portalID = (data.GetValue("portalID") ?? portalID).Value<int>();
            startDelay = (data.GetValue("startDelay") ?? startDelay).Value<float>();
            gameLimit = (data.GetValue("gameLimit") ?? gameLimit).Value<int>();
        }

        public override string type => "gameQueuer";
    }
}