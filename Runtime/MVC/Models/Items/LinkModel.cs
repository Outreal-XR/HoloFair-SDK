using UnityEngine;

namespace outrealxr.holomod
{
    public class LinkModel : StringModel
    {
        public override string type => "link";
        [Tooltip("Optional")]
        public AnalyticsModel analytics;

    }
}