using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Infrastructure;
using Assets.Sources.Models;
using Assets.Sources.ViewModels;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Views
{
    public class FaceBoxView:UnityGuiView<FaceBoxViewModel>
    {
        public Text nameText;
        public Text levelText;
        public Image faceImage;
        public BadgeView badgeView;

        public EventTrigger eventTrigger;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            //初始化Binder
            Binder.Add<string>("Name",OnNamePropertyVlaueChanged);
            Binder.Add<int>("Level",OnLevelPropertyValueChanged);
            Binder.Add<string>("Face",OnFacePropertyValueChanged);
            Binder.Add<Badge>("Badge",OnBadgePropertyValueChanged);
            //监听事件
            var beginDragEntry = new EventTrigger.Entry();
            beginDragEntry.eventID = EventTriggerType.BeginDrag;
            beginDragEntry.callback.AddListener(eventData => { OnBeginDrag(); });
            eventTrigger.triggers.Add(beginDragEntry);

            var dragEntry = new EventTrigger.Entry();
            dragEntry.eventID = EventTriggerType.Drag;
            dragEntry.callback.AddListener(eventData => { OnDrag(); });
            eventTrigger.triggers.Add(dragEntry);

            var endDragEntry = new EventTrigger.Entry();
            endDragEntry.eventID = EventTriggerType.EndDrag;
            endDragEntry.callback.AddListener(eventData => { OnEndDrag(); });
            eventTrigger.triggers.Add(endDragEntry);

            var pointClickEntry = new EventTrigger.Entry();
            pointClickEntry.eventID = EventTriggerType.PointerClick;
            pointClickEntry.callback.AddListener(eventData => { OnClick(); });
            eventTrigger.triggers.Add(pointClickEntry);
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

        private void OnClick()
        {
            if (BindingContext.OnClick != null)
            {
                BindingContext.OnClick();
            }
        }

        private void OnBeginDrag()
        {
            if (BindingContext.OnBeginDrag != null)
            {
                BindingContext.OnBeginDrag();
            }
        }

        private void OnDrag()
        {
            if (BindingContext.OnDrag != null)
            {
                BindingContext.OnDrag();
            }
        }

        private void OnEndDrag()
        {
            if (BindingContext.OnEndDrag != null)
            {
                BindingContext.OnEndDrag();
            }
        }
    }
}
