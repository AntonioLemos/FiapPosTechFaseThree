using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.ViewModels
{
    public class DDDViewModel
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }
        public string Regiao { get; set; }
        public string Estado { get; set; }
    }
}
