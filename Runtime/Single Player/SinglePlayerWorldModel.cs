using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class SinglePlayerWorldModel : MonoBehaviour
    {
        public List<Controller> _controllers;
        public string TagUsedForGrouping = "Area";
        
        private void Start()
        {
            Debug.Log($"[WorldModel] Preparing world");
            var models = FindObjectsOfType<Model>();
            
            foreach (var model in models)
            {
                Controller controllerPrefab;
                try {
                    controllerPrefab = GetControllerByName(model.provider.ModKey);
                }
                catch (System.Exception) {
                    Debug.Log($"[WorldModel] Failed to get controller for view of model {model}");
                    break;
                }

                if (!controllerPrefab) continue;

                var controller = Instantiate(controllerPrefab, model.transform, true);

                controller.transform.localPosition = Vector3.zero;
                controller.transform.localRotation = Quaternion.identity;
                try {
                    model.view.SetController(controller);
                }
                catch (System.Exception) {
                    Debug.Log($"[WorldModel] Failed to set controller {controller} to view of model {model}");
                }
                
            }
        }
        
        private string GetModelName(GameObject gameObject)
        {
            return (gameObject.transform.parent != null && gameObject.transform.parent.CompareTag(TagUsedForGrouping) ? gameObject.transform.parent.name + "/" : "") + gameObject.name;
        }

        private Controller GetControllerByName(string name)
        {
            foreach (var controller in _controllers.Where(controller => controller.name == name))
                return controller;
            Debug.Log($"[WorldModel] missing controller {name}. Check list: " + string.Join(",", _controllers));
            return null;
        }
    }
}
