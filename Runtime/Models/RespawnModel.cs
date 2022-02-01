using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class RespawnModel : BaseModel
    {
        public float radius;

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add("radius", radius);
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            radius = data.GetValue("radius").Value<float>();
        }
    }
}