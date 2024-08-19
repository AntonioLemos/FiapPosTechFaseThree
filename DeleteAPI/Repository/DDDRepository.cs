using Data.DataContext;
using DeleteAPI.Repository.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DeleteAPI.Repository
{
    public class DDDRepository : Repository<DDD>, IDDDRepository
    {

        public DDDRepository(FiapDataContext context) : base (context)
        {}

        public async Task<DDD> GetDDDPorCodigo(int codigo)
        {
             return _context.DDD.Where(x => x.Codigo.Equals(codigo)).FirstOrDefault();
        }
    }
}
