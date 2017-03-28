using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.DataBinding;
using DG.Tweening;
using UnityEngine;

namespace uMVVM.Sources.Infrastructure
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UnityGuiView<T>:MonoBehaviour,IView<T> where T:ViewModelBase
    {
        private bool _isInitialized;
        public bool destroyOnHide;
        protected readonly PropertyBinder<T> Binder=new PropertyBinder<T>();
        public readonly BindableProperty<T> ViewModelProperty = new BindableProperty<T>();
        /// <summary>
        /// 显示之后的回掉函数
        /// </summary>
        public Action RevealedAction { get; set; }
        /// <summary>
        /// 隐藏之后的回掉函数
        /// </summary>
        public Action HiddenAction { get; set; }

        public T BindingContext
        {
            get { return ViewModelProperty.Value; }
            set
            {
                if (!_isInitialized)
                {
                    OnInitialize();
                    _isInitialized = true;
                }
                //触发OnValueChanged事件
                ViewModelProperty.Value = value;
            }
        }

        public void Reveal(bool immediate = false, Action action = null)
        {
            if (action!=null)
            {
                RevealedAction += action;
            }
            OnAppear();
            OnReveal(immediate);
            OnRevealed();
        }

        public void Hide(bool immediate = false, Action action = null)
        {
            if (action!=null)
            {
                HiddenAction += action;
            }
            OnHide(immediate);
            OnHidden();
            OnDisappear();
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
        /// 激活gameObject,Disable->Enable
        /// </summary>
        public virtual void OnAppear()
        {
            gameObject.SetActive(true);
            BindingContext.OnStartReveal();
        }
        /// <summary>
        /// 开始显示
        /// </summary>
        /// <param name="immediate"></param>
        private void OnReveal(bool immediate)
        {
            if (immediate)
            {
                //立即显示
                transform.localScale = Vector3.one;
                GetComponent<CanvasGroup>().alpha = 1;
            }
            else
            {
                StartAnimatedReveal();
            }
        }
        /// <summary>
        /// alpha 0->1 之后执行
        /// </summary>
        public virtual void OnRevealed()
        {
            BindingContext.OnFinishReveal();
            //回掉函数
            if (RevealedAction!=null)
            {
                RevealedAction();
            }
        }
      
        private void OnHide(bool immediate)
        {
            BindingContext.OnStartHide();
            if (immediate)
            {
                //立即隐藏
                transform.localScale = Vector3.zero;
                GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                StartAnimatedHide();
            }
        }
        /// <summary>
        /// alpha 1->0时
        /// </summary>
        public virtual void OnHidden()
        {
            //回掉函数
            if (HiddenAction!=null)
            {
                HiddenAction();
            }
        }
        /// <summary>
        /// 消失 Enable->Disable
        /// </summary>
        public virtual void OnDisappear()
        {
            gameObject.SetActive(false);
            BindingContext.OnFinishHide();
            if (destroyOnHide)
            {
                //销毁
                Destroy(this.gameObject);
            }

        }
        /// <summary>
        /// 当gameObject将被销毁时，这个方法被调用
        /// </summary>
        public virtual void OnDestroy()
        {
            if (BindingContext.IsRevealed)
            {
                Hide(true);
            }
            BindingContext.OnDestory();
            BindingContext = null;
            ViewModelProperty.OnValueChanged = null;
        }

        /// <summary>
        /// scale:1,alpha:1
        /// </summary>
        protected virtual void StartAnimatedReveal()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            transform.localScale = Vector3.one;

            canvasGroup.DOFade(1, 0.2f).SetDelay(0.2f).OnComplete(() =>
            {
                canvasGroup.interactable = true;
            });
        }
        /// <summary>
        /// alpha:0,scale:0
        /// </summary>
        protected virtual void StartAnimatedHide()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.DOFade(0, 0.2f).SetDelay(0.2f).OnComplete(() =>
            {
                transform.localScale = Vector3.zero;
                canvasGroup.interactable = true;
            });
        }
        /// <summary>
        /// 绑定的上下文发生改变时的响应方法
        /// 利用反射+=/-=OnValuePropertyChanged
        /// </summary>
        public virtual void OnBindingContextChanged(T oldValue, T newValue)
        {
            Binder.Unbind(oldValue);
            Binder.Bind(newValue);
        }
    }
}
