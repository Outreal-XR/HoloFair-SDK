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

        Dictionary<int, string> map = new Dictionary<int, string>();

        public override void CreateData(string guid)
        {
            if (!map.ContainsValue(guid))
            {
                map.Add(id, guid);
                id++;
            }
            OnDataCreated(guid, id);
        }

        public override void WriteData(int id, JObject data)
        {
            ApplyData(map[id], data);
        }

        public override JObject ReadData(int id)
        {
            return GuidManagerSingleton.ResolveGuid(new Guid(map[id])).GetComponent<Model>().ToJObject();
        }

        public override void ApplyData(string guid, JObject data)
        {
            GameObject go  = GuidManagerSingleton.ResolveGuid(new Guid(guid));
            if (go)
            {
                Model model = go.GetComponent<Model>();
                model.FromJObject(data);
                model.Apply();
            }
        }
    }
}
