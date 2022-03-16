using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestEmailValidatorController : Controller
    {

        EmailValidatorProvider provider;
        public static bool IsEmailValid;
        public string loginError = "Invalid credentials", createError = "Email is already taken", verifyError = "Invalid verification code";
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
            switch(provider.state)
            {
                case EmailValidatorProvider.State.Idle:
                    provider.SetState(EmailValidatorProvider.State.Choose);
                    break;
                case EmailValidatorProvider.State.Login:
                    SimulateLogin();
                    break;
                case EmailValidatorProvider.State.Create:
                    SimulateCreate();
                    break;
                case EmailValidatorProvider.State.Verify:
                    SimulateVerify();
                    break;
                default:
                    provider.SetState(EmailValidatorProvider.State.Choose);
                    break;
            }
        }

        void SimulateLogin()
        {
            StartCoroutine(Login());
        }

        IEnumerator Login()
        {
            provider.SetState(EmailValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(loginError))
            {
                provider.SetState(EmailValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(EmailValidatorProvider.State.Login);
                provider.errorText.text = loginError;
                loginError = "";
                provider.IncrementTimeLeft();
            }
        }

        void SimulateCreate()
        {
            StartCoroutine(CreateAccount());
        }

        IEnumerator CreateAccount()
        {
            provider.SetState(EmailValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if(string.IsNullOrWhiteSpace(createError))
            {
                provider.SetState(EmailValidatorProvider.State.Verify);
                provider.OnVerifcationSent.Invoke();
            }
            else
            {
                provider.SetState(EmailValidatorProvider.State.Create);
                provider.errorText.text = createError;
                createError = "";
                provider.IncrementTimeLeft();
            }
        }

        void SimulateVerify()
        {
            StartCoroutine(VerifyAccount());
        }

        IEnumerator VerifyAccount()
        {
            provider.SetState(EmailValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(verifyError))
            {
                provider.SetState(EmailValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(EmailValidatorProvider.State.Verify);
                provider.errorText.text = verifyError;
                verifyError = "";
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