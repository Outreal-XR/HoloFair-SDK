namespace com.outrealxr.holomod
{
    public class LinkParser : StringParser
    {
        public LinkParser(LinkView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit("link");
        }
    }
}