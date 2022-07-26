using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class RespawnModel : Model
    {
        public float radius;

        public override string type => "respawn";

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                { "radius", radius }
            });
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            radius = data.GetValue("radius").Value<float>();
        }

        public Vector3 GetRespawnPosition()
        {
            var randPos = Random.insideUnitCircle * radius;
            return new Vector3(randPos.x, 0, randPos.y) + transform.position;
        }
    }
}