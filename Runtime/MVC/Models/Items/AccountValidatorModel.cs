using Newtonsoft.Json.Linq;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class AccountValidatorModel : Model
    {

        public enum State
        {
            Idle = 0,
            Choose = 1,
            Login = 2,
            Create = 3,
            Verify = 4,
            Waiting = 5
        }

        public State state;
        public View view;

        [Header("Behavior Data")]
        public float lastTimeToWait;
        [Tooltip("For testing feel free to change this variable")]
        public float timeLeft;
        public readonly float delay = 15;
        public string TimeRemaingFormat = "You can try again after ";

        [Header("User Data")]
        public string InputEmail;
        public string InputPassword;
        public string VerificationCode;

        [Header("UI")]
        public GameObject Form;
        public GameObject Step1, Step2;
        public GameObject Loading;
        public CanvasGroup canvasGroup;
        public TMPro.TextMeshProUGUI timeLeftText, errorText;
        public TMPro.TMP_InputField EmailInputField, PasswordInputField, VerificationCodeInputField;
        public UnityEngine.UI.Button LoginButton, CreateButton, VerifyButton;

        public UnityEvent OnEmailInvalid, OnVerifcationSent, OnErrorOccured, OnEmailValid;

        private void Awake()
        {
            EmailInputField.text = "";
            PasswordInputField.text = "";
            VerificationCodeInputField.text = "";
            errorText.text = "";

            InputEmail = "";
            InputPassword = "";
            VerificationCode = "";

            SetState(State.Idle);
        }

        private void Update()
        {
            if (timeLeft > 0)
            {
                timeLeft = Mathf.Clamp(timeLeft-Time.deltaTime, 0, 3599);
                timeLeftText.text = GetFormattedTimeRemaining();
                UpdateAccountButtonState();
            }
            timeLeftText.gameObject.SetActive(timeLeft > 0);
        }

        public void SetState(int val)
        {
            SetState((State)val);
        }

        public void SetState(State val)
        {
            if (state == State.Waiting && val == State.Idle) lastTimeToWait = delay;
            state = val;
            Loading.SetActive(state == State.Waiting);
            if (state != State.Waiting)
            {
                Form.SetActive(state != State.Idle);
                Step1.SetActive(state == State.Choose);
                Step2.SetActive(state != State.Choose);
                VerificationCodeInputField.gameObject.SetActive(state == State.Verify);
            }
            canvasGroup.interactable = state != State.Waiting;
            EmailInputField.interactable = state == State.Create || state == State.Login;
            PasswordInputField.interactable = EmailInputField.interactable;
            UpdateAccountButtonState();
        }

        public string GetFormattedTimeRemaining()
        {
            return $"{TimeRemaingFormat}{TimeSpan.FromSeconds(timeLeft):mm\\:ss}";
        }

        public void SetEmail(string val)
        {
            InputEmail = val.Trim();
            UpdateAccountButtonState();
        }

        public void SetPassword(string val)
        {
            InputPassword = val.Trim();
            UpdateAccountButtonState();
        }

        public void Next()
        {
            view.Handle();
        }

        public void IncrementTimeLeft()
        {
            timeLeft = lastTimeToWait + delay;
            lastTimeToWait = timeLeft;
        }
 
        void UpdateAccountButtonState()
        {
            if (state == State.Create || state == State.Login)
            {
                CreateButton.interactable = timeLeft <= 0 && !string.IsNullOrWhiteSpace(InputEmail) && InputEmail.Contains("@") && !string.IsNullOrWhiteSpace(InputPassword);
                LoginButton.interactable = CreateButton.interactable;
            }
            else if (state == State.Verify)
            {
                VerifyButton.interactable = timeLeft <= 0 && !string.IsNullOrWhiteSpace(VerificationCode);
            }
            else
            {
                CreateButton.interactable = false;
                VerifyButton.interactable = false;
                LoginButton.interactable = false;
            }
        }

        public void SetCode(string val)
        {
            VerificationCode = val.Trim();
            UpdateAccountButtonState();
        }

        public override string type => "accountValidator";
    }
}