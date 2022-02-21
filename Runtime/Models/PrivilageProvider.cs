using Newtonsoft.Json.Linq;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class PrivilageProvider : Provider
    {
        public int[] TargetPrivilages;
        public int MinPrivilage;

        public UnityEvent OnGranted, OnRevoked;

        public override string ModKey => "privilage";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            MinPrivilage = data.GetValue("MinPrivilage").Value<int>();
            TargetPrivilages = data.GetValue("TargetPrivilages").Value<int[]>();
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                new JProperty("MinPrivilage", MinPrivilage),
                new JProperty("TargetPrivilages", TargetPrivilages)
            };
            return data;
        }
    }
}