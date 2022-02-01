using Newtonsoft.Json.Linq;

public interface IProvider
{
    public abstract JObject ToJObject();

    public abstract void FromJObject(JObject data);
}
