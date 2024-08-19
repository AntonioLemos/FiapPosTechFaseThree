namespace CadastroAPI.ViewModels
{
    public class MessageViewModel<T> where T : class
    {

        public string NomeFila { get; set; }
        public T Dados { get; set; }
    }
}
