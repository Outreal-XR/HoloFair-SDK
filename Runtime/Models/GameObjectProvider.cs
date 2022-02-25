using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class GameObjectProvider : Provider
    {
        public override string ModKey => "gameObject";
        public override void SetIsDirty(bool val) {
            isDirty = val;
        }

        public override bool IsDirty() => isDirty;

        public override JObject ToJObject() {
            var data = new JObject {
                new JProperty("active", gameObject.activeInHierarchy)
            };
            return data;
        }

        public override void FromJObject(JObject data) {
            var active = data.GetValue("active").Value<bool>();
            
            gameObject.SetActive(active);
        }

        public override string providerType => typeof(GameObjectProvider).ToString();
    }
}
