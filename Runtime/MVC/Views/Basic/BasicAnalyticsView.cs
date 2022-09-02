using SaG.GuidReferences;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicAnalyticsView : View
    {
        public void RecordAction(GuidComponent guidComponent, int action) {
            (model as AnalyticsModel)?.SendData(guidComponent.GetStringGuid(), action); 
        }

        public override void Apply() {
            
        }

        public override void Edit() {
            
        }
    }
}