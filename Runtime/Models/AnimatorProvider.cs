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
        public double startTime;
        public float elapsedTime, currentTime;
        public float animationLength;
        public Animator animator;

        DateTime startDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        static DateTime epoch = new DateTime(1970, 1, 1);

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
            startDateTime = epoch.AddMilliseconds(double.Parse(startTime.ToString()));
            animator.Play(stateName);
            animationLength = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
            elapsedTime = (float)(DateTime.UtcNow.Subtract(startDateTime).TotalMilliseconds % (animationLength * 1000f) / 1000f);
        }

        void Update()
        {
            currentTime = elapsedTime + Time.time;
            if(animationLength > 0)
                animator.SetFloat(normalizedTimeParameterName, currentTime / animationLength);
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
            return data;
        }
    }
}