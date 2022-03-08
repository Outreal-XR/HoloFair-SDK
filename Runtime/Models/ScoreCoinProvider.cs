using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreCoinProvider : Provider
    {
        public int amount;
        public GameObject visual;

        public override JObject ToJObject() {
            return new JObject {{"amount", amount}};
        }

        public override void FromJObject(JObject data) {
            amount = (data.GetValue("amount") ?? amount).Value<int>();
        }

        public override string providerType => GetType().Name;
        public override string ModKey => "scoreCoin";
        public override void SetIsDirty(bool val) => isDirty = val;
        public override bool IsDirty() => isDirty;
    }
}
