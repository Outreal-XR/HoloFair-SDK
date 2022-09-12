using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class SerializedArray : SerializedVar
    {
        [SerializeField] private List<SerializedVar> vars = new ();

        public override void Deserialize(JToken jToken) {
            var array = JArray.FromObject(jToken);

            for (var i = 0; i < array.Count; i++) {
                if (i >= vars.Count) continue;
                if (vars[i]) vars[i].Deserialize(array[i]);
            }
        }

        public override JToken Serialize() {
            var array = new JArray();

            foreach (var serVar in vars)
                if (serVar) array.Add(serVar.Serialize());

            return array;
        }
    }
}