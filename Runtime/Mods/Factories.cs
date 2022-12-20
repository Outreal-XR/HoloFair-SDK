using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class Factories : MonoBehaviour
    {
        protected ModelFactory<string> _stringFactory;
        protected ModelFactory<double> _doubleFactory;
        protected ModelFactory<int> _intFactory;
        
        protected readonly Dictionary<string, StringView> _stringViews = new();
        protected readonly Dictionary<string, DoubleView> _doubleViews = new();
        protected readonly Dictionary<string, IntView> _intViews = new();
        
        public static Factories Instance { get; private set; }

        private void Awake() {
            Instance = this;

            _intFactory = new ModelFactory<int>();
            _stringFactory = new ModelFactory<string>();
            _doubleFactory = new ModelFactory<double>();
        }

        public abstract void Init();

        public void RegisterView<T>(View<T> view) {
            switch (view) {
                case StringView sView:
                    if (_stringViews.ContainsKey(view.Guid)) return;
                    _stringViews.Add(sView.Guid, sView); 
                    break;
                case DoubleView dView:
                    if (_doubleViews.ContainsKey(view.Guid)) return;
                    _doubleViews.Add(dView.Guid, dView); 
                    break;
                case IntView iView:
                    if (_intViews.ContainsKey(view.Guid)) return;
                    _intViews.Add(iView.Guid, iView);
                    break;
            }

            SetHandler(view);
        }
        
        public void DeregisterView<T>(View<T> view) {
            switch (view) {
                case StringView sView:
                    if (!_stringViews.ContainsKey(view.Guid)) return;
                    _stringViews.Remove(sView.Guid); 
                    break;
                case DoubleView dView:
                    if (!_doubleViews.ContainsKey(view.Guid)) return;
                    _doubleViews.Remove(dView.Guid); 
                    break;
                case IntView iView:
                    if (!_intViews.ContainsKey(view.Guid)) return;
                    _intViews.Remove(iView.Guid);
                    break;
            }
        }

        protected abstract void SetHandler<T>(View<T> view);

        public abstract void WriteData<T>(ModelData<T> data);

        public void ReadData<T>(View<T> view) {
            switch (view) {
                case StringView sView:
                    if (_stringFactory.HasModel(view.Guid))
                        ReadData(sView, _stringViews, _stringFactory.GetModel(view.Guid));
                    break;
                case DoubleView dView:
                    if (_doubleFactory.HasModel(view.Guid))
                        ReadData(dView, _doubleViews, _doubleFactory.GetModel(view.Guid));
                    break;
                case IntView iView:
                    if (_intFactory.HasModel(view.Guid))
                        ReadData(iView, _intViews, _intFactory.GetModel(view.Guid));
                    break;
            }
        }

        private void ReadData<T, T2>(T view, Dictionary<string, T> dict, Model<T2> model) where T : View<T2> {
            if (!dict.ContainsKey(view.Guid)) RegisterView<T2>(view);
            view.SetValue(model.Value, model.Position);
            model.SetView(view);
        }
    }
}