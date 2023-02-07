using System;
using SaG.GuidReferences;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class View : MonoBehaviour
    {
        private GuidComponent _guid;
        private int _builderId;

        public string ViewId => _guid ? _guid.GetStringGuid() : _builderId.ToString();
        public abstract string Tags { get; }

        public void SetBuilderId(int id) {
            _builderId = id;
        }

        protected virtual void Start() {
            _guid = GetComponent<GuidComponent>();
            Factories.Instance.RegisterView(this);
        }

        protected virtual void OnDestroy() {
            Factories.Instance.DeregisterView(this);
        }
    }
}