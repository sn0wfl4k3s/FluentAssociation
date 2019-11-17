using FluentAssertions;
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
            var metrics = await _service.GetReport1ItemSets();

            var leite = metrics.GetItemSet("leite");

            leite.Suport.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_2ItemSet()
        {
            var metrics = await _service.GetReport2ItemSets();

            // [leite] => [ovos]
            var exemplo = metrics.GetItemSet("leite", "ovos");

            exemplo.Suport.Should().Be(0.5f);

            exemplo.Confidence.Should().BeApproximately(0.83f, 1);
        }

        [Fact]
        public async void Test_3ItemSet()
        {
            var metrics = await _service.GetReport3ItemSets();

            // [leite, ovos] => [café]
            var exemplo = metrics.GetItemSet("leite", "ovos", "café");

            exemplo.Suport.Should().Be(0.3f);

            exemplo.Confidence.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_4ItemSet()
        {
            var metrics = await _service.GetReport4ItemSets();

            // [leite, ovos, café] => [açúcar]
            var exemplo = metrics.GetItemSet("leite", "ovos", "café", "açúcar");

            exemplo.Suport.Should().Be(0.3f);

            exemplo.Confidence.Should().Be(1f);
        }

        [Fact]
        public async void Combinação_de_4_itens_com_melhor_confiança()
        {
            var metrics = await _service.GetReport4ItemSets();

            var melhorConfiança = metrics.OrderByDescendingConfidence().First();

            melhorConfiança.Item1.Should().BeEquivalentTo("leite");
            
            melhorConfiança.Item2.Should().BeEquivalentTo("ovos");
            
            melhorConfiança.Item3.Should().BeEquivalentTo("café");
            
            melhorConfiança.Item4.Should().BeEquivalentTo("açúcar");

            melhorConfiança.Suport.Should().BeApproximately(0.3f, 1);
        }
    }
}