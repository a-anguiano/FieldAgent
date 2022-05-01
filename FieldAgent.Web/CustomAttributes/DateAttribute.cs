using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.CustomAttributes
{
    public class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This attribute only works with DateTime objects");
            }

        }
    }
}
