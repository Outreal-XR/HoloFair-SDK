using UnityEngine;

namespace com.outrealxr.holomod
{
    public class LightProbesAutoTetrahedralize : MonoBehaviour
    {
        [Tooltip("Optional. It is set to true when tetrahedralization is started and false when complete.")]
        public GameObject loading;
        public bool async = true;

        private void Awake()
        {
            Debug.Log("[LightProbesAutoTetrahedralize] Preparing");
            if(loading) loading.SetActive(false);
            LightProbes.needsRetetrahedralization += StartTetrahedralize;
            LightProbes.tetrahedralizationCompleted += EndTetrahedralizeAsync;
            Debug.Log("[LightProbesAutoTetrahedralize] Ready");
        }

        void StartTetrahedralize()
        {
            Debug.Log("[LightProbesAutoTetrahedralize] Starting async = " + async);
            if (loading) loading.SetActive(true);
            if (async) LightProbes.TetrahedralizeAsync();
            else LightProbes.Tetrahedralize();
            Debug.Log("[LightProbesAutoTetrahedralize] Started async = " + async);
        }

        void EndTetrahedralizeAsync()
        {
            Debug.Log("[LightProbesAutoTetrahedralize] Finishing");
            if (loading) loading.SetActive(false);
            Debug.Log("[LightProbesAutoTetrahedralize] Finished");
        }

        private void OnDestroy()
        {
            Debug.Log("[LightProbesAutoTetrahedralize] Destroying");
            LightProbes.needsRetetrahedralization -= StartTetrahedralize;
            LightProbes.tetrahedralizationCompleted -= EndTetrahedralizeAsync;
            Debug.Log("[LightProbesAutoTetrahedralize] Destroyed");
        }
    }
}