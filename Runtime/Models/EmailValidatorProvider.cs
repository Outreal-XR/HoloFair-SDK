using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class EmailValidatorProvider : Provider
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

        public override string ModKey => "emailValidator";

        public override string providerType => GetType().Name;

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override JObject ToJObject()
        {
            return new JObject()
            {
                {"mustContain", mustContain}
            };
        }

        public override void FromJObject(JObject data)
        {
            mustContain = data.GetValue("mustContain").Value<string>();
        }
    }
}