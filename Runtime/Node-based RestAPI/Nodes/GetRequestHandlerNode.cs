using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
	[NodeTint("#7393B3")]
	public class GetRequestHandlerNode : WebRequestHandlerNode
	{
		public override void Execute() {
			var request = new UnityWebRequest(url);

			request.downloadHandler = new DownloadHandlerBuffer();
			request.SendWebRequest().completed += _ => OnGetRequestCompleted(request);
		}

		private void OnGetRequestCompleted(UnityWebRequest request) {
			try {
				if (request.result == UnityWebRequest.Result.Success) {
					var jToken = JToken.Parse(request.downloadHandler.text);

					var outputVars = GetOutputPort("OutputVars").GetConnections();
					foreach (var outputVar in outputVars)
						if (outputVar.node is VariableNode varNode)
							varNode.Parse(jToken);

					OnSuccess?.Invoke();
				}
				else {
					OnFail?.Invoke();
					Debug.LogWarning(request.error);
				}
			}
			finally {
				request.Dispose();
			}
		}
	}
}