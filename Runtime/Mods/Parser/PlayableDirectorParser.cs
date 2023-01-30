namespace com.outrealxr.holomod
{
    public class PlayableDirectorParser : DoubleParser
    {
        public PlayableDirectorParser(PlayableDirectorView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "playerDirector");
        }
    }
}