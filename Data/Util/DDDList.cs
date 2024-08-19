using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Util
{
    public static class DDDList
    {
        public static readonly DDD[] ddds =
        {
            new DDD { Id = new Guid("11111111-1111-1111-1111-111111111111"), Codigo = 11, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = new Guid("22222222-2222-2222-2222-222222222222"), Codigo = 12, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 13, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 14, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 15, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 16, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 17, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 18, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 19, Estado = "São Paulo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 21, Estado = "Rio de Janeiro", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 22, Estado = "Rio de Janeiro", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 24, Estado = "Rio de Janeiro", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 27, Estado = "Espírito Santo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 28, Estado = "Espírito Santo", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 31, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 32, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 33, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 34, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 35, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 37, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 38, Estado = "Minas Gerais", Regiao = "Sudeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 41, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 42, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 43, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 44, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 45, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 46, Estado = "Paraná", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 47, Estado = "Santa Catarina", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 48, Estado = "Santa Catarina", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 49, Estado = "Santa Catarina", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 51, Estado = "Rio Grande do Sul", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 53, Estado = "Rio Grande do Sul", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 54, Estado = "Rio Grande do Sul", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 55, Estado = "Rio Grande do Sul", Regiao = "Sul" },
            new DDD { Id = Guid.NewGuid(), Codigo = 61, Estado = "Distrito Federal", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 62, Estado = "Goiás", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 63, Estado = "Tocantins", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 64, Estado = "Goiás", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 65, Estado = "Mato Grosso", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 66, Estado = "Mato Grosso", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 67, Estado = "Mato Grosso do Sul", Regiao = "Centro-Oeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 68, Estado = "Acre", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 69, Estado = "Rondônia", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 71, Estado = "Bahia", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 73, Estado = "Bahia", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 74, Estado = "Bahia", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 75, Estado = "Bahia", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 77, Estado = "Bahia", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 79, Estado = "Sergipe", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 81, Estado = "Pernambuco", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 82, Estado = "Alagoas", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 83, Estado = "Paraíba", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 84, Estado = "Rio Grande do Norte", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 85, Estado = "Ceará", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 86, Estado = "Piauí", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 87, Estado = "Pernambuco", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 88, Estado = "Ceará", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 89, Estado = "Piauí", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 91, Estado = "Pará", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 92, Estado = "Amazonas", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 93, Estado = "Pará", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 94, Estado = "Pará", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 95, Estado = "Roraima", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 96, Estado = "Amapá", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 97, Estado = "Amazonas", Regiao = "Norte" },
            new DDD { Id = Guid.NewGuid(), Codigo = 98, Estado = "Maranhão", Regiao = "Nordeste" },
            new DDD { Id = Guid.NewGuid(), Codigo = 99, Estado = "Maranhão", Regiao = "Nordeste" }
        };
    }
}
