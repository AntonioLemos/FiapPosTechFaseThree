using DeleteAPI.ViewModels.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeleteAPI.ViewModels
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class ContatoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(9, ErrorMessage = "O telefone deve ter 9 caracteres.", MinimumLength = 9)]
        [RegularExpression(@"^9?\d{8}$", ErrorMessage = "O telefone deve estar no formato 999999999.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        public int DDDSelecionado { get; set; }

        public Guid? DDDId { get; set; }
        public string Regiao { get; set; }
        public string Mensagem { get; set; } = "";

        public async Task<FluentValidation.Results.ValidationResult> IsValid()
        {
            var validator = new ContatoViewModelValidator();
            var result = await validator.ValidateAsync(this);
            return result;
        }
    }
}
