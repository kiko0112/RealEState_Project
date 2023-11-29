﻿using System.ComponentModel.DataAnnotations;

namespace MyProject1.Helper
{
    public static class ValidationHelper<T> where T : class
    {
        public static string Validate(T model)
        {
            var modelValidationContext = new ValidationContext(model);
            var modelValidationResults = new List<ValidationResult>();
            bool modelIsValid = Validator.TryValidateObject(model, modelValidationContext, modelValidationResults, true);

            List<string> errors = new List<string>();
            if (!modelIsValid)
            {
                errors = modelValidationResults.Select(r => r.ErrorMessage).ToList();
                string errorMessage = string.Join(", ", errors);
                return errorMessage;
            }

            return null;
        }
    }
}
