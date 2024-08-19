using Data.Util;
using FluentValidation;
using System.Numerics;

namespace CadastroAPI.ViewModels.Validation
{
    public class ContatoViewModelValidator : AbstractValidator<ContatoViewModel>
    {
        public ContatoViewModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.").MaximumLength(60).WithMessage("O nome deve ter no máximo 60 caracteres.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.").Length(9).WithMessage("O telefone deve ter 9 caracteres.").Matches(@"^9?\d{8}$").WithMessage("O telefone deve estar no formato 999999999.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email é obrigatório.").EmailAddress().WithMessage("O email não é válido.").MaximumLength(60).WithMessage("O email deve ter no máximo 60 caracteres.");
            var dddsValidos = DDDList.ddds.Select(x => x.Codigo).ToList();
            RuleFor(x => x.DDDSelecionado).Must(ddd => dddsValidos.Contains(ddd)).WithMessage("O DDD deve ser um valor válido de 2 dígitos.");
        }

        private bool BeInteger(string ddd)
        {
            return int.TryParse(ddd, out _);
        }

    }
}
