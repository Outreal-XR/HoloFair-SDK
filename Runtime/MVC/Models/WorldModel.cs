using UnityEngine;
using SaG.GuidReferences;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace outrealxr.holomod
{
    public abstract class WorldModel : MonoBehaviour
    {

        public Dictionary<string, Model> pendingData = new Dictionary<string, Model>();
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
        public void StartWorld()
        {
            foreach (var onStartHandler in FindObjectsOfType<OnStartHandler>())
                onStartHandler.WorldStart();
        }

        public abstract void CreateData(string guid);

        public void OnDataCreated(string guid, int id) {
            if (!pendingData.ContainsKey(guid)) pendingData.Add(guid, GuidManagerSingleton.ResolveGuid(new Guid(guid)).GetComponent<Model>());
            if (!detectedData.ContainsKey(id)) detectedData.Add(id, pendingData[guid]);
            pendingData.Remove(guid);
            detectedData[id].SetMMOItemID(id);
        }

        public abstract void WriteData(int id, JObject data);
        public abstract void ApplyData(int id, JObject data);
        public abstract JObject ReadData(int id);
    }
}