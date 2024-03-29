using UnityEngine;

namespace com.outrealxr.holomod
{
    public sealed class Model<T> where T: notnull
    {
        public T Value { get; private set; }
        private ViewT<T> _view;
        public readonly string Id;
        public Vector3 Position { get; private set; }

        public Model(ModelData<T> modelData) {
            Value = modelData.Value;
            Id = modelData.Id;
            Position = modelData.Position;
        }

        public void SetView(ViewT<T> view) => _view = view;

        public void SetValue(Vector3 pos, T val) {
            Value = val;
            Position = pos;
            if (_view) _view.SetValue(val);
        }
    }
}