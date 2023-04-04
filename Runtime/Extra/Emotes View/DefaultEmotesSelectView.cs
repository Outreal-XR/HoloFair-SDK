namespace com.outrealxr.holomod
{
    public class DefaultEmotesSelectView : EmotesSelectView
    {
        private void Awake() {
            DefaultView = this;
            gameObject.SetActive(false);
        }
    }
}
