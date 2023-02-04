namespace com.outrealxr.holomod
{
    public class AnalyticsView : StringView
    {
        public void RecordImmediate()
        {
            Analytics.instance.RecordImmediate(this, GetValue);
        }

        public void RecordStart()
        {
            Analytics.instance.RecordStart(this, GetValue);
        }

        public void RecordEnd()
        {
            Analytics.instance.RecordEnd(this, GetValue);
        }
    }
}