using Domain.Entities;
using FluentValidation;

namespace Application.Validators.Categorias
{
    public class CategoriasCreateValidator : AbstractValidator<CategoriasEntity>
    {
        public CategoriasCreateValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage(c => $"Canpo {nameof(c.Nome)} é obrigatório.");

            RuleFor(c => c.Descricao)
               .NotEmpty()
               .WithMessage(c => $"Canpo {nameof(c.Descricao)} é obrigatório.");
        }
    }
}
