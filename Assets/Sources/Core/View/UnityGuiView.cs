using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.DataBinding;
using UnityEngine;

namespace uMVVM.Sources.Infrastructure
{
    public class UnityGuiView<T>:MonoBehaviour,IView where T:ViewModelBase
    {
        private bool _isBindingContextInitialized;
        protected readonly PropertyBinder<T> Binder=new PropertyBinder<T>();
        public readonly BindableProperty<ViewModelBase> ViewModelProperty = new BindableProperty<ViewModelBase>();

        public ViewModelBase BindingContext
        {
            get { return ViewModelProperty.Value; }
            set
            {
                if (!_isBindingContextInitialized)
                {
                    OnInitialize();
                    _isBindingContextInitialized = true;
                }
                //触发OnValueChanged事件
                ViewModelProperty.Value = value;
            }
        }
        /// <summary>
        /// 初始化View，当BindingContext改变时执行
        /// </summary>
        protected virtual void OnInitialize()
        {
            //无所ViewModel的Value怎样变化，只对OnValueChanged事件监听(绑定)一次
            ViewModelProperty.OnValueChanged += OnBindingContextChanged;
        }
        /// <summary>
        /// 绑定的上下文发生改变时的响应方法
        /// 利用反射+=/-=OnValuePropertyChanged
        /// </summary>
        private void OnBindingContextChanged(ViewModelBase oldvalue, ViewModelBase newvalue)
        {
            Binder.Unbind((T)oldvalue);
            Binder.Bind((T)newvalue);
        }
    }
}
