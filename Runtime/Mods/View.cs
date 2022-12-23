using SaG.GuidReferences;
using UnityEngine;

namespace com.outrealxr.holomod
{
    [RequireComponent(typeof(GuidComponent))]
    public class View : MonoBehaviour
    {
        [SerializeField] private GuidComponent _guid;

        public string Guid => _guid.GetStringGuid();

        protected virtual void Start() {
            _guid = GetComponent<GuidComponent>();
            Factories.Instance.RegisterView(this);
        }
    }
}