using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static outrealxr.holomod.ZoneTalkModel;

namespace outrealxr.holomod
{
    public class BasicTalkZoneView : BasicStringView
    {
        public GameObject idle;
        public GameObject connecting;
        public GameObject success;
        public GameObject error;

        [Tooltip("Assigned automatically on start after world init. Not used in BasicVideoView")]
        BasicTalkZoneController basicTalkZoneController;

        private void Start()
        {
            basicTalkZoneController = (BasicTalkZoneController)controller;
            if (basicTalkZoneController == null) Debug.LogWarning($"[BasicTalkZoneView] There is no controller for {gameObject.name}");
            else basicTalkZoneController.SetModel(model);
        }

        public override void Apply()
        {
            Debug.LogWarning($"[BasicLinkView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }

        public void SetVisualState(State state)
        {
            if (idle) idle.SetActive(state == State.Idle);
            if (connecting) connecting.SetActive(state == State.Connecting);
            if (success) success.SetActive(state == State.Success);
            if (error) error.SetActive(state == State.Error);
        }
    }
}