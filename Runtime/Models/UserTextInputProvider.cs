using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class UserTextInputProvider : Provider
    {

        public string InputName, Title, Description;

        public override string ModKey => "textInput";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            InputName = data.GetValue("InputName").Value<string>();
            Title = data.GetValue("Title").Value<string>();
            Description = data.GetValue("Description").Value<string>();
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            JObject data = new JObject
            {
               new JProperty ("InputName", InputName ),
               new JProperty ("Title", Title ),
               new JProperty ("Description", Description )
            };
            return data;
        }
    }
}