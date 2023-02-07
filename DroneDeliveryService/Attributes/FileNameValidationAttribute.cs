using System.ComponentModel.DataAnnotations;

namespace DroneDeliveryService.Attributes
{
    public class FileNameValidationAttribute : ValidationAttribute
    {
        private readonly string _fileName;

        public FileNameValidationAttribute(string fileName)
        {
            _fileName = fileName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? file = (IFormFile?)value;
            if (file != null)
            {
                if (file.FileName.Split(".")[0] != _fileName)
                    return new ValidationResult($"The file name '{file.FileName}' is not valid.");
            }
            else
                return new ValidationResult($"The file was not uploaded into the request.");
            return ValidationResult.Success;
        }
    }
}
