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
        [Tooltip("ms")]
        public double lagCompensationAmount = 100;
        [Tooltip("UTC Timestamp in milliseconds")]
        public double now, startTime;
        public float elapsedTime;
        public float animationLength;
        public Animator animator;
        readonly DateTime beginningOfTheWorld = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override string type => "animator";

        void Start()
        {
            startTime = DateTime.UtcNow.Subtract(beginningOfTheWorld).TotalMilliseconds;
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
            startTime = data.GetValue("startTime").Value<double>() - lagCompensationAmount;
            AnimatorStateInfo current = animator.GetCurrentAnimatorStateInfo(layerIndex);
            Debug.Log($"[AnimatorModel] old ({current.fullPathHash}): {current.length}");
            Apply();
            StartCoroutine(UpdateAnimationLength());
        }

        IEnumerator UpdateAnimationLength()
        {
            yield return new WaitForFixedUpdate();
            AnimatorStateInfo current = animator.GetCurrentAnimatorStateInfo(layerIndex);
            Debug.Log($"[AnimatorModel] new ({current.fullPathHash}): {current.length}");
            animationLength = current.length;
            LateUpdate();
        }

        void LateUpdate()
        {
            now = DateTime.Now.ToUniversalTime().Subtract(beginningOfTheWorld).TotalMilliseconds;
            elapsedTime = Mathf.Clamp(((float)(now - startTime)) / 1000f, 0f, animationLength);
            if (animationLength > 0)
                animator.SetFloat(normalizedTimeParameterName, elapsedTime / animationLength);
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