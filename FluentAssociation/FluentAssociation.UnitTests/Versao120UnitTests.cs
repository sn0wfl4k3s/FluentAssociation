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
            var transactions = new List<List<string>>
            {
                new List<string> { "milk", "eggs", "coffee", "sugar", "diapers", "butter" },
                new List<string> { "milk", "coffee", "flour" },
                new List<string> { "milk", "eggs", "sugar" },
                new List<string> { "coffee", "sugar" },
                new List<string> { "diapers" },
                new List<string> { "butter", "eggs", "milk" },
                new List<string> { "coffee", "sugar", "milk", "eggs" },
                new List<string> { "flour", "butter", "eggs" },
                new List<string> { "butter", "eggs", "milk", "coffee", "sugar" },
                new List<string> { "diapers", "coffee", "beer" }
            };

            _service = new FluentAssociation<string>();

            _service.LoadDataWarehouse(transactions);
        }

        [Fact]
        public async void Test_1ItemSet()
        {
            var metrics = await _service.GetReportItemSets(1);

            var milk = metrics.GetItemSet("milk");

            milk.Suport.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_2ItemSet()
        {
            var metrics = await _service.GetReportItemSets(2);

            // [milk] => [eggs]
            var example = metrics.GetItemSet("milk", "eggs");

            example.Suport.Should().Be(0.5f);

            example.Confidence.Should().BeApproximately(0.83f, 1);
        }

        [Fact]
        public async void Test_3ItemSet()
        {
            var metrics = await _service.GetReportItemSets(3);

            // [milk, eggs] => [coffee]
            var example = metrics.GetItemSet("milk", "eggs", "coffee");

            example.Suport.Should().Be(0.3f);

            example.Confidence.Should().Be(0.6f);
        }

        [Fact]
        public async void Test_4ItemSet()
        {
            var metrics = await _service.GetReportItemSets(4);

            // [milk, eggs, coffee] => [sugar]
            var example = metrics.GetItemSet("milk", "eggs", "coffee", "sugar");

            example.Suport.Should().Be(0.3f);

            example.Confidence.Should().Be(1f);
        }

        [Fact]
        public async void Combinação_de_4_itens_com_melhor_confiança()
        {
            var metrics = await _service.GetReportItemSets(4);

            var bestConfidence = metrics.OrderByDescendingConfidence().First();

            bestConfidence.Items.ElementAt(0).Should().BeEquivalentTo("milk");

            bestConfidence.Items.ElementAt(1).Should().BeEquivalentTo("eggs");

            bestConfidence.Items.ElementAt(2).Should().BeEquivalentTo("coffee");

            bestConfidence.Items.ElementAt(3).Should().BeEquivalentTo("sugar");

            bestConfidence.Suport.Should().BeApproximately(0.3f, 1);
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

            var bestConfidence = metrics.OrderByDescendingConfidence().First();

            var bestSuport = metrics.OrderByDescendingSuport().First();

            bestConfidence.Items.Should().ContainInOrder("milk", "eggs", "coffee", "diapers", "butter");

            bestSuport.Items.Should().ContainInOrder("milk", "eggs", "coffee", "sugar", "butter");
        }
    }
}