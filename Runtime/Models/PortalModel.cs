using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class PortalModel : Provider
    {
        public string sceneName;

        public override string ModKey => "portal";
        
        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "sceneName", sceneName }
            };
            return data;
        }

        public override void FromJObject(JObject data)
        {
            sceneName = data.GetValue("sceneName").Value<string>();
        }
    }
}