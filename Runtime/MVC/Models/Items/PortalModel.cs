using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class PortalModel : Model
    {
        public string sceneName;

        public override string type => "portal";

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {{
                "sceneName", sceneName
            }});
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            sceneName = data.GetValue("sceneName").Value<string>();
        }
    }
}