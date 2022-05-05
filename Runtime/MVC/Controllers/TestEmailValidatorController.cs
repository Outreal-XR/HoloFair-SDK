using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestEmailValidatorController : Controller
    {
        EmailValidatorModel provider;
        public bool IsEmailValid;

        public override void Handle()
        {
            if (provider == null) provider = (EmailValidatorModel)model;
            foreach (var validator in FindObjectsOfType<EmailValidatorModel>())
            {
                if (IsEmailValid)
                {
                    validator.OnEmailValid.Invoke();
                }
                else
                {
                    validator.OnEmailInvalid.Invoke();
                }
            }
            provider.SetState(IsEmailValid ? EmailValidatorModel.State.Idle : EmailValidatorModel.State.WaitingForUserEmail);
            IsEmailValid = true;
        }

        public override void Read()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadForAll()
        {
            throw new System.NotImplementedException();
        }

        public override void Write()
        {
            throw new System.NotImplementedException();
        }
    }
}