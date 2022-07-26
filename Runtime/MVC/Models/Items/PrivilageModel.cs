using Newtonsoft.Json.Linq;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class PrivilageModel : Model
    {
        public int[] TargetPrivilages;
        public int MinPrivilage;

        public UnityEvent OnGranted, OnRevoked;

        public override string type => "privilage";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            MinPrivilage = data.GetValue("MinPrivilage").Value<int>();
            TargetPrivilages = data.GetValue("TargetPrivilages").Value<int[]>();
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                new JProperty("MinPrivilage", MinPrivilage),
                new JProperty("TargetPrivilages", TargetPrivilages)
            });
            return data;
        }
    }
}