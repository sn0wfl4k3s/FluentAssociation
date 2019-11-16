using FluentAssociation.Library.Exception;
using FluentAssociation.Library.Interface;
using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssociation.Library.Implementation
{
    public class FluentAssociation<T> : IFluentAssociation<T>
    {
        private List<List<T>> _collection;
        private List<T> _elements;

        public float Suport { get; set; } = 0.25f;
        public float Confidence { get; set; } = 0.75f;

        public async void LoadDataWarehouse(List<List<T>> collection)
        {
            _collection = collection ?? throw new DataWareHouseNotLoadedException();

            _elements = await GetInstanceDistincts();
        }

        private Task<List<T>> GetInstanceDistincts()
        {
            var distincts = new List<T>();

            foreach (var transaction in _collection)
            {
                foreach (var element in transaction)
                {
                    if (!distincts.Contains(element))
                    {
                        distincts.Add(element);
                    }
                }
            }

            return Task.FromResult(distincts);
        }

        public Task<List<Metrics1Item<T>>> Get1ItemSets()
        {
            var metrics = new List<Metrics1Item<T>>();

            foreach (var header in _elements)
            {
                var quantity = _collection
                    .Where(t => t.Contains(header))
                    .Count();

                var metric = new Metrics1Item<T>
                {
                    Item = header,
                    Suport = (float)quantity / _collection.Count
                };

                metrics.Add(metric);
            }

            return Task.FromResult(metrics);
        }

        public Task<List<Metrics2Item<T>>> Get2ItemSets()
        {
            var metrics = new List<Metrics2Item<T>>();

            var combinations = new List<T[]>();

            for (int i = 1; i < _elements.Count; ++i)
            {
                for (int j = i; j < _elements.Count; ++j)
                {
                    combinations.Add(new T[2] { _elements[i - 1], _elements[j] });
                }
            }

            foreach (var itens in combinations)
            {
                // melhorar aplicando programação dinâmica futuramente

                var countXandY = _collection
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]))
                    .Count();

                var countX = _collection
                    .Where(t => t.Contains(itens[0]))
                    .Count();

                var suport = (float)countXandY / _collection.Count;

                var confidence = suport / ((float)countX / _collection.Count);

                var metric = new Metrics2Item<T>
                {
                    Item1 = itens[0],
                    Item2 = itens[1],
                    Suport = suport,
                    Confidence = confidence
                };

                metrics.Add(metric);
            }

            return Task.FromResult(metrics);
        }

        public Task<List<Metrics3Item<T>>> Get3ItemSets()
        {
            var metrics = new List<Metrics3Item<T>>();

            var combinations = new List<T[]>();

            for (int i = 2; i < _elements.Count; ++i)
            {
                for (int j = i; j < _elements.Count; ++j)
                {
                    for (int l = j; l < _elements.Count; ++l)
                    {
                        combinations.Add(new T[3] {
                            _elements[i - 2],
                            _elements[j - 1],
                            _elements[l] });
                    }
                }
            }

            foreach (var itens in combinations)
            {
                var countXandY = _collection
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]))
                    .Count();

                var countX = _collection
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]))
                    .Count();

                var suport = (float)countXandY / _collection.Count;

                var confidence = suport / ((float)countX / _collection.Count);

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

            return Task.FromResult(metrics);
        }

        public Task<List<Metrics4Item<T>>> Get4ItemSets()
        {
            var metrics = new List<Metrics4Item<T>>();

            var combinations = new List<T[]>();

            for (int i = 3; i < _elements.Count; ++i)
            {
                for (int j = i; j < _elements.Count; ++j)
                {
                    for (int l = j; l < _elements.Count; ++l)
                    {
                        for (int h = j; h < _elements.Count; ++h)
                        {
                            combinations.Add(new T[4] {
                                _elements[i - 3],
                                _elements[j - 2],
                                _elements[l - 1],
                                _elements[h] });
                        }
                    }
                }
            }

            foreach (var itens in combinations)
            {
                var countXandY = _collection
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]) && t.Contains(itens[3]))
                    .Count();

                var countX = _collection
                    .Where(t => t.Contains(itens[0]) && t.Contains(itens[1]) && t.Contains(itens[2]))
                    .Count();

                var suport = (float)countXandY / _collection.Count;

                var confidence = suport / ((float)countX / _collection.Count);

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

            return Task.FromResult(metrics);
        }
    }
}