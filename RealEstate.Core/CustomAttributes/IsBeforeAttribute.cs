using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.CustomAttributes
{
    public class IsBeforeAttribute : ValidationAttribute
    {
        private readonly string propertyToCompare;

        public IsBeforeAttribute(string _propertyToCompare, string errorMessage = "")
        {
            this.propertyToCompare = _propertyToCompare;
            this.ErrorMessage = errorMessage;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                DateTime dateToCompare = (DateTime)validationContext
                .ObjectType
                .GetProperty(propertyToCompare)
                .GetValue(validationContext.ObjectInstance);

                if ((DateTime)value < dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            catch (Exception)
            {}

            return new ValidationResult(ErrorMessage);
        }
    }
}
