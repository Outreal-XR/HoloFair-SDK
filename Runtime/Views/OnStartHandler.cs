
namespace outrealxr.holomod
{
    public class OnStartHandler : ViewHandler
    {
        public override void Handle()
        {
            view.controller.Handle();
        }
    }
}