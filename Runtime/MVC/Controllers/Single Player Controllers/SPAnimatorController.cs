namespace outrealxr.holomod
{
    public class SPAnimatorController : Controller
    {
        public override void Handle()
        {
            
        }

        public void Restart()
        {
            var animatorProvider = (AnimatorModel)model;
            animatorProvider.startTime = 0;
        }
    }
}
