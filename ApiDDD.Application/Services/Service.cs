using AutoMapper;
using FluentValidation.Results;
using ApiDDD.Application.Extensions;
using ApiDDD.Application.ViewModels;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ApiDDD.Domain.Models;

namespace ApiDDD.Application.Services
{
    public abstract class Service
    {
        protected readonly IMapper Mapper;

        protected Service(IMapper mapper) => Mapper = mapper;

        private ValidationResult _validationResult;

        protected OperationResult Error() => new OperationResult(_validationResult);

        protected OperationResult Error(HttpStatusCode statusCode) => new OperationResult(_validationResult, statusCode);

        protected OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            return new OperationResult(new ValidationResult(failures), statusCode);
        }

        protected OperationResult Success(object obj = null) => new OperationResult(obj);

        protected OperationResult Success(long id) => new OperationResult(new PostViewModel(id));

        protected void NotifyError(string errorMessage)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            _validationResult = new ValidationResult(failures);
        }

        protected bool EntityIsValid<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return true;

            _validationResult = result;
            return false;
        }

        protected bool EntityIsValid<TV, TE>(TV validator, IEnumerable<TE> entities) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            foreach (var item in entities)
            {
                var result = validator.Validate(item);
                if (!result.IsValid)
                {
                    _validationResult = result;
                    return false;
                }
            }

            return true;
        }
    }
}