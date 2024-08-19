using ConsultaAPI.Repository.Interface;
using Data.DataContext;
using Data.Util;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAPI.Repository
{
    public class ContatoRepository : Repository<CONTATO>, IContatoRepository
    {

        public ContatoRepository(FiapDataContext context) : base(context)
        { }

        public async Task<PagedResult<CONTATO>> GetContatosPaginados(int pageNumber, int pageSize, int ddd)
        {
            var query = ddd == 0
                        ? _context.CONTATO
                            .Select(c => new CONTATO { Id = c.Id, Nome = c.Nome, Email = c.Email, Telefone = c.Telefone, DDD = new DDD { Id = c.DDD.Id, Codigo = c.DDD.Codigo, Regiao = c.DDD.Regiao } })
                            .OrderBy(c => c.Nome)
                            .AsQueryable()
                        : _context.CONTATO
                            .Where(c => c.DDD.Codigo == ddd)
                            .Select(c => new CONTATO { Id = c.Id, Nome = c.Nome, Email = c.Email, Telefone = c.Telefone, DDD = new DDD { Id = c.DDD.Id, Codigo = c.DDD.Codigo, Regiao = c.DDD.Regiao } })
                            .OrderBy(c => c.Nome)
                            .AsQueryable();

            return await PaginationUtil.PaginateAsync(query, pageNumber, pageSize);
        }

        public async Task<IEnumerable<CONTATO>> GetListaContatoPorTelefone(string telefone)
        {
            return await _context.CONTATO.Where(x => x.Telefone.Equals(telefone)).ToListAsync();
        }

        public async Task<CONTATO> GetContatoPorEmail(string email)
        {
            return _context.CONTATO.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
    }
}
