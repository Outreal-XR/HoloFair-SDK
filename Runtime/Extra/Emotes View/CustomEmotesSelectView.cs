namespace com.outrealxr.holomod
{
    public class CustomEmotesSelectView : EmotesSelectView
    {
        private void Awake() {
            CustomView = this;
            gameObject.SetActive(false);
        }
    }
}
