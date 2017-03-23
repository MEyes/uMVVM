using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using uMVVM.Sources.Infrastructure;
using UnityEditor;

namespace Assets.Sources.Core.DataBinding
{
    public class PropertyBinder<T> where T:ViewModelBase
    {
        private delegate void BindHandler(T viewmodel);
        private delegate void UnBindHandler(T viewmodel);

        private readonly List<BindHandler> _binders=new List<BindHandler>();
        private readonly List<UnBindHandler> _unbinders=new List<UnBindHandler>();
        
        public void Add<TProperty>(string name,BindableProperty<TProperty>.ValueChangedHandler valueChangedHandler )
        {
            var fieldInfo = typeof(T).GetField(name, BindingFlags.Instance | BindingFlags.Public);
            if (fieldInfo == null)
            {
                throw new Exception(string.Format("Unable to find bindableproperty field '{0}.{1}'", typeof(T).Name, name));
            }

            _binders.Add(viewmodel =>
            {
                GetPropertyValue<TProperty>(name, viewmodel, fieldInfo).OnValueChanged += valueChangedHandler;
            });

            _unbinders.Add(viewModel =>
            {
                GetPropertyValue<TProperty>(name, viewModel, fieldInfo).OnValueChanged -= valueChangedHandler;
            });

        }

        private  BindableProperty<TProperty> GetPropertyValue<TProperty>(string name, T viewModel,FieldInfo fieldInfo)
        {
            var value = fieldInfo.GetValue(viewModel);
            BindableProperty<TProperty> bindableProperty = value as BindableProperty<TProperty>;
            if (bindableProperty == null)
            {
                throw new Exception(string.Format("Illegal bindableproperty field '{0}.{1}' ", typeof(T).Name, name));
            }

            return bindableProperty;
        }

        public void Bind(T viewmodel)
        {
            if (viewmodel!=null)
            {
                for (int i = 0; i < _binders.Count; i++)
                {
                    _binders[i](viewmodel);
                }
            }
        }

        public void Unbind(T viewmodel)
        {
            if (viewmodel!=null)
            {
                for (int i = 0; i < _unbinders.Count; i++)
                {
                    _unbinders[i](viewmodel);
                }
            }
        }

    }
}
