using System.ComponentModel.DataAnnotations;

namespace DroneDeliveryService.Attributes
{
    public class FileContentValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? file = (IFormFile?)value;
            if (file != null)
            {
                if (file.Length <= 0)
                    return new ValidationResult($"The file is empty.");
            }
            else
                return new ValidationResult($"The file was not uploaded into the request.");
            return ValidationResult.Success;
        }
    }
}
