using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Util
{
    public static class ContatoList
    {
        public static readonly CONTATO[] contatos =
        {
            new CONTATO
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                Nome = "João Silva",
                Telefone = "999977118",
                Email = "joao.silva@example.com",
                DDDId = new Guid("11111111-1111-1111-1111-111111111111")
            },
            new CONTATO
            {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Nome = "Maria Souza",
                Telefone = "999977117",
                Email = "maria.souza@example.com",
                DDDId = new Guid("22222222-2222-2222-2222-222222222222")
            }
        };
    }
}