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
        public float timeAfterWorldReady = 2f;
        protected float timeNow;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if(timeNow > 0)
            {
                timeNow -= Time.deltaTime;
                if (timeNow <= 0) StartWorld();
            }
        }

        public void CreateData()
        {
            timeNow = timeAfterWorldReady;
        }

        public void StartWorld()
        {
            foreach (var onStartHandler in FindObjectsOfType<OnStartHandler>())
                onStartHandler.WorldStart();
        }

        public void OnDataCreated(string guid, int id) {
            if (!GUIDsMap.ContainsKey(guid)) GUIDsMap.Add(guid, id);
            if (!detectedData.ContainsKey(id)) detectedData.Add(id, GetModel(guid));
            detectedData[id].SetMMOItemID(id);
        }

        public Model GetModel(string guid)
        {
            return GuidManagerSingleton.ResolveGuid(new Guid(guid)).GetComponent<Model>();
        }

        public abstract void WriteData(int id, string guid, JObject data);
        public abstract void ApplyData(int id, JObject data);
        public abstract JObject ReadData(string guid);

    }
}