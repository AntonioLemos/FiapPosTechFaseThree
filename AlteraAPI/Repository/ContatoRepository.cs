using AlteraAPI.Repository.Interface;
using Data.DataContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlteraAPI.Repository
{
    public class ContatoRepository : Repository<CONTATO>, IContatoRepository
    {

        public ContatoRepository(FiapDataContext context) : base(context)
        { }

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
