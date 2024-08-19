using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DDD
    {
        public Guid Id { get; set; }

        public int Codigo { get; set; } 

        public string Regiao { get; set; } 
        public string Estado { get; set; } 

        public ICollection<CONTATO> Contatos { get; set; } 
    }
}
