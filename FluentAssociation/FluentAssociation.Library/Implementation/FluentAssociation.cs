using FluentAssociation.Library.Exception;
using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public class FluentAssociation<T> : IFluentAssociation<T>
    {
        private List<List<T>> _transactions;
        private List<T> _itens;

        public float MinSuport { get; set; } = 0.2f;

        public async void LoadDataWarehouse(List<List<T>> transaction)
        {
            _transactions = transaction ?? throw new DataWareHouseNotLoadedException();

            _itens = await GetInstanceDistincts();
        }

        private Task<List<T>> GetInstanceDistincts()
        {
            if (_transactions == null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            var itens = new List<T>();

            foreach (var transaction in _transactions)
            {
                foreach (var element in transaction)
                {
                    if (!itens.Contains(element))
                    {
                        itens.Add(element);
                    }
                }
            }

            return Task.FromResult(itens);
        }

        public async Task<List<Metrics1Item<T>>> GetReport1ItemSets()
        {
            if (_transactions == null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            var metrics = new List<Metrics1Item<T>>();

            foreach (var header in _itens)
            {
                var quantity = _transactions
                    .Where(t => t.Contains(header))
                    .Count();

                var suport = (float) quantity / _transactions.Count;

                if (suport >= MinSuport)
                {
                    var metric = new Metrics1Item<T>
                    {
                        Item = header,
                        Suport = suport
                    };

                    metrics.Add(metric);
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics2Item<T>>> GetReport2ItemSets()
        {
            if (_transactions == null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            var oneItemSets = GetReport1ItemSets();

            var metrics = new List<Metrics2Item<T>>();

            var combinations = new List<T[]>();

            var item = (await oneItemSets).Select(m => m.Item).ToList();

            for (int a = 0; a < item.Count; a++)
            {
                for (int b = a + 1; b < item.Count; b++)
                {
                    combinations.Add(new T[2] { item[a], item[b] });
                }
            }

            foreach (var itens in combinations)
            {
                // melhorar aplicando programação dinâmica futuramente

                var countXandY = _transactions
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]))
                    .Count();

                var countX = _transactions
                    .Where(t => t.Contains(itens[0]))
                    .Count();

                var suport = (float)countXandY / _transactions.Count;

                if (suport >= MinSuport)
                {
                    var confidence = suport / ((float) countX / _transactions.Count);

                    var metric = new Metrics2Item<T>
                    {
                        Item1 = itens[0],
                        Item2 = itens[1],
                        Suport = suport,
                        Confidence = confidence
                    };

                    metrics.Add(metric);
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics3Item<T>>> GetReport3ItemSets()
        {
            if (_transactions == null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            var oneItemSets = GetReport1ItemSets();

            var metrics = new List<Metrics3Item<T>>();

            var combinations = new List<T[]>();

            var item = (await oneItemSets).Select(m => m.Item).ToList();

            for (int a = 0; a < item.Count; a++)
            {
                for (int b = a + 1; b < item.Count; b++)
                {
                    for (int c = b + 1; c < item.Count; c++)
                    {
                        combinations.Add(new T[3] { item[a], item[b], item[c] });
                    }
                }
            }

            foreach (var itens in combinations)
            {
                var countXandY = _transactions
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]))
                    .Count();

                var countX = _transactions
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]))
                    .Count();

                var suport = (float) countXandY / _transactions.Count;

                if (suport >= MinSuport)
                {
                    var confidence = suport / ((float) countX / _transactions.Count);

                    var metric = new Metrics3Item<T>
                    {
                        Item1 = itens[0],
                        Item2 = itens[1],
                        Item3 = itens[2],
                        Suport = suport,
                        Confidence = confidence
                    };

                    metrics.Add(metric);
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics4Item<T>>> GetReport4ItemSets()
        {
            if (_transactions == null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            var oneItemSets = GetReport1ItemSets();

            var metrics = new List<Metrics4Item<T>>();

            var combinations = new List<T[]>();

            var item = (await oneItemSets).Select(m => m.Item).ToList();

            for (int a = 0; a < item.Count; a++)
            {
                for (int b = a + 1; b < item.Count; b++)
                {
                    for (int c = b + 1; c < item.Count; c++)
                    {
                        for (int d = c + 1; d < item.Count; d++)
                        {
                            combinations.Add(new T[4] { item[a], item[b], item[c], item[d] });
                        }
                    }
                }
            }

            foreach (var itens in combinations)
            {
                var countXandY = _transactions
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]) && t.Contains(itens[3]))
                    .Count();

                var countX = _transactions
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]))
                    .Count();

                var suport = (float) countXandY / _transactions.Count;

                if (suport >= MinSuport)
                {
                    var confidence = suport / ((float) countX / _transactions.Count);

                    var metric = new Metrics4Item<T>
                    {
                        Item1 = itens[0],
                        Item2 = itens[1],
                        Item3 = itens[2],
                        Item4 = itens[3],
                        Suport = suport,
                        Confidence = confidence
                    };

                    metrics.Add(metric);
                }
            }

            return await Task.FromResult(metrics);
        }
    }
}