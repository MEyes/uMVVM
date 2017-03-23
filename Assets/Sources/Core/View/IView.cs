using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uMVVM.Sources.Infrastructure
{
    public interface IView
    {
        ViewModelBase BindingContext { get; set; }
    }
}
