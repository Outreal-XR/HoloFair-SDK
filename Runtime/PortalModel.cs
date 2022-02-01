using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class PortalModel : BaseModel
    {
        public string sceneName;

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add("sceneName", sceneName);
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            sceneName = data.GetValue("sceneName").Value<string>();
        }
    }
}