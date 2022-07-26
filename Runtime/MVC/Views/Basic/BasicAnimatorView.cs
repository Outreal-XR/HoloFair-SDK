namespace outrealxr.holomod
{
    public class BasicAnimatorView : View
    {
        public override void Apply()
        {
            AnimatorModel model = (AnimatorModel)this.model;
            model.animator.Play(model.stateName);
        }

        public override void Edit()
        {
            throw new System.NotImplementedException();
        }

        public void SetStateName(string val)
        {
            ((AnimatorModel)model).SetStateName(val);
            Write();
        }
    }
}