using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
