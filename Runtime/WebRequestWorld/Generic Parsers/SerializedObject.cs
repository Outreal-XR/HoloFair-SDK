using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class SerializedObject : SerializedVar
    {
        [SerializeField] private List<SerializedVar> vars = new ();

        public override void Deserialize(JToken jToken) {
            var jObject = JObject.FromObject(jToken);

            foreach (var serVar in vars) {
                if (!jObject.ContainsKey(serVar.gameObject.name)) continue;
                var token = jObject.GetValue(serVar.gameObject.name);
                serVar.Deserialize(token);
            }
        }

        public override JToken Serialize() {
            var jObject = new JObject();

            foreach (var serVar in vars) {
                jObject.Add(serVar.gameObject.name, serVar.Serialize());
            }

            return jObject;
        }
    }
}