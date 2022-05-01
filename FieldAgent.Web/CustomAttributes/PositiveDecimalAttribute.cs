using System.ComponentModel.DataAnnotations;

namespace FieldAgent.Web.CustomAttributes
{
    public class PositiveDecimalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is decimal)
            {
                decimal height = Convert.ToDecimal(value);

                if (height <= 0)
                {
                    return new ValidationResult("Input must be a positive decimal");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("This attribute only works with Decimal objects");
            }

        }
    }
}
