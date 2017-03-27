using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Infrastructure;
using Assets.Sources.Models;
using Assets.Sources.ViewModels;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Views
{
    public class FaceBoxView:UnityGuiView<FaceBoxViewModel>
    {
        public Text nameText;
        public Text levelText;
        public Image faceImage;
        public BadgeView badgeView;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Binder.Add<string>("Name",OnNamePropertyVlaueChanged);
            Binder.Add<int>("Level",OnLevelPropertyValueChanged);
            Binder.Add<string>("Face",OnFacePropertyValueChanged);
            Binder.Add<Badge>("Badge",OnBadgePropertyValueChanged);
        }

        private void OnBadgePropertyValueChanged(Badge oldValue, Badge newValue)
        {
            badgeView.BindingContext = new BadgeViewModel() ;
            badgeView.BindingContext.Initialization(newValue);

        }

        private void OnLevelPropertyValueChanged(int oldValue, int newValue)
        {
            levelText.text = newValue.ToString("00");
        }

        private void OnFacePropertyValueChanged(string oldValue, string newValue)
        {
            var settings = GameObject.Find("UICamera").GetComponent<GlobalSettings>();
            var field = typeof(GlobalSettings).GetField(newValue);
            faceImage.sprite = field.GetValue(settings) as Sprite;
        }

        private void OnNamePropertyVlaueChanged(string oldValue, string newValue)
        {
            nameText.text = newValue;
        }
    }
}
