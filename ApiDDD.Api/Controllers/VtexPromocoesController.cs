using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDDD.Domain.Models;
using ApiDDD.Application.Interfaces;
using ApiDDD.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Api.Controllers
{
    [Route("api/promocoes")]
    [ApiController]
    public class VtexPromocoesController : ApiController
    {
        private readonly IVtexPromocoesService _service;

        public VtexPromocoesController(IVtexPromocoesService service)
        => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Promocoes>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Promocoes>>> Get()
            => CustomResponse(await _service.FindAll());
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Promocoes), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Promocoes>> Get(long id)
            => CustomResponse(await _service.FindById(id));

        [HttpGet]
        [Route("top100")]
        [ProducesResponseType(typeof(IEnumerable<Promocoes>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Promocoes>>> GetTop100()
            => CustomResponse(await _service.GetTop());
    }
}
