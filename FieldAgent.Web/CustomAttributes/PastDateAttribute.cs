using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.CustomAttributes
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime date = Convert.ToDateTime(value);

                if (date >= DateTime.Today)
                {
                    return new ValidationResult("Date must be in the past");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("This attribute only works with DateTime objects");
            }

        }
    }
}
