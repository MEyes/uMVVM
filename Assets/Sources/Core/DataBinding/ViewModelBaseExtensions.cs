using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM.Sources.Infrastructure;

namespace Assets.Sources.Core.DataBinding
{
    public static class ViewModelBaseExtensions
    {
        public static IEnumerable<T> Ancestors<T>(this ViewModelBase origin) where T : ViewModelBase
        {
            if (origin==null)
            {
                yield break;
            }
            var parentViewModel = origin.ParentViewModel;
            while (parentViewModel!=null)
            {
                var castedViewModel = parentViewModel as T;
                if (castedViewModel != null)
                {
                    yield return castedViewModel;
                }
                parentViewModel = parentViewModel.ParentViewModel;
            }

        }
    }
}
