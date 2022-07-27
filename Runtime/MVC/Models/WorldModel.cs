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

#if UNITY_EDITOR
        public TMPro.TextMeshPro debugText;
        public Color error = Color.red, warning = Color.yellow;
        protected Dictionary<string, TMPro.TextMeshPro> debugtexts = new Dictionary<string, TMPro.TextMeshPro>();
#endif

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// Updates dictionary
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="id"></param>
        /// <returns>Weather it was successfull to set an ID or not</returns>
        public bool OnDataCreated(string guid, int id) {
            if (!GUIDsMap.ContainsKey(guid)) GUIDsMap.Add(guid, id);
            Model model = GetModel(guid);
            if (model) {
                if (!detectedData.ContainsKey(id)) detectedData.Add(id, model);
                detectedData[id].SetMMOItemID(id);
                ClearProblem(guid);
                return true;
            }
            return false;
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
#if UNITY_EDITOR
        protected void ReportProblem(string guid, string msg, Vector3 pos, bool error)
        {
            ClearProblem(guid);
            debugtexts.Add(guid, Instantiate(debugText, pos, Quaternion.identity, transform));
            debugtexts[guid].text = msg;
            debugtexts[guid].color = error ? this.error : warning;
        }

        protected void ClearProblem(string guid)
        {
            if (debugtexts.ContainsKey(guid))
            {
                if(debugtexts[guid]) Destroy(debugtexts[guid].gameObject);
                debugtexts.Remove(guid);
            }
        }
#endif
    }
}