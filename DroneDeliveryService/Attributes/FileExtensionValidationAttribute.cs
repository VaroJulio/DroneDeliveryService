using System.ComponentModel.DataAnnotations;

namespace DroneDeliveryService.Attributes
{
    public class FileExtensionValidationAttribute : ValidationAttribute
    {
        private readonly string[] _fileExtensions;

        public FileExtensionValidationAttribute(string fileExtensions)
        {
            _fileExtensions = fileExtensions.Split(",");
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile? file = (IFormFile?)value;
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                if (!_fileExtensions.Contains(extension.ToLower()))
                    return new ValidationResult($"The extension '{extension}' is not valid.");
            }
            else
                return new ValidationResult($"The file was not uploaded into the request.");
            return ValidationResult.Success;
        }
    }
}
