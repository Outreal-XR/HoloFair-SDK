using SaG.GuidReferences;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class View<T> : MonoBehaviour
    {
        [SerializeField] private bool _readOnStart;

        [SerializeField] private T _value;

        [SerializeField] private GuidComponent _guid;
        
        protected virtual void Start() {
            Factories.Instance.RegisterView(this);
            if (_readOnStart) Read();
        }

        public void Read() {
            Factories.Instance.ReadData(this);
        }

        public void Write(T value) {
            Factories.Instance.WriteData(new ModelData<T>(value, Guid, transform.position));
        }
        
        public abstract void Edit();

        public string Guid => _guid.GetStringGuid();

        public virtual void SetValue(T value, Vector3 position) {
            _value = value;
            transform.position = position;
        }
        
        public virtual T GetValue => _value;
    }
}