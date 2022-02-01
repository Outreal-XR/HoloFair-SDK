using UnityEngine;
using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class BaseModel: MonoBehaviour
    {
        public virtual JObject ToJObject()
        {
            return transform.ToJObject();
        }

        public virtual void FromJObject(JObject data)
        {
            transform.localPosition = data.GetValue("localPosition").ToObject<JObject>().FromJObject();
            transform.localEulerAngles = data.GetValue("localEulerAngles").ToObject<JObject>().FromJObject();
            transform.localScale = data.GetValue("localScale").ToObject<JObject>().FromJObject();
        } 
    }
}