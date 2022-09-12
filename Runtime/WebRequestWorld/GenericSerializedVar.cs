using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod.Runtime
{
    public abstract class GenericSerializedVar<T> : SerializedVar where T : notnull
    {
        [SerializeField] protected T value;
        [SerializeField] protected UnityEvent<T> OnValueUpdate;

        public override void Deserialize(JToken jToken) {
            value = jToken.Value<T>();
            OnValueUpdate?.Invoke(value);
        }

        public override JToken Serialize() => JToken.FromObject(value);

        public void SetValue(T newValue) => value = newValue;
        public void SetValue(GenericSerializedVar<T> otherVar) => value = otherVar.value;
    }
}