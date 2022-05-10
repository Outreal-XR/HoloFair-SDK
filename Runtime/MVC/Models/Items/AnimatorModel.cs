using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class AnimatorModel : Model
    {
        [Header("Network variables")]
        public string stateName;
        public int layerIndex;

        [Header("Local variables")]
        public string normalizedTimeParameterName = "progress";
        [Tooltip("UTC Timestamp in milliseconds")]
        public double now, startTime;
        public float elapsedTime;
        public float animationLength;
        public Animator animator;

        DateTime startDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public void SetStateName(string val)
        {
            stateName = val;
            startTime = 0;
        }

        public void SetLayerIndex(int val)
        {
            layerIndex = val;
        }

        public override string type => "animator";

        private void Start()
        {
            startTime = DateTime.UtcNow.Subtract(startDateTime).TotalMilliseconds;
            Apply();
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            stateName = data.GetValue("stateName").Value<string>();
            layerIndex = data.GetValue("layerIndex").Value<int>();
            startTime = data.GetValue("startTime").Value<double>();
            Apply();
        }

        void Update()
        {
            now = DateTime.Now.ToUniversalTime().Subtract(startDateTime).TotalMilliseconds;
            elapsedTime = ((float)(now - startTime)) / 1000f;
            if (animator)
                animationLength = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
            if (animationLength > 0)
                animator.SetFloat(normalizedTimeParameterName, elapsedTime / animationLength);
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                new JProperty("stateName", stateName),
                new JProperty("layerIndex", layerIndex)
            });
            if (startTime == 0) data.Add(new JProperty("startTime", startTime));
            return data;
        }
    }
}