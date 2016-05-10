using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM.Sources.ViewModels;
using uMVVM.Sources.Views;
using UnityEngine;


namespace uMVVM.Sources
{
    public class Install:MonoBehaviour
    {
        // Use this for initialization
        public SetupView setupView;
        void Start()
        {
            //绑定上下文
            setupView.BindingContext=new SetupViewModel();
        }
    }
}
