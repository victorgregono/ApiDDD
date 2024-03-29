﻿using ApiDDD.Application.Extensions;
using ApiDDD.Application.Interfaces;
using ApiDDD.Domain.Interfaces;
using AutoMapper;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiDDD.Services
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
