﻿using Data.Util;
using Domain.Models;

namespace AlteraAPI.Repository.Interface
{
    public interface IContatoRepository : IRepository<CONTATO>
    {
        Task<IEnumerable<CONTATO>> GetListaContatoPorTelefone(string telefone);
        Task<CONTATO> GetContatoPorEmail(string email);
    }
}
