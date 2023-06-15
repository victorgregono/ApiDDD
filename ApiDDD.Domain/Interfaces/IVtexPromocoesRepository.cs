using ApiDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces
{

    public interface IVtexPromocoesRepository : IRepository<Promocoes>
    {
        Task<IEnumerable<Promocoes>> GetAllVtexPromocoesAsync();
        Task<Promocoes> GetByIdAsync(long id);
        Task<IEnumerable<Promocoes>> GetTop100();
    }
   
}
