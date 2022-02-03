using Newtonsoft.Json.Linq;
using UnityEngine;

public abstract class Provider: MonoBehaviour
{
    public abstract string ModKey { get; }

    public abstract void SetIsDirty(bool val);

    public abstract bool IsDirty();

    public abstract JObject ToJObject();

    public abstract void FromJObject(JObject data);
}
