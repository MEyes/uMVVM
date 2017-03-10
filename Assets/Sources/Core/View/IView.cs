using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uMVVM.Sources.Infrastructure
{
    public interface IView
    {
        ViewModel BindingContext { get; set; }
    }
}
