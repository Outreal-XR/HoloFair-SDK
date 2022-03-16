using Newtonsoft.Json.Linq;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class EmailValidatorProvider : Provider
    {

        public enum State
        {
            Idle = 0,
            NewValidAccountDetailsRequired = 1,
            VerificationCodeSent = 2,
            Waiting = 3
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
        public GameObject Loading;
        public CanvasGroup canvasGroup;
        public TMPro.TextMeshProUGUI timeLeftText, errorText;
        public TMPro.TMP_InputField EmailInputField, PasswordInputField, VerificationCodeInputField;
        public UnityEngine.UI.Button CreateAccountButton, VerifyAccountButton;

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
            if (state != State.Waiting) Form.SetActive(state != State.Idle);
            canvasGroup.interactable = state != State.Waiting;
            EmailInputField.interactable = state == State.NewValidAccountDetailsRequired;
            PasswordInputField.interactable = EmailInputField.interactable;
            if(state != State.Waiting) VerificationCodeInputField.gameObject.SetActive(state == State.VerificationCodeSent);
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
            if (state == State.NewValidAccountDetailsRequired)
            {
                CreateAccountButton.interactable = timeLeft <= 0 && !string.IsNullOrWhiteSpace(InputEmail) && InputEmail.Contains("@") && !string.IsNullOrWhiteSpace(InputPassword);
            }
            else if (state == State.VerificationCodeSent)
            {
                VerifyAccountButton.interactable = timeLeft <= 0 && !string.IsNullOrWhiteSpace(VerificationCode);
            }
            else
            {
                CreateAccountButton.interactable = false;
                VerifyAccountButton.interactable = false;
            }
        }

        public void SetCode(string val)
        {
            VerificationCode = val.Trim();
            UpdateAccountButtonState();
        }

        public override string ModKey => "emailValidator";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data) { }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            return new JObject();
        }
    }
}