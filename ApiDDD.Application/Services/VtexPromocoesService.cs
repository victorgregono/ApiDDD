using AutoMapper;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services
{
    public  class VtexPromocoesService : Service, IVtexPromocoesService
    {
        private readonly IVtexPromocoesRepository _repository;

        public VtexPromocoesService(IVtexPromocoesRepository repository, IMapper mapper) : base(mapper)
            => _repository = repository;

        public async Task<OperationResult> FindAll()
        {
            var entity = await _repository.GetAllAsync();
            
            if (!entity.Any())
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(entity);
        }

        public async Task<OperationResult> FindById(long id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(entity);
        }

        public async Task<OperationResult> GetTop()
        {
            var entity = await _repository.GetTop100();

            if (!entity.Any())
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(entity);
        }
    }
}
