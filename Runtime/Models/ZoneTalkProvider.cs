using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ZoneTalkProvider : Provider
    {

        public enum State
        {
            Idle,
            Connecting,
            Success,
            Error
        }

        public string zoneName;

        [Header("Visuals")]
        public GameObject idle;
        public GameObject connecting;
        public GameObject success;
        public GameObject error;

        private void Start()
        {
            SetVisualState(State.Idle);
        }

        public override string ModKey => "zonetalk";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            zoneName = data.GetValue("zoneName").Value<string>();
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public void SetVisualState(State state)
        {
            if (idle) idle.SetActive(state == State.Idle);
            if (connecting) idle.SetActive(state == State.Connecting);
            if (success) idle.SetActive(state == State.Success);
            if (error) idle.SetActive(state == State.Error);
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
                new JProperty("zoneName", zoneName)
            };
            return data;
        }
    }
}