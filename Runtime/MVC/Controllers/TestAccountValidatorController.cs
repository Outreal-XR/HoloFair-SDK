using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class TestAccountValidatorController : Controller
    {

        AccountValidatorModel provider;
        public static bool IsEmailValid;
        public string loginError = "Invalid credentials", createError = "Email is already taken", verifyError = "Invalid verification code";
        public float minTimeToRespond = 0.1f, maxTimeToRespawn = 1.1f;

        public override void Handle()
        {
            if (IsEmailValid)
            {
                provider.SetState(AccountValidatorModel.State.Idle);
                provider.OnEmailValid.Invoke();
                return;
            }
            if (provider == null) provider = (AccountValidatorModel)model;
            switch (provider.state)
            {
                case AccountValidatorModel.State.Idle:
                    provider.SetState(AccountValidatorModel.State.Choose);
                    break;
                case AccountValidatorModel.State.Login:
                    SimulateLogin();
                    break;
                case AccountValidatorModel.State.Create:
                    SimulateCreate();
                    break;
                case AccountValidatorModel.State.Verify:
                    SimulateVerify();
                    break;
                default:
                    provider.SetState(AccountValidatorModel.State.Choose);
                    break;
            }
        }

        void SimulateLogin()
        {
            StartCoroutine(Login());
        }

        IEnumerator Login()
        {
            provider.SetState(AccountValidatorModel.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(loginError))
            {
                provider.SetState(AccountValidatorModel.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(AccountValidatorModel.State.Login);
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
            provider.SetState(AccountValidatorModel.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(createError))
            {
                provider.SetState(AccountValidatorModel.State.Verify);
                provider.OnVerifcationSent.Invoke();
            }
            else
            {
                provider.SetState(AccountValidatorModel.State.Create);
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
            provider.SetState(AccountValidatorModel.State.Waiting);
            yield return new WaitForSeconds(Random.Range(minTimeToRespond, maxTimeToRespawn));
            if (string.IsNullOrWhiteSpace(verifyError))
            {
                provider.SetState(AccountValidatorModel.State.Idle);
                provider.OnEmailValid.Invoke();
                IsEmailValid = true;
            }
            else
            {
                provider.SetState(AccountValidatorModel.State.Verify);
                provider.errorText.text = verifyError;
                verifyError = "";
                provider.IncrementTimeLeft();
            }
        }

        public override void Read()
        {
            throw new System.NotImplementedException();
        }

        public override void Write()
        {
            throw new System.NotImplementedException();
        }
    }
}