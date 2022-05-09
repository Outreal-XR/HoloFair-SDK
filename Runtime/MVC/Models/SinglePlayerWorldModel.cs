using Newtonsoft.Json.Linq;
using SaG.GuidReferences;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SinglePlayerWorldModel : WorldModel
    {
        int id = 0;

        public override void CreateData(string guid)
        {
            if (!pendingData.ContainsKey(guid))
            {
                pendingData.Add(guid, GuidManagerSingleton.ResolveGuid(new Guid(guid)).GetComponent<Model>());
                id++;
            }
            OnDataCreated(guid, id);
        }

        public override void WriteData(int id, JObject data)
        {
            ApplyData(id, data);
        }

        public override JObject ReadData(int id)
        {
            return detectedData[id].ToJObject();
        }

        public override void ApplyData(int id, JObject data)
        {
            if (detectedData.ContainsKey(id))
            {
                Model model = detectedData[id];
                model.FromJObject(data);
                model.Apply();
            }
        }
    }
}
