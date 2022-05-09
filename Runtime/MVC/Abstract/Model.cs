using UnityEngine;
using Newtonsoft.Json.Linq;
using SaG.GuidReferences;

namespace outrealxr.holomod
{
    [RequireComponent(typeof(GuidComponent))]
    public abstract class Model: MonoBehaviour
    {
        public int MMOItemID = -1;
        string guid;
        [Tooltip("Addressable Path to a GameObject (Optional)")]
        public string Addressable;
        public View view;
        public bool reportMissingKeys;

        public abstract string type { get; }

        void Start()
        {
            view.model = this;
            guid = GetComponent<GuidComponent>().GetStringGuid();
            WorldModel.instance.CreateData(guid);
        }

        public void SetMMOItemID(int val)
        {
            MMOItemID = val;
        }

        public void Apply()
        {
            view.Apply();
        }

        public virtual JObject ToJObject()
        {
            var data = transform.ToJObject();
            data.Add(new JProperty("type", type));
            data.Add(new JProperty("guid", guid));
            if (!string.IsNullOrWhiteSpace(Addressable)) data.Add(new JProperty("Addressable", Addressable));
            return data;
        }

        public virtual void FromJObject(JObject data)
        {
            data.ToTransform(this);
            if (data.ContainsKey("Addressable")) Addressable = data.GetValue("Addressable").Value<string>();
            else if(reportMissingKeys) Debug.Log("[Model] Missing Addressable key");
        }
    }
}