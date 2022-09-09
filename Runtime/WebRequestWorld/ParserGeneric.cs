using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod.Runtime
{
    public abstract class ParserGeneric<T> : Parser where T : notnull
    {
        [SerializeField] protected T value;
        [SerializeField] protected UnityEvent<T> OnValueUpdate;

        public override void SetValue(JToken jToken) {
            value = jToken.Value<T>();
            OnValueUpdate?.Invoke(value);
        }
    }
}