using UnityEngine;
using UnityEngine.Rendering;

namespace outrealxr.holomod
{
    /// <summary>
    /// Make sure the asset is in addressables and named WorldSettings
    /// </summary>
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "HoloFairSDK/Create WorldSettings", order = 1)]
    public class WorldSettings : ScriptableObject
    {
        public GameObject sceneZonesPrefab;
        public int maxVariables = 15, maxUsers = 2000, maxSpectators = 0;
        public Vector3 AreaofInterest;
        public bool unverifiedUsersAllowed = true;
        public RenderPipelineAsset lowestSettings;
        public RenderPipelineAsset defaultSettings;
        public RenderPipelineAsset mediumSettings;
        public RenderPipelineAsset highestSettings;

        [SerializeField] private TextAsset _packageJson;
        [SerializeField] private string _jsonText;
        
        public string ScoreUpdateHostFormat = "{0}/users/score/update.php?uuid={2}";
        public string InteractionsHistoryPathFormat = "{0}/interactions/create.php?uuid={2}";

        public string PackageJsonText => _jsonText;

        private void OnValidate() {
            if (_packageJson != null) _jsonText = _packageJson.text;
        }
        
        public void Init()
        {
        }

        public string GetFormattedScoreUpdateHost()
        {
            return SmartStringSource.Instance.GetFormattedString(ScoreUpdateHostFormat, "n/a");
        }

        public string GetFormattedInteractionsHistoryPath()
        {
            return SmartStringSource.Instance.GetFormattedString(InteractionsHistoryPathFormat, "n/a");
        }
    }
}