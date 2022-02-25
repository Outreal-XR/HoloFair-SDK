using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class AnimatorProvider : Provider
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
        }

        public void SetLayerIndex(int val)
        {
            layerIndex = val;
        }

        public override string ModKey => "animator";

        public override string providerType => GetType().Name;

        private void Start()
        {
            startTime = DateTime.UtcNow.Subtract(startDateTime).TotalMilliseconds;
            Sync();
        }

        public override void FromJObject(JObject data)
        {
            stateName = data.GetValue("stateName").Value<string>();
            layerIndex = data.GetValue("layerIndex").Value<int>();
            startTime = data.GetValue("startTime").Value<double>();
            Sync();
        }

        void Sync()
        {
            animator.Play(stateName); 
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

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                new JProperty("stateName", stateName),
                new JProperty("layerIndex", layerIndex)
            };
            if (startTime == 0) data.Add(new JProperty("startTime", startTime));
            return data;
        }
    }
}