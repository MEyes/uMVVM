using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Models;
using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.ViewModels
{
    public class FaceBoxViewModel:ViewModelBase
    {
        public readonly BindableProperty<string> Name=new BindableProperty<string>();
        public readonly BindableProperty<int> Level=new BindableProperty<int>();
        public readonly BindableProperty<string> Face=new BindableProperty<string>();
        public readonly BindableProperty<Badge> Badge=new BindableProperty<Badge>();
        public delegate void OnBeginDragHandler();
        public OnBeginDragHandler OnBeginDrag;
        public delegate void OnDragHandler();
        public OnDragHandler OnDrag;
        public delegate void OnEndDragHandler();
        public OnEndDragHandler OnEndDrag;
        public delegate void OnClickHandler();
        public OnClickHandler OnClick;

        public override void OnStartReveal()
        {
            base.OnStartReveal();
            //Initialization();
        }

        public void Initialization()
        {
            Name.Value = "比尔";
            Level.Value = 9;
            Face.Value = "Avatar204_Face";
            Badge.Value = new Badge() {Icon = "Icon_WeaponRod", ElementColor = "1CB9FFFF"};
        }

        public void InitializationFromData(FaceBox member)
        {
            Name.Value = member.Name;
            Level.Value = member.Level;
            Face.Value = member.Face;
            Badge.Value = new Badge() { Icon = member.Badge.Icon, ElementColor = member.Badge.ElementColor };
        }
    }
}
