using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ZoneTalkModel : Model
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

        public override string type => "zonetalk";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            zoneName = data.GetValue("zoneName").Value<string>();
        }

        public void SetVisualState(State state)
        {
            if (idle) idle.SetActive(state == State.Idle);
            if (connecting) connecting.SetActive(state == State.Connecting);
            if (success) success.SetActive(state == State.Success);
            if (error) error.SetActive(state == State.Error);
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject {
                new JProperty("zoneName", zoneName)
            });
            return data;
        }
    }
}