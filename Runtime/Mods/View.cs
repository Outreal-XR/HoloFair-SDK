using SaG.GuidReferences;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GuidComponent _guid;

        public string Guid => _guid.GetStringGuid();

        protected virtual void Start() {
            Factories.Instance.RegisterView(this);
        }
    }
}