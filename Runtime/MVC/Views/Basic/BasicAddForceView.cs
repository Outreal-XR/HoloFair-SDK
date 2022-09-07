namespace outrealxr.holomod
{
    public class BasicAddForceView : View
    {
        private AddForceModel ForceModel => model as AddForceModel;
        
        public override void Apply() {
            ForceModel.playerRb.AddForce(transform.up * ForceModel.force, ForceModel.forceMode);
        }

        public override void Edit() {
            throw new System.NotImplementedException();
        }
    }
}