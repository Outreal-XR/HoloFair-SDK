using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class EmailValidatorModel : Model
    {
        public enum State
        {
            Idle = 0,
            WaitingForUserEmail = 1
        }

        State state;
        public GameObject form;
        public TMPro.TMP_InputField emailInput;
        public UnityEngine.UI.Button button;
        public string mustContain = "@";
        public UnityEvent OnEmailInvalid, OnEmailValid;

        private void Start()
        {
            SetState(State.Idle);
        }

        public void SetState(int val)
        {
            SetState((State) val);
        }

        public void SetState(State val)
        {
            state = val;
            form.SetActive(state == State.WaitingForUserEmail);
            OnChange(emailInput.text);
        }

        public void OnChange(string val)
        {
            if(string.IsNullOrWhiteSpace(mustContain)) button.interactable = !string.IsNullOrWhiteSpace(val);
            else button.interactable = !string.IsNullOrWhiteSpace(val) && val.Contains(mustContain);
        }

        public override string type => "emailValidator";

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Merge(new JObject()
            {
                {"mustContain", mustContain}
            });
            return data;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            mustContain = data.GetValue("mustContain").Value<string>();
        }
    }
}