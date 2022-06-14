using ApiDDD.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Interfaces
{
    public interface IVtexPromocoesService
    {
        Task<OperationResult> FindAll();
        Task<OperationResult> FindById(long id);
        Task<OperationResult> GetTop();
    }
}
