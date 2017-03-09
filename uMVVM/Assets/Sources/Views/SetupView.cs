
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.Models;
using uMVVM.Sources.ViewModels;
using UnityEngine.UI;

namespace uMVVM.Sources.Views
{
    public class SetupView:UnityGuiView
    {

        public InputField nameInputField;
        public Text nameMessageText;

        public InputField jobInputField;
        public Text jobMessageText;

        public InputField atkInputField;
        public Text atkMessageText;

        public Slider successRateSlider;
        public Text successRateMessageText;

        public Toggle joinToggle;
        public Button joinInButton;
        public Button waitButton;
        public SetupViewModel ViewModel { get { return (SetupViewModel)BindingContext; } }
        protected override void OnBindingContextChanged(ViewModel oldViewModel, ViewModel newViewModel)
        {

            base.OnBindingContextChanged(oldViewModel, newViewModel);

            SetupViewModel oldVm = oldViewModel as SetupViewModel;
            if (oldVm != null)
            {
                oldVm.Name.OnValueChanged -= NameValueChanged;
                oldVm.Job.OnValueChanged -= JobValueChanged;
                oldVm.ATK.OnValueChanged -= ATKValueChanged;
                oldVm.State.OnValueChanged -= StateValueChanged;
                oldVm.SuccessRate.OnValueChanged -= SuccessRateValueChanged;
            }
            if (ViewModel!=null)
            {
                ViewModel.Name.OnValueChanged += NameValueChanged;
                ViewModel.Job.OnValueChanged += JobValueChanged;
                ViewModel.ATK.OnValueChanged += ATKValueChanged;
                ViewModel.State.OnValueChanged += StateValueChanged;
                ViewModel.SuccessRate.OnValueChanged += SuccessRateValueChanged;
            }
            UpdateControls();
        }

        private void SuccessRateValueChanged(float oldvalue, float newvalue)
        {
            successRateMessageText.text = newvalue.ToString();
        }

        private void ATKValueChanged(int oldValue, int newValue)
        {
            atkMessageText.text = newValue.ToString();
        }

        private void JobValueChanged(string oldvalue, string newvalue)
        {
            jobMessageText.text = newvalue.ToString();
        }

        private void NameValueChanged(string oldvalue, string newvalue)
        {
            nameMessageText.text = newvalue.ToString();
        }
        private void StateValueChanged(State oldvalue, State newvalue)
        {
            switch (newvalue)
            {
                case State.JoinIn:
                    joinInButton.interactable = true;
                    waitButton.interactable = false;
                    break;
                case State.Wait:
                    joinInButton.interactable = false;
                    waitButton.interactable = true;
                    break;
            }
        }

        public void iptName_ValueChanged()
        {
            ViewModel.Name.Value = nameInputField.text;
        }

        public void iptJob_ValueChanged()
        {
            ViewModel.Job.Value = jobInputField.text;
        }

        public void iptATK_ValueChanged()
        {
            int result;
            if (int.TryParse(atkInputField.text,out result))
            {
                ViewModel.ATK.Value = int.Parse(atkInputField.text);
            }
        }

        public void sliderSuccessRate_ValueChanged()
        {
            ViewModel.SuccessRate.Value = successRateSlider.value;
        }

        public void toggle_ValueChanged()
        {
            if (joinToggle.isOn)
            {
                ViewModel.State.Value = State.JoinIn;
            }
            else
            {
                ViewModel.State.Value = State.Wait;
            }
        }

        private void UpdateControls()
        {
            joinToggle.isOn = false;
        }

        public void JoinInBattleTeam()
        {
            ViewModel.JoininCurrentTeam();
        }

        public void JoinInClan()
        {
            ViewModel.JoininClan();
        }
    }
}
