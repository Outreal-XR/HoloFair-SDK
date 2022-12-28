using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ModelFactory<T>
    {
        private readonly Dictionary<string, Model<T>> _models = new();

        public void AddModel(ModelData<T> data) {
            if (!_models.ContainsKey(data.Id)) {
                var model = new Model<T>(data);
                _models.Add(model.Id, model);
            } else
                WriteData(data);
        }

        public void WriteData(ModelData<T> data) {
            if (_models.TryGetValue(data.Id, out var model)) 
                model.SetValue(data.Position, data.Value);
            else 
                Debug.LogWarning("[ModelFactory] No model with given GUID found.");
        }

        public bool HasModel(string guid) => _models.ContainsKey(guid);

        public Model<T> GetModel(string guid) {
            if (_models.TryGetValue(guid, out var model))
                return model;
            Debug.LogWarning("[ModelFactory] No model with given GUID found.");
            return null;
        }
    }

    public struct ModelData<T> where T : notnull
    {
        public readonly string Id;
        public readonly Vector3 Position;
        public readonly T Value;

        public ModelData(T value, string id, Vector3 position) {
            Value = value;
            Position = position;
            Id = id;
        }
    }
}