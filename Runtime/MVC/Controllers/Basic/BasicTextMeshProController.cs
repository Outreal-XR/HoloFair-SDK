namespace outrealxr.holomod
{
    public class BasicTextMeshProController : Controller
    {
        public override void Handle()
        {
            model.Apply();
        }

        public override void Read()
        {
            model.FromJObject(WorldModel.instance.ReadData(model.MMOItemID));
        }

        public override void ReadForAll()
        {
            throw new System.NotImplementedException();
        }

        public override void Write()
        {
            WorldModel.instance.WriteData(model.MMOItemID, model.ToJObject());
        }
    }
}