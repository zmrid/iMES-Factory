using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace iMES.Core.ObjectActionValidator
{
    public class ObjectModelValidatorFilter : Attribute
    {
        public ObjectModelValidatorFilter(ValidatorModel validatorGroup)
        {
            MethodsParameters = validatorGroup.GetModelParameters()?.Select(x => x.ToLower())?.ToArray();
        }
        public string[] MethodsParameters { get; }
    }
}
