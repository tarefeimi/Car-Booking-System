using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalRazorPages.ViewModels
{
    public class DateLessThan : ValidationAttribute,IClientModelValidator
    {
            private readonly string _comparisonProperty;

            public DateLessThan(string comparisonProperty)
            {
                _comparisonProperty = comparisonProperty;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ErrorMessage = ErrorMessageString;
                var currentValue = (DateTime)value;

                var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

                if (property == null)
                    throw new ArgumentException("Property with this name not found");

                var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

                  if (currentValue<DateTime.Now) 
                      return new ValidationResult("Date Should be Greater than Taday");
                      
           

                if (currentValue > comparisonValue)
                    return new ValidationResult(ErrorMessage = " Date To must be Greater than Date From ");

                return ValidationResult.Success;
            }
            public void AddValidation(ClientModelValidationContext context)
            {
                  var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
                  context.Attributes.Add("data-val", "true");
                  context.Attributes.Add("data-val-error", error);
            }
        
    }
}