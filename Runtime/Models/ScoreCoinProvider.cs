using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreCoinProvider : Provider
    {
        public float baseAmount, minAmount;
        public float expectedCollectionTimeAfterSceneLoad = -1;
        public float amountPerSecondAfterExpectedCollectionTime = 0.1f;
        public GameObject visual;

        public static float startTime = 0;

        public void UpdateStartTime()
        {
            startTime = Time.time;
        }

        public override JObject ToJObject() {
            return new JObject {
                { "amount", GetAmount () },
                { "baseAmount", baseAmount },
                { "minAmount", minAmount },
                { "expectedCollectionTimeAfterSceneLoad", expectedCollectionTimeAfterSceneLoad },
                { "amountPerSecondAfterExpectedCollectionTime", amountPerSecondAfterExpectedCollectionTime }
            };
        }

        public override void FromJObject(JObject data) {
            baseAmount = (data.GetValue("baseAmount") ?? baseAmount).Value<float>();
            minAmount = (data.GetValue("minAmount") ?? baseAmount).Value<float>();
            expectedCollectionTimeAfterSceneLoad = (data.GetValue("expectedCollectionTimeAfterSceneLoad") ?? baseAmount).Value<float>();
            amountPerSecondAfterExpectedCollectionTime = (data.GetValue("amountPerSecondAfterExpectedCollectionTime") ?? baseAmount).Value<float>();
        }

        public float GetAmount()
        {
            if (expectedCollectionTimeAfterSceneLoad < 0) return baseAmount;
            float timePassedAfterCollection = Mathf.Clamp(Time.time - startTime - expectedCollectionTimeAfterSceneLoad, 0, float.MaxValue);
            return Mathf.Clamp(baseAmount - timePassedAfterCollection * amountPerSecondAfterExpectedCollectionTime, minAmount, float.MaxValue);
        }

        public override string providerType => GetType().Name;
        public override string ModKey => "scoreCoin";
        public override void SetIsDirty(bool val) => isDirty = val;
        public override bool IsDirty() => isDirty;
    }
}
