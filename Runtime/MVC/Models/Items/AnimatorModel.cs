using Newtonsoft.Json.Linq;
using SaG.GuidReferences;
using System;
using System.Collections;
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
        bool applyProgress;
        [Tooltip("UTC Timestamp in milliseconds")]
        public double now, startTime;
        public float elapsedTime;
        public float animationLength;
        public Animator animator;

        DateTime startDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override string type => "animator";

        void Start()
        {
            startTime = DateTime.UtcNow.Subtract(startDateTime).TotalMilliseconds;
            Apply();
            view.model = this;
            guid = GetComponent<GuidComponent>().GetStringGuid();
            WorldModel.instance.CreateData(guid);
        }

        public void SetStateName(string val)
        {
            stateName = val;
            startTime = now;
        }

        public void SetLayerIndex(int val)
        {
            layerIndex = val;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            stateName = data.GetValue("stateName").Value<string>();
            layerIndex = data.GetValue("layerIndex").Value<int>();
            startTime = data.GetValue("startTime").Value<double>();
            applyProgress = false;
            StartCoroutine(ApplyProgress());
        }

        void Update()
        {
            if (!applyProgress) return;
            now = DateTime.Now.ToUniversalTime().Subtract(startDateTime).TotalMilliseconds;
            elapsedTime = ((float)(now - startTime)) / 1000f;
            if (animator)
                animationLength = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
            if (animationLength > 0)
                animator.SetFloat(normalizedTimeParameterName, elapsedTime / animationLength);
        }

        IEnumerator ApplyProgress()
        {
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            applyProgress = true;
            Update();
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                new JProperty("stateName", stateName),
                new JProperty("layerIndex", layerIndex),
                new JProperty("startTime", startTime)
            });
            return data;
        }
    }
}