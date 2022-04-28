using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace outrealxr.holomod
{
    public class PortalProvider : Provider
    {
        public string sceneName;
        public AssetReference scene;


        public override string ModKey => "portal";

        public override string providerType => GetType().Name;

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
        
        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override bool IsDirty()
        {
            return isDirty;
        }
    }
}