using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace uMVVM.Sources.Infrastructure
{
    public class UnityGuiView:MonoBehaviour,IView
    {
        public readonly BindableProperty<ViewModel> ViewModelProperty = new BindableProperty<ViewModel>();
        public ViewModel BindingContext
        {
            get { return ViewModelProperty.Value; }
            set { ViewModelProperty.Value = value; }
        }

        protected virtual void OnBindingContextChanged(ViewModel oldViewModel, ViewModel newViewModel)
        {
        }

        public UnityGuiView()
        {
            this.ViewModelProperty.OnValueChanged += OnBindingContextChanged;
        }

    }
}
