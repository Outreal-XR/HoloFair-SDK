
namespace outrealxr.holomod
{
    public class OnClickHandler : ViewHandler
    {
        public override void Handle()
        {
            view.controller.Handle();
        }
    }
}