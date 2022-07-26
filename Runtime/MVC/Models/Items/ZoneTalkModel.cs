using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ZoneTalkModel : StringModel
    {

        public enum State
        {
            Idle,
            Connecting,
            Success,
            Error
        }

        private void Start()
        {
            SetVisualState(State.Idle);
        }

        public void SetVisualState(State state)
        {
            ((BasicTalkZoneView)view).SetVisualState(state);
        }

        public override string type => "zonetalk";
    }
}