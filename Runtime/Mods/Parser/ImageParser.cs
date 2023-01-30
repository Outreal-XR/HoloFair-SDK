namespace com.outrealxr.holomod
{
    public class ImageParser : LinkParser
    {
        public ImageParser(ImageView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "image");
        }
    }
}