namespace com.outrealxr.holomod
{
    public class VideoParser : ImageParser
    {
        public VideoParser(VideoView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit("video");
        }
    }
}