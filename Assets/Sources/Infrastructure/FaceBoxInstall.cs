using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.ViewModels;
using Assets.Sources.Views;
using uMVVM.Sources.ViewModels;
using uMVVM.Sources.Views;
using UnityEngine;

namespace Assets.Sources.Infrastructure
{
    public class FaceBoxInstall : MonoBehaviour
    {
      
        public FaceBoxView FaceBoxView;
        void Start()
        {
            //绑定上下文
            FaceBoxView.BindingContext = new FaceBoxViewModel();
            //立刻显示
            FaceBoxView.Reveal();
        }
    }
}
