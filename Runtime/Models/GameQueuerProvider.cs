using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class GameQueuerProvider : Provider
    {
        public string sceneName;
        public int portalID;
        public float startDelay;
        public int gameLimit;
        
        public override JObject ToJObject() {
            var data = new JObject {
                { "sceneName", sceneName },
                { "portalID", portalID },
                { "startDelay", startDelay },
                { "gameLimit", gameLimit} 
            };
            return data;
        }

        public override void FromJObject(JObject data) {
            sceneName = (data.GetValue("sceneName") ?? sceneName).Value<string>();
            portalID = (data.GetValue("portalID") ?? portalID).Value<int>();
            startDelay = (data.GetValue("startDelay") ?? startDelay).Value<float>();
            gameLimit = (data.GetValue("gameLimit") ?? gameLimit).Value<int>();
        }

        public override string providerType => GetType().Name;
        public override string ModKey => "gameQueuer";
        
        public override void SetIsDirty(bool val) {
            isDirty = val;
        }
        public override bool IsDirty() => isDirty;

    }
}