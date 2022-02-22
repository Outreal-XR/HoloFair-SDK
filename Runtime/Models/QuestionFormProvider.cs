using Newtonsoft.Json.Linq;

namespace outrealxr.holomod
{
    public class QuestionFormProvider : Provider
    {
        public override string ModKey => "questionForm";
        public override string providerType => GetType().Name;

        public override void SetIsDirty(bool val) => isDirty = val;

        public override bool IsDirty() => isDirty;

        public override JObject ToJObject() {
            return new JObject();
        }

        public override void FromJObject(JObject data) {
        }

    }
}