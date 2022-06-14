using ApiDDD.Data.SqlQuerys;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Data.Repositories
{
    public class VtexPromocoesRepository : Repository<Promocoes>, IVtexPromocoesRepository
    {
        public VtexPromocoesRepository(FactoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Promocoes>> GetAllVtexPromocoesAsync()
             => await _currentSet.AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<Promocoes> GetByIdAsync(long id)
         => await _currentSet
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.IdConfirmacao == id);

        public async Task<IEnumerable<Promocoes>> GetTop100()
            => await _context.Database
            .GetDbConnection()
            .QueryFirstOrDefaultAsync<IEnumerable<Promocoes>>(promocaoScript.PromocoesScript);
    }
}