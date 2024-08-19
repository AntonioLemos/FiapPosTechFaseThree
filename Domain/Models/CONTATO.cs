using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CONTATO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }


        public Guid DDDId { get; set; }
        public DDD DDD { get; set; }

    }
}
