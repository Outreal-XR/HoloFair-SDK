using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestAccountValidatorController : Controller
    {

        AccountValidatorProvider provider;
        public static bool IsEmailValid;
        public string loginError = "Invalid credentials", createError = "Email is already taken", verifyError = "Invalid verification code";
        public float minTimeToRespond = 0.1f, maxTimeToRespawn = 1.1f;

        public override void Handle()
        {
            if (IsEmailValid)
            {
                provider.SetState(AccountValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                return;
            }
            if (provider == null) provider = (AccountValidatorProvider)model.provider;
            switch (provider.state)
            {
                case AccountValidatorProvider.State.Idle:
                    provider.SetState(AccountValidatorProvider.State.Choose);
                    break;
                case AccountValidatorProvider.State.Login:
                    SimulateLogin();
                    break;
                case AccountValidatorProvider.State.Create:
                    SimulateCreate();
                    break;
                case AccountValidatorProvider.State.Verify:
                    SimulateVerify();
                    break;
                default:
                    provider.SetState(AccountValidatorProvider.State.Choose);
                    break;
            }
        }

        void SimulateLogin()
        {
            StartCoroutine(Login());
        }

        IEnumerator Login()
        {
            provider.SetState(AccountValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(loginError))
            {
                provider.SetState(AccountValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(AccountValidatorProvider.State.Login);
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
            provider.SetState(AccountValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(createError))
            {
                provider.SetState(AccountValidatorProvider.State.Verify);
                provider.OnVerifcationSent.Invoke();
            }
            else
            {
                provider.SetState(AccountValidatorProvider.State.Create);
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
            provider.SetState(AccountValidatorProvider.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(verifyError))
            {
                provider.SetState(AccountValidatorProvider.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(AccountValidatorProvider.State.Verify);
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