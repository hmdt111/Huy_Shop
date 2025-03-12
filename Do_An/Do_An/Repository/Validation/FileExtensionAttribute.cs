using NuGet.Packaging;
using System.ComponentModel.DataAnnotations;

namespace Do_An.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);//342.jpg  
                string[] extennsions = { "jpg", "png", "jpeg" };

                bool result = extennsions.Any(x => extension.EndsWith(x));
                if (!result)
                {
                    return new ValidationResult("Không phải đuôi jpg , png , jpeg");
                }

            }

            return ValidationResult.Success;
        }
    }
}
