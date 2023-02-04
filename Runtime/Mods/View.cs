using System;
using SaG.GuidReferences;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GuidComponent _guid;

        [SerializeField] private int _builderId;
        [SerializeField] public string tags;

        public string ViewId => _guid ? _guid.GetStringGuid() : _builderId.ToString();

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