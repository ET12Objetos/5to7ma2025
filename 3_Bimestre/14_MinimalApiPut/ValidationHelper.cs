using System.ComponentModel.DataAnnotations;

namespace MinimalApiPut
{
    public static class ValidationHelper
    {
        public static (bool IsValid, Dictionary<string, string[]> Errors) Validate<T>(T model)
        {
            var validationContext = new ValidationContext(model!);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model!, validationContext, validationResults, true);

            var errores = validationResults
                .GroupBy(e => e.MemberNames.FirstOrDefault() ?? "Error")
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage ?? "Error de validación").ToArray()
                );

            return (isValid, errores);
        }
    }
}
