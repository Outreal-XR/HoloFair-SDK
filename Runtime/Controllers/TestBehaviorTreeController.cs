namespace outrealxr.holomod
{
    public class TestBehaviorTreeController : Controller
    {

        BehaviorTreeProvider behaviorTreeProvider;

        public override void Handle()
        {
            if (behaviorTreeProvider == null) behaviorTreeProvider = GetComponentInParent<BehaviorTreeProvider>();
            behaviorTreeProvider.tree.EnableBehavior();
        }

        public override void Sync()
        {
            model.FromJObject(model.ToJObject());
        }

        public override void Read()
        {
            model.FromJObject(model.ToJObject());
        }

        public override void ReadForAll()
        {
            model.FromJObject(model.ToJObject());
        }
    }
}