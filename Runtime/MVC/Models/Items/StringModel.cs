using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class StringModel : Model
    {
        [Header("Network Base Settings")]
        [TextArea(2, 10)]
        public string value;
        public override string type => "string";

        public virtual void SetValue(string value)
        {
            this.value = value;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            SetValue(data.GetValue("value").ToString());
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add(new JProperty("value", value));
            return data;
        }
    }
}