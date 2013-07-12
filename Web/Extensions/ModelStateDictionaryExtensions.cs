using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ScrumBoard.Web.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static void Add(this System.Web.ModelBinding.ModelStateDictionary modelState, ICollection<ValidationResult> validationResults)
        {
            var dictionary = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var vr in validationResults)
            {
                string subPropertyName = vr.MemberNames.First();

                if (!dictionary.ContainsKey(subPropertyName))
                    dictionary[subPropertyName] = modelState.IsValidField(subPropertyName);

                if (dictionary[subPropertyName])
                    modelState.AddModelError(subPropertyName, vr.ErrorMessage);
            }
        }

        public static void Add(this System.Web.Http.ModelBinding.ModelStateDictionary modelState, ICollection<ValidationResult> validationResults)
        {
            var dictionary = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var vr in validationResults)
            {
                string subPropertyName = vr.MemberNames.First();

                if (!dictionary.ContainsKey(subPropertyName))
                    dictionary[subPropertyName] = modelState.IsValidField(subPropertyName);

                if (dictionary[subPropertyName])
                    modelState.AddModelError(subPropertyName, vr.ErrorMessage);
            }
        }
    }
}            // Validator.TryValidateObject(this, new ValidationContext(this),  validationResults);
