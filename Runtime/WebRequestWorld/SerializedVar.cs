using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public abstract class SerializedVar : MonoBehaviour
    {
        public abstract void Deserialize(JToken jToken);
        public abstract string Serialize();
    }
}