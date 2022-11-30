using Newtonsoft.Json.Linq;
using SaG.GuidReferences;
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
        [Tooltip("UTC Timestamp in milliseconds")]
        public double startTime;
        public float elapsedTime;
        public float animationLength;
        public Animator animator;
        
        public override string type => "animator";

        void Start()
        {
            startTime = UniversalTimeModel.Now;
            Apply();
            view.model = this;
            guid = GetComponent<GuidComponent>().GetStringGuid();
        }

        public void SetStateName(string val)
        {
            stateName = val;
            startTime = UniversalTimeModel.Now;
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
            elapsedTime = Mathf.Clamp((float)(UniversalTimeModel.Now - startTime), 0f, animationLength);
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