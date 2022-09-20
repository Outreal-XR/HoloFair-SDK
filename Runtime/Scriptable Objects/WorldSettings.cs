using UnityEngine;

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

        public static WorldSettings instance;

        public string ScoreUpdateHostFormat = "{0}/users/score/update.php?uuid={2}";

        public void Init()
        {
            instance = this;
        }

        public string GetFormattedScoreUpdateHost()
        {
            return SmartStringSource.Instance.GetFormattedString(ScoreUpdateHostFormat, "n/a");
        }
    }
}