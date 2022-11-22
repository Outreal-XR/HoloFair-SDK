using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    [NodeTint("#F89880")]
    public class PostRequestHandlerNode : WebRequestHandlerNode
    {
        [Input(dynamicPortList = true)] public List<NodeConnection> InputVars = new ();

        public override void Execute() {
            var formData = new WWWForm();

            var inputVars = GetInputValues<NodeConnection>("InputVars");
            foreach (var inputVar in inputVars) {
                var value = inputVar.Variable.Serialize().ToString();
                var keyName = inputVar.Variable.name;
                formData.AddField(keyName, value);
            }

            var request = UnityWebRequest.Post(url, formData);
        
            request.SendWebRequest().completed += _ => OnPostRequestCompleted(request);
        }
    
        private void OnPostRequestCompleted(UnityWebRequest request) {
            try {
                if (request.result == UnityWebRequest.Result.Success) {
                    var jToken = JToken.Parse(request.downloadHandler.text);

                    var outputVars = GetOutputPort("OutputVars").GetConnections();
                    foreach (var outputVar in outputVars)
                        if (outputVar.node is VariableNode varNode)
                            varNode.Parse(jToken);
                    OnSuccess?.Invoke();
                } else {
                    OnFail?.Invoke();
                    Debug.LogWarning(request.error);
                }
            } finally {
                request.Dispose();
            }
        }
    }
}