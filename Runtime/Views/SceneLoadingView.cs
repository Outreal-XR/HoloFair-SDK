using UnityEngine;

namespace outrealxr.holomod
{
    public class SceneLoadingView : MonoBehaviour
    {
        public string ProgressFormat = "Loading {0}: {1:P1}";
        public TMPro.TextMeshProUGUI ProgressText;
        public UnityEngine.UI.Image ProgressAmountImage;
        public GameObject LoadingView;

        public SceneController current;
        public static SceneLoadingView instance;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            ProgressAmountImage.fillAmount = current == null || !current.loadSceneAssetHandler.IsValid() ? 0 : current.loadSceneAssetHandler.PercentComplete;
            ProgressText.text = string.Format(ProgressFormat, SceneController.currentlyLoading, ProgressAmountImage.fillAmount);
        }
    }
}