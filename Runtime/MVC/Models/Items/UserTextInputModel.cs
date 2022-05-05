using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class UserTextInputModel : Model
    {

        public string InputName, Title, Description;

        public override string type => "textInput";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            InputName = data.GetValue("InputName").Value<string>();
            Title = data.GetValue("Title").Value<string>();
            Description = data.GetValue("Description").Value<string>();
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject
            {
               new JProperty ("InputName", InputName ),
               new JProperty ("Title", Title ),
               new JProperty ("Description", Description )
            });
            return data;
        }
    }
}