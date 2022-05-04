using UnityEngine;
using UnityEngine.AddressableAssets;

namespace outrealxr.holomod
{
    /// <summary>
    /// Make sure the asset is in addressables and named WorldSettings
    /// </summary>
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "HoloFairSDK/Create WorldSettings", order = 1)]
    public class WorldSettings : ScriptableObject
    {
        [Tooltip("Must be scene")]
        public AssetReference entryScene;
        public GameObject sceneZonesPrefab;
        public int maxVariables = 15, maxUsers = 2000, maxSpectators = 0;
        public Vector3 AreaofInterest;
    }
}