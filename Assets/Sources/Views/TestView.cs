using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.ViewModels;
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Views
{
    public class TestView:UnityGuiView<TestViewModel>
    {
        public Image buttonImage;
        public TestViewModel ViewModelBase { get { return (TestViewModel)BindingContext; } }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Binder.Add<string>("Color",OnColorPropertyValueChanged);
        }

        private void OnColorPropertyValueChanged(string oldValue, string newValue)
        {
            switch (newValue)
            {
                case "Red":
                    buttonImage.color = Color.red;
                    break;
                case "Yellow":
                    buttonImage.color = Color.yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
