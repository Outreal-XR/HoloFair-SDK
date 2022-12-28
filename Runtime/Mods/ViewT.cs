using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class ViewT<T> : View
    {
        [SerializeField] private T _value;

        protected override void Start() {
            Factories.Instance.RegisterView(this);
        }

        public void Write(T value) {
            Factories.Instance.WriteData(new ModelData<T>(value, ViewId, transform.position));
        }
        
        public abstract void Edit();

        public virtual void SetValue(T value, Vector3 position) {
            _value = value;
            transform.position = position;
        }
        
        public virtual T GetValue => _value;

        protected override void OnDestroy() {
            Factories.Instance.DeregisterView<T>(this);
        }
    }
}