using FluentValidation;
using FluentValidation.Models;

namespace FluentValidation.Validations
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(p => p.Descricao)
                .MaximumLength(10)
                .WithMessage("Tamanho máximo de Descrição é de 10 caracteres.");

            RuleFor(p => p.Titulo)
                .MaximumLength(10)
                .WithMessage("Tamanho máximo de Título é de 10 caracteres");
        }
    }
}
