using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicRespawnView : View
    {
        public override void Apply()
        {
            Debug.Log("[BasicRespawnView] No apply logic is available for this view. Just call View.Handle() to respawn a player");
        }

        public override void Edit()
        {
            Debug.Log("[BasicRespawnView] No edit logic is available for this view. Just call View.Handle() to respawn a player");
        }
    }
}