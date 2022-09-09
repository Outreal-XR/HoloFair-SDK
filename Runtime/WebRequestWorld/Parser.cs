using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public abstract class Parser : MonoBehaviour
    {
        public abstract void SetValue(JToken jToken);
    }
}