using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Infrastructure;
using uMVVM.Sources.Infrastructure;
using UnityEngine;

namespace Assets.Sources.ViewModels
{
    public class TestViewModel:ViewModel
    {
        public readonly BindableProperty<string> Color=new BindableProperty<string>();

        public TestViewModel()
        {
            EventAggregator<object>.Instance.SubscribeEvent("Toggle",ToggleHandler);
            Debug.Log("2");
        }

        private void ToggleHandler(object sender, EventArgs<object> args)
        {
            Color.Value = (string) args.Item;
        }
    }
}
