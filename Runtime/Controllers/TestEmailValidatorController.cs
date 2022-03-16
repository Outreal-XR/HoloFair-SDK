using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestEmailValidatorController : Controller
    {

        EmailValidatorProvider provider;
        public bool IsEmailValid;
        public string accountCreationError, accountVerificationError;
        public float minTimeToRespond = 0.1f, maxTimeToRespawn = 1.1f;

        public override void Handle()
        {
            if (IsEmailValid)
            {
                provider.SetState(EmailValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                return;
            }
            if (provider == null) provider = (EmailValidatorProvider) model.provider;
            if (provider.state == EmailValidatorProvider.State.Idle)
            {
                provider.SetState(EmailValidatorProvider.State.NewValidAccountDetailsRequired);
                provider.OnEmailInvalid.Invoke();
            }
            else if (provider.state == EmailValidatorProvider.State.NewValidAccountDetailsRequired)
            {
                SimulateAccountCreation();
            }
            else if(provider.state == EmailValidatorProvider.State.VerificationCodeSent)
            {
                SimulateAccountVerification();
            }
        }

        void SimulateAccountCreation()
        {
            StartCoroutine(CreateAccount());
        }

        IEnumerator CreateAccount()
        {
            provider.SetState(EmailValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if(string.IsNullOrWhiteSpace(accountCreationError))
            {
                provider.SetState(EmailValidatorProvider.State.VerificationCodeSent);
                provider.OnVerifcationSent.Invoke();
            }
            else
            {
                provider.SetState(EmailValidatorProvider.State.NewValidAccountDetailsRequired);
                provider.errorText.text = accountCreationError;
                accountCreationError = "";
                provider.IncrementTimeLeft();
            }
        }

        void SimulateAccountVerification()
        {
            StartCoroutine(VerifyAccount());
        }

        IEnumerator VerifyAccount()
        {
            provider.SetState(EmailValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(accountVerificationError))
            {
                provider.SetState(EmailValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(EmailValidatorProvider.State.VerificationCodeSent);
                provider.errorText.text = accountVerificationError;
                accountVerificationError = "";
                provider.IncrementTimeLeft();
            }
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