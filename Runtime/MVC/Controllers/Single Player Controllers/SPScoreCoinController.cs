namespace outrealxr.holomod
{
    public class SPScoreCoinController : Controller
    {
        public override void Handle() {
            ((ScoreCoinModel)model).visual.SetActive(false);
        }
    }
}
