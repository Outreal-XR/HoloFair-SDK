using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class PortalModel : MonoBehaviour, IProvider
    {
        public string sceneName;

        public JObject ToJObject()
        {
            JObject data = new JObject
            {
                { "sceneName", sceneName }
            };
            return data;
        }

        public void FromJObject(JObject data)
        {
            sceneName = data.GetValue("sceneName").Value<string>();
        }
    }
}