using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Models;
using Assets.Sources.ViewModels;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Views
{
    public class ClanView:UnityGuiView<ClanViewModel>
    {
        public RectTransform clanMembersRectTransform;
        public Button addButton;
        public Button removeButton;

        public override void OnBindingContextChanged(ClanViewModel oldValue, ClanViewModel newValue)
        {
            base.OnBindingContextChanged(oldValue, newValue);
            if (oldValue != null)
            {
                oldValue.Members.OnValueChanged -= OnMembersPropertyValueChanged;
                oldValue.Members.OnAdd -= ClanMembers_OnAdd;
                oldValue.Members.OnRemove -= ClanMembers_OnRemove;
            }
            if (newValue != null)
            {
                newValue.Members.OnValueChanged += OnMembersPropertyValueChanged;
                newValue.Members.OnAdd += ClanMembers_OnAdd;
                newValue.Members.OnRemove += ClanMembers_OnRemove;
            }
            addButton.onClick.AddListener(AddMember);
            removeButton.onClick.AddListener(RemoveMember);

        }


        private void OnMembersPropertyValueChanged(List<FaceBox> oldValue, List<FaceBox> newValue)
        {
            //永远找到第一个原型的Prefab，它是Disabled的
            Transform prefab = (clanMembersRectTransform.childCount > 0 ? clanMembersRectTransform.GetChild(0) : null);
            if (prefab == null)
            {
                throw new System.Exception(clanMembersRectTransform.childCount.ToString());
            }
            for (int i = 0; i < newValue.Count; i++)
            {
                var member = newValue[i];
                var newGameObject = GameObject.Instantiate(prefab.gameObject);
                newGameObject.name = member.Name;
                //newGameObject.SetActive(true);

                //获取子View
                var subView = newGameObject.GetComponent<FaceBoxView>();
                subView.BindingContext = new FaceBoxViewModel() {ParentViewModel = BindingContext};
                subView.BindingContext.InitializationFromData(member);
                subView.Reveal();

                newGameObject.transform.SetParent(clanMembersRectTransform, false);
                newGameObject.transform.localScale = Vector3.one;
            }

        }

        private void ClanMembers_OnAdd(FaceBox instance)
        {
           Debug.Log("instance "+instance.Name+" add");

            Transform prefab = (clanMembersRectTransform.childCount > 0 ? clanMembersRectTransform.GetChild(0) : null);
            if (prefab == null)
            {
                throw new System.Exception(clanMembersRectTransform.childCount.ToString());
            }
          
            var newGameObject = GameObject.Instantiate(prefab.gameObject);
            newGameObject.name = instance.Name;

            //获取子View
            var subView = newGameObject.GetComponent<FaceBoxView>();
            subView.BindingContext = new FaceBoxViewModel() { ParentViewModel = BindingContext };
            subView.BindingContext.InitializationFromData(instance);
            subView.Reveal();

            newGameObject.transform.SetParent(clanMembersRectTransform, false);
            newGameObject.transform.localScale = Vector3.one;

        }

        private void ClanMembers_OnRemove(FaceBox instance)
        {
            Debug.Log("instance " + instance.Name + " delete");
            Destroy(GameObject.Find(instance.Name));

        }

        public void AddMember()
        {
            BindingContext.AddMember();
        }

        public void RemoveMember()
        {
            BindingContext.RemoveMember();
        }

    }
}
