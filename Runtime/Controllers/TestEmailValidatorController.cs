using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestEmailValidatorController : Controller
    {
        EmailValidatorProvider provider;
        public bool IsEmailValid;

        public override void Handle()
        {
            if (provider == null) provider = (EmailValidatorProvider)model.provider;
            foreach (var validator in FindObjectsOfType<EmailValidatorProvider>())
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
            provider.SetState(IsEmailValid ? EmailValidatorProvider.State.Idle : EmailValidatorProvider.State.WaitingForUserEmail);
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

        public override void Sync()
        {
            throw new System.NotImplementedException();
        }
    }
}