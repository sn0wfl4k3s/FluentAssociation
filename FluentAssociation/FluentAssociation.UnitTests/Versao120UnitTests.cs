using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FluentAssociation.UnitTests
{
    public class Versao120UnitTests
    {
        private readonly IFluentAssociation <string> _service;

        public Versao120UnitTests()
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
            var metrics = await _service.GetReportItemSets(1);

            var leite = metrics.GetItemSet("leite");

            leite.Suport.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_2ItemSet()
        {
            var metrics = await _service.GetReportItemSets(2);

            // [leite] => [ovos]
            var exemplo = metrics.GetItemSet("leite", "ovos");

            exemplo.Suport.Should().Be(0.5f);

            exemplo.Confidence.Should().BeApproximately(0.83f, 1);
        }

        [Fact]
        public async void Test_3ItemSet()
        {
            var metrics = await _service.GetReportItemSets(3);

            // [leite, ovos] => [café]
            var exemplo = metrics.GetItemSet("leite", "ovos", "café");

            exemplo.Suport.Should().Be(0.3f);

            exemplo.Confidence.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_4ItemSet()
        {
            var metrics = await _service.GetReportItemSets(4);

            // [leite, ovos, café] => [açúcar]
            var exemplo = metrics.GetItemSet("leite", "ovos", "café", "açúcar");

            exemplo.Suport.Should().Be(0.3f);

            exemplo.Confidence.Should().Be(1f);
        }

        [Fact]
        public async void Combinação_de_4_itens_com_melhor_confiança()
        {
            var metrics = await _service.GetReportItemSets(4);

            var melhorConfiança = metrics.OrderByDescendingConfidence().First();

            melhorConfiança.Items.ElementAt(0).Should().BeEquivalentTo("leite");

            melhorConfiança.Items.ElementAt(1).Should().BeEquivalentTo("ovos");

            melhorConfiança.Items.ElementAt(2).Should().BeEquivalentTo("café");

            melhorConfiança.Items.ElementAt(3).Should().BeEquivalentTo("açúcar");

            melhorConfiança.Suport.Should().BeApproximately(0.3f, 1);
        }

        [Fact]
        public async void Nao_deve_haver_itemset_com_suport_maior_que_dois()
        {
            var metrics1 = await _service.GetReportItemSets();

            var metrics2 = await _service.GetReportItemSets(2);

            var metrics3 = await _service.GetReportItemSets(3);

            var metrics4 = await _service.GetReportItemSets(4);

            metrics1.Where(m => m.Suport < _service.MinSuport).Count().Should().Be(0);

            metrics2.Where(m => m.Suport < _service.MinSuport).Count().Should().Be(0);

            metrics3.Where(m => m.Suport < _service.MinSuport).Count().Should().Be(0);

            metrics4.Where(m => m.Suport < _service.MinSuport).Count().Should().Be(0);
        }

        [Fact]
        public async void Combinação_de_5_itens_com_melhor_confiança()
        {
            var metrics = await _service.GetReportItemSets(5);

            var melhorConfiança = metrics.OrderByDescendingConfidence().First();

            var melhorSuporte = metrics.OrderByDescendingSuport().First();

            melhorConfiança.Items.Should().ContainInOrder("leite", "ovos", "café", "fraldas", "manteiga");

            melhorSuporte.Items.Should().ContainInOrder("leite", "ovos", "café", "açúcar", "manteiga");
        }
    }
}