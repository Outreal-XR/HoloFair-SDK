using BehaviorDesigner.Runtime;

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
    }
}