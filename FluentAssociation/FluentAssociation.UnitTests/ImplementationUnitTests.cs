using FluentAssertions;
using FluentAssociation.Library.Implementation;
using FluentAssociation.Library.Interface;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FluentAssociation.UnitTests
{
    public class ImplementationUnitTests
    {
        private readonly IFluentAssociation <string> _service;

        public ImplementationUnitTests()
        {
            var lista = new List<List<string>>
            {
                new List<string> { "leite", "ovos", "café", "açúcar", "fraldas", "manteiga" },
                new List<string> { "leite", "café", "farinha" },
                new List<string> { "leite", "ovos", "açúcar" },
                new List<string> { "café", "açúcar" },
                new List<string> { "fraldas" },
                new List<string> { "manteiga", "ovos", "leite" },
                new List<string> { "café", "açúcar", "leite", "ovos" },
                new List<string> { "farinha", "manteiga", "ovos" },
                new List<string> { "manteiga", "ovos", "leite", "café", "açúcar" },
                new List<string> { "fraldas", "café", "cerveja" }
            };

            _service = new FluentAssociation<string>();

            _service.LoadDataWarehouse(lista);
        }

        [Fact]
        public async void Test_1ItemSet()
        {
            var metrics = await _service.Get1ItemSets();

            metrics
                .Where(m => m.Item == "leite")
                .First().Suport.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_2ItemSet()
        {
            var metrics = await _service.Get2ItemSets();

            // [leite] => [ovos]
            var exemplo = metrics
                .Where(m => m.Item1 == "leite" && m.Item2 == "ovos")
                .First();

            exemplo.Suport.Should().Be(0.5f);

            exemplo.Confidence.Should().BeApproximately(0.83f, 1);
        }

        [Fact]
        public async void Test_3ItemSet()
        {
            var metrics = await _service.Get3ItemSets();

            // [leite, ovos] => [café]
            var exemplo = metrics
                .Where(m => m.Item1 == "leite" && m.Item2 == "ovos" && m.Item3 == "café")
                .First();

            exemplo.Suport.Should().Be(0.3f);

            exemplo.Confidence.Should().Be(0.6f);
        }
    }
}