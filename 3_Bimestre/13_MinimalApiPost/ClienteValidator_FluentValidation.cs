using FluentValidation;

namespace MinimalApiPost;

public class ClienteValidator_FluentValidation : AbstractValidator<Cliente>
{
    public ClienteValidator_FluentValidation()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("El Id debe ser mayor que cero.");

        RuleFor(c => c.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("El email es obligatorio.")
            .EmailAddress().WithMessage("El email no es válido.");
    }
}