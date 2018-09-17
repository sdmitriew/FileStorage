using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Modulbank.FileStorage.Binders
{
    //TODO вытащить это в common
    public class InjectParameterBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var service = bindingContext.HttpContext.RequestServices.GetService(bindingContext.ModelType);
            bindingContext.Model = service;
            bindingContext.Result = ModelBindingResult.Success(service);
            return Task.CompletedTask;
        }
    }
}
