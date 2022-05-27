using com.outrealxr.networkimages.Runtime;

namespace outrealxr.holomod
{
    public class BasicImageView : BasicLinkView
    {
        public NetworkImage networkImage;

        public override void Apply()
        {
            networkImage.SetAndEnqueue(((ImageModel)model).value);    
        }
    }
}