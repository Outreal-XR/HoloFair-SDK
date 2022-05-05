using UnityEngine;
using SaG.GuidReferences;
using Newtonsoft.Json.Linq;
using System;

namespace outrealxr.holomod
{
    public abstract class WorldModel : MonoBehaviour
    {
        public static WorldModel instance;

        private void Awake()
        {
            instance = this;
        }

        public abstract void CreateData(string guid);

        public void OnDataCreated(string guid, int id) {
            Model model = GuidManagerSingleton.ResolveGuid(new Guid(guid)).GetComponent<Model>();
            model.SetMMOItemID(id);
            model.Apply();
        }

        public abstract void WriteData(int id, JObject data);
        public abstract void ApplyData(string guid, JObject data);
        public abstract JObject ReadData(int id);
    }
}