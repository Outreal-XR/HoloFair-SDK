using UnityEngine;
using SaG.GuidReferences;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace outrealxr.holomod
{
    public abstract class WorldModel : MonoBehaviour
    {
        public Dictionary<string, int> GUIDsMap = new Dictionary<string, int>();
        public Dictionary<int, Model> detectedData = new Dictionary<int, Model>();

        public static WorldModel instance;

        private void Awake()
        {
            instance = this;
        }

        public void OnDataCreated(string guid, int id) {
            if (!GUIDsMap.ContainsKey(guid)) GUIDsMap.Add(guid, id);
            Model model = GetModel(guid);
            if (model) {
                if (!detectedData.ContainsKey(id)) detectedData.Add(id, model);
                detectedData[id].SetMMOItemID(id);
            }
        }

        public Model GetModel(string guid)
        {
            GameObject gameObject = GuidManagerSingleton.ResolveGuid(new Guid(guid));
            if (gameObject == null) return null;
            return gameObject.GetComponent<Model>();
        }

        public abstract void WriteData(int id, string guid, JObject data);
        public abstract void ApplyData(int id, JObject data);
        public abstract JObject ReadData(string guid);

    }
}