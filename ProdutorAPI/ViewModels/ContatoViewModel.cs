using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProdutorAPI.ViewModels
{
    public class ContatoViewModel
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Email { get; set; }

        public int DDDSelecionado { get; set; }

        public Guid? DDDId { get; set; }
        public string Regiao { get; set; }
        public string Mensagem { get; set; } = "";

    }
}
