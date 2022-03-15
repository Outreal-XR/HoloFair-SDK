namespace outrealxr.holomod
{
    public class SPAnimatorController : Controller
    {
        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            SetModel(GetComponentInParent<Model>());
        }

        public void SetModel(Model model)
        {
            this.model = model;
        }

        public override void Handle()
        {
            
        }

        public override void Sync()
        {
            
        }

        public void Restart()
        {
            var animatorProvider = (AnimatorProvider)model.provider;
            animatorProvider.startTime = 0;
        }

        public override void Read()
        {
        }

        public override void ReadForAll()
        {
        }
    }
}
