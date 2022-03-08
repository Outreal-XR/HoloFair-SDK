using Newtonsoft.Json.Linq;
using outrealxr.holomod;
using UnityEngine;

public class ScoreCoinProvider : Provider
{
    public float amount;
    
    public override JObject ToJObject() {
        return new JObject { { "amount", amount } };
    }

    public override void FromJObject(JObject data) {
        amount = (data.GetValue("amount") ?? amount).Value<float>();
    }

    public override string providerType => GetType().Name;
    public override string ModKey => "scoreCoin";
    public override void SetIsDirty(bool val) => isDirty = val;
    public override bool IsDirty() => isDirty;

}
