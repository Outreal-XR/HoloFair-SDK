using UnityEngine;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Initiator/Event Trigger Node")]
    public class EventTriggerNode : InitiatorNode
    {
        [SerializeField] private string _eventName;
        public string EventName => _eventName;
    }
}