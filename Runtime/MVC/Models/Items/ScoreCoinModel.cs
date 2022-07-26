using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ScoreCoinModel : Model
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
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                { "amount", GetAmount () },
                { "baseAmount", baseAmount },
                { "minAmount", minAmount },
                { "expectedCollectionTimeAfterSceneLoad", expectedCollectionTimeAfterSceneLoad },
                { "amountPerSecondAfterExpectedCollectionTime", amountPerSecondAfterExpectedCollectionTime }
            });
            return data;
        }

        public override void FromJObject(JObject data) {
            base.FromJObject(data);
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

        public override string type => GetType().Name;
    }
}
