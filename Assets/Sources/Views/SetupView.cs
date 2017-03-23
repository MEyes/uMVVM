
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.Models;
using uMVVM.Sources.ViewModels;
using UnityEngine.UI;

namespace uMVVM.Sources.Views
{
    public class SetupView:UnityGuiView<SetupViewModel>
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

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Binder.Add<string>("Name", OnNamePropertyValueChanged);
            Binder.Add<string>("Job",OnJobPropertyValueChanged);
            Binder.Add<int>("ATK",OnATKPropertyValueChanged);
            Binder.Add<float>("SuccessRate",OnSuccessRatePropertyValueChanged);
            Binder.Add<State>("State",OnStatePropertyValueChanged);

        }


        private void OnSuccessRatePropertyValueChanged(float oldValue, float newValue)
        {
            successRateMessageText.text = newValue.ToString("F2");
        }

        private void OnATKPropertyValueChanged(int oldValue, int newValue)
        {
            atkMessageText.text = newValue.ToString();
        }

        private void OnJobPropertyValueChanged(string oldValue, string newValue)
        {
            jobMessageText.text = newValue.ToString();
        }

        private void OnNamePropertyValueChanged(string oldValue, string newValue)
        {
            nameMessageText.text = newValue.ToString();
        }
        private void OnStatePropertyValueChanged(State oldValue, State newValue)
        {
            switch (newValue)
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
