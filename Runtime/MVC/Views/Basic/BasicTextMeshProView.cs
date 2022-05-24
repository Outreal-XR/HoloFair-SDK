 namespace outrealxr.holomod
{
    public class BasicTextMeshProView : View
    {
        public TMPro.TextMeshPro textMeshPro;

        public override void Apply()
        {
            textMeshPro.text = ((TextMeshProModel)model).value;
        }

        public override void Edit()
        {
            throw new System.NotImplementedException();
        }
    }
}