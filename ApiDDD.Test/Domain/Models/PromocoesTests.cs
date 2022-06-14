using ApiDDD.Domain.Models;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Test.Domain.Models
{
    public class PromocoesTests
    {
        private readonly Fixture _fixture;

        public PromocoesTests()
            => _fixture = new Fixture();

        [Fact]
        public void TypeObject()
        {
            var promocoes = _fixture.Create<Promocoes>();

            Assert.IsAssignableFrom<int>(promocoes.IdConfirmacao);
            Assert.IsAssignableFrom<string>(promocoes.Usuario);
            Assert.IsAssignableFrom<int>(promocoes.Loja);
            Assert.IsAssignableFrom<DateTime>(promocoes.DataHora);
            Assert.IsAssignableFrom<string>(promocoes.NomeArquivo);
            Assert.IsAssignableFrom<int>(promocoes.Status);
        }
    }
}
