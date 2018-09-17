using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Modulbank.FileStorage.Dto.Response;

namespace Modulbank.FileStorage.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<ErrorResponse.Error>();
                foreach (var field in context.ModelState)
                {
                    var fieldId = field.Key;
                    foreach (var error in field.Value.Errors)
                    {
                        errors.Add(new ErrorResponse.Error
                        {
                            Code = "fail",
                            FieldId = fieldId,
                            Message = error.ErrorMessage
                        });
                    }
                }
                context.Result = new JsonResult(new ErrorResponse
                {
                    Code = "fail",
                    Errors = errors
                });
            }
        }
    }
}
