using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static outrealxr.holomod.ZoneTalkModel;

namespace outrealxr.holomod
{
    public class BasicTalkZoneView : BasicStringView
    {
        [Tooltip("Assigned automatically on start after world init. Not used in BasicVideoView")]
        BasicTalkZoneController basicTalkZoneController;

        private void Start()
        {
            if (!CheckForController()) return;

            basicTalkZoneController = (BasicTalkZoneController)controller;
            if (basicTalkZoneController == null) Debug.LogWarning($"[BasicTalkZoneView] There is no controller for {gameObject.name}");
            else basicTalkZoneController.SetModel(model);
        }

        public override void Apply()
        {
            Debug.LogWarning($"[BasicLinkView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }

        public void Join()
        {
            if (!CheckForController()) return;

            basicTalkZoneController.SetRoomName((model as StringModel).value);
            basicTalkZoneController.SetVideoOutput((model as ZoneTalkModel).videoMeshRenderer, (model as ZoneTalkModel).materialIndex, (model as ZoneTalkModel).materialPropertyName);
            basicTalkZoneController.Join();
        }

        public void Leave()
        {
            if (!CheckForController()) return;

            basicTalkZoneController.Leave();
        }
    }
}