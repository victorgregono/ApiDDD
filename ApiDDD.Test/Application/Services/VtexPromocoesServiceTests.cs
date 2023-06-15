using ApiDDD.Application.Profiles;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using ApiDDD.Services;
using AutoFixture;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Test.Application.Services
{
    public class VtexPromocoesServiceTests
    {
        private readonly Mock<IVtexPromocoesRepository> _mockVtexPromocoesRepository;
        private readonly VtexPromocoesService _vtexPromocoesService;
        private readonly IMapper _mapper;

        private readonly Fixture _fixture;

        public VtexPromocoesServiceTests()
        {
            _fixture = new Fixture();

            _mockVtexPromocoesRepository = new Mock<IVtexPromocoesRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mappingConfig.CreateMapper();

            _vtexPromocoesService = new VtexPromocoesService(_mockVtexPromocoesRepository.Object, _mapper);
        }

        [Fact]
        public async Task VtexPromocoesGetallReturnSucess()
        {
            var promocoes = _fixture.Create<IEnumerable<Promocoes>>();

            _mockVtexPromocoesRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(promocoes);

            var result = await _vtexPromocoesService.FindAll();

            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task VtexPromocoesGetaTop100ReturnSucess()
        {
            var promocoes = _fixture.Create<IEnumerable<Promocoes>>();

            _mockVtexPromocoesRepository.Setup(x => x.GetTop100()).ReturnsAsync(promocoes);

            var result = await _vtexPromocoesService.GetTop();

            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task VtexPromocoesGetByIdReturnSucess()
        {
            var promocoes = _fixture.Create<Promocoes>();

            _mockVtexPromocoesRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(promocoes);

            var result = await _vtexPromocoesService.FindById(1);

            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task VtexPromocoesGetallReturnNotFound()
        {
            _mockVtexPromocoesRepository.Setup(x => x.GetAllAsync());

            var result = await _vtexPromocoesService.FindAll();

            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task VtexPromocoesGetaTop100ReturnNotFound()
        {
            _mockVtexPromocoesRepository.Setup(x => x.GetTop100());

            var result = await _vtexPromocoesService.GetTop();

            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async Task VtexPromocoesGetByIdReturnNotFound(long Id)
        {
            var promocoes = _fixture.Create<Promocoes>();

            _mockVtexPromocoesRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(promocoes);

            var result = await _vtexPromocoesService.FindById(Id);

            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }
    }
}