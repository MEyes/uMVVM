using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.ViewModels;
using Assets.Sources.Views;
using uMVVM.Sources.ViewModels;
using uMVVM.Sources.Views;
using UnityEngine;


namespace uMVVM.Sources
{
    public class Install:MonoBehaviour
    {
        // Use this for initialization
        public SetupView setupView;
        public TestView testView;
        void Start()
        {
            //绑定上下文
            setupView.BindingContext=new SetupViewModel();
            testView.BindingContext=new TestViewModel();
            //以动画模式缓慢显示
            setupView.Reveal(false, () =>
            {
                Debug.Log("测试");
            });
            //立刻显示
            testView.Reveal(true);
        }
    }
}
