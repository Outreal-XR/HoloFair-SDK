namespace outrealxr.holomod.Runtime
{
    public abstract class BasicScoreController : Controller
    {
        public override void Handle() { }

        public abstract void AddScore(float score);

        public abstract void Save();
    }
}