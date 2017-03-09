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
    public class TestView:UnityGuiView
    {
        public Image buttonImage;
        public TestViewModel ViewModel { get { return (TestViewModel)BindingContext; } }
        protected override void OnBindingContextChanged(ViewModel oldViewModel, ViewModel newViewModel)
        {
            base.OnBindingContextChanged(oldViewModel, newViewModel);

            TestViewModel oldVm = oldViewModel as TestViewModel;
            if (oldVm != null)
            {
                ViewModel.Color.OnValueChanged -= OnColorPropertyValueChanged;
            }
            if (ViewModel != null)
            {
                ViewModel.Color.OnValueChanged += OnColorPropertyValueChanged;
            }
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
