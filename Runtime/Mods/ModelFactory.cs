using System.Collections.Generic;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ModelFactory<T>
    {
        private readonly Dictionary<string, Model<T>> _models = new();

        public void AddModel(ModelData<T> data) {
            if (!_models.ContainsKey(data.Guid)) {
                var model = new Model<T>(data);
                
                _models.Add(model.Guid, model);
            } else
                WriteData(data);
        }

        public void WriteData(ModelData<T> data) {
            if (_models.TryGetValue(data.Guid, out var model)) 
                model.SetValue(data.Position, data.Value);
            
            Debug.LogWarning("[WorldModel] No model with given GUID found.");
        }

        public bool HasModel(string guid) => _models.ContainsKey(guid);

        public Model<T> GetModel(string guid) {
            if (_models.TryGetValue(guid, out var model))
                return model;

            Debug.LogWarning("[WorldModel] No model with given GUID found.");
            return null;
        }
    }

    public struct ModelData<T> where T : notnull
    {
        public string Guid;
        public Vector3 Position;
        public T Value;
        public bool Dynamic;

        public ModelData(T value, string guid, Vector3 position, bool dynamic = false) {
            Value = value;
            Position = position;
            Guid = guid;
            Dynamic = dynamic;
        }
    }
}