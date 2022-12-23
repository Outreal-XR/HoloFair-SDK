using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class Factories : MonoBehaviour
    {
        protected ModelFactory<string> _stringFactory;
        protected ModelFactory<double> _doubleFactory;
        protected ModelFactory<int> _intFactory;

        protected readonly Dictionary<string, View> _views = new();
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

        public void RegisterView(View view) {
            if (_views.ContainsKey(view.ViewId)) return;
            _views.Add(view.ViewId, view);

            SetHandler(view);
        }
        
        public void RegisterView<T>(ViewT<T> view) {
            switch (view) {
                case StringView sView:
                    if (_stringViews.ContainsKey(view.ViewId)) return;
                    _stringViews.Add(sView.ViewId, sView); 
                    break;
                case DoubleView dView:
                    if (_doubleViews.ContainsKey(view.ViewId)) return;
                    _doubleViews.Add(dView.ViewId, dView); 
                    break;
                case IntView iView:
                    if (_intViews.ContainsKey(view.ViewId)) return;
                    _intViews.Add(iView.ViewId, iView);
                    break;
            }

            SetHandler(view);
        }
        
        
        protected void AddOrUpdateModel<T>(ModelFactory<T> modelFactory, T value, Vector3 position, string id) {
            var modelData = new ModelData<T>(value, id, position);

            if (!modelFactory.HasModel(id))
                modelFactory.AddModel(modelData);
            else
                modelFactory.WriteData(modelData);

            TryUpdateView(modelData);
        }

        private void TryUpdateView<T>(ModelData<T> data) {
            switch (data) {
                case ModelData<double> dData:
                    if (_doubleViews.ContainsKey(dData.Id))
                        _doubleViews[dData.Id].SetValue(dData.Value, dData.Position);
                    break;
                case ModelData<int> iData:
                    if (_intViews.ContainsKey(iData.Id))
                        _intViews[iData.Id].SetValue(iData.Value, iData.Position);
                    break;
                case ModelData<string> sData:
                    if (_stringViews.ContainsKey(sData.Id))
                        _stringViews[sData.Id].SetValue(sData.Value, sData.Position);
                    break;
            }
        }

        public void DeregisterView<T>(ViewT<T> view) {
            switch (view) {
                case StringView sView:
                    if (!_stringViews.ContainsKey(view.ViewId)) return;
                    _stringViews.Remove(sView.ViewId); 
                    break;
                case DoubleView dView:
                    if (!_doubleViews.ContainsKey(view.ViewId)) return;
                    _doubleViews.Remove(dView.ViewId); 
                    break;
                case IntView iView:
                    if (!_intViews.ContainsKey(view.ViewId)) return;
                    _intViews.Remove(iView.ViewId);
                    break;
            }
        }

        protected abstract void SetHandler(View view);

        public abstract void WriteData<T>(ModelData<T> data);

        public void ReadData<T>(ViewT<T> view) {
            switch (view) {
                case StringView sView:
                    if (_stringFactory.HasModel(view.ViewId))
                        ReadData(sView, _stringViews, _stringFactory.GetModel(view.ViewId));
                    break;
                case DoubleView dView:
                    if (_doubleFactory.HasModel(view.ViewId))
                        ReadData(dView, _doubleViews, _doubleFactory.GetModel(view.ViewId));
                    break;
                case IntView iView:
                    if (_intFactory.HasModel(view.ViewId))
                        ReadData(iView, _intViews, _intFactory.GetModel(view.ViewId));
                    break;
            }
        }

        private void ReadData<T, T2>(T view, IReadOnlyDictionary<string, T> dict, Model<T2> model) where T : ViewT<T2> {
            if (!dict.ContainsKey(view.ViewId)) RegisterView(view);
            view.SetValue(model.Value, model.Position);
            model.SetView(view);
        }
    }
}