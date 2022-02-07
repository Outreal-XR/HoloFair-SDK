
namespace outrealxr.holomod
{
    public class OnStartHandler : ViewHandler
    {
        private void Start()
        {
            Handle();    
        }

        public override void Handle()
        {
            view.controller.Handle();
        }
    }
}