using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Modulbank.FileStorage.Binders
{
    public class ProtectedIdModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (!context.Metadata.IsComplexType) return null;
            if (!context.BindingInfo.BindingSource.IsFromRequest)
                return new BinderTypeModelBinder(typeof(InjectParameterBinding));
            return null;
        }
    }
}
