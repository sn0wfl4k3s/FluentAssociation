using FluentAssociation.Library.Exception;
using FluentAssociation.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public class FluentAssociation<T> : IFluentAssociation<T>
    {
        private List<List<T>> _transactions;
        private List<T> _distinctItems = new();
        private float _minSuport = .2f;

        public float MinSuport 
        {
            get => _minSuport;
            set
            {
                if (value is < 0 or > 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _minSuport = value;
            }
        }

        public List<T> GetDistinctItems 
            => _transactions is null ? throw new DataWareHouseNotLoadedException() : _distinctItems;

        public async void LoadDataWarehouse(List<List<T>> transactions)
        {
            _transactions = transactions ?? throw new ArgumentNullException();

            _distinctItems = _transactions
                .SelectMany(transacao => transacao.Select(item => item))
                .Distinct()
                .ToList();

            await Task.CompletedTask;
        }

        public async Task<List<Metrics1Item<T>>> GetReport1ItemSets()
        {
            if (_transactions is null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            if (_distinctItems.Count is 0)
            {
                throw new DistinctItemsLengthTooLowException();
            }

            var metrics = new List<Metrics1Item<T>>();

            for (int i = 0; i < _distinctItems.Count; ++i)
            {
                int itemQuantity = _transactions.Count(t => t.Contains(_distinctItems[i]));

                float suport = (float)itemQuantity / _transactions.Count;

                if (suport >= MinSuport)
                {
                    var metric = new Metrics1Item<T>
                    {
                        Item = _distinctItems[i],
                        Suport = suport
                    };

                    metrics.Add(metric);
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics2Item<T>>> GetReport2ItemSets()
        {
            if (_transactions is null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            if (_distinctItems.Count < 2)
            {
                throw new DistinctItemsLengthTooLowException();
            }

            var metrics = new List<Metrics2Item<T>>();

            for (int a = 0; a < _distinctItems.Count; ++a)
            {
                for (int b = a + 1; b < _distinctItems.Count; ++b)
                {
                    int countXandY = _transactions.Count(t => t.Contains(_distinctItems[a]) && t.Contains(_distinctItems[b]));

                    int countX = _transactions.Count(t => t.Contains(_distinctItems[a]));

                    float suport = (float)countXandY / _transactions.Count;

                    if (suport >= MinSuport)
                    {
                        float confidence = suport / ((float)countX / _transactions.Count);

                        var metric = new Metrics2Item<T>
                        {
                            Item1 = _distinctItems[a],
                            Item2 = _distinctItems[b],
                            Suport = suport,
                            Confidence = confidence
                        };

                        metrics.Add(metric);
                    }
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics3Item<T>>> GetReport3ItemSets()
        {
            if (_transactions is null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            if (_distinctItems.Count < 3)
            {
                throw new DistinctItemsLengthTooLowException();
            }

            var metrics = new List<Metrics3Item<T>>();

            for (int a = 0; a < _distinctItems.Count; ++a)
            {
                for (int b = a + 1; b < _distinctItems.Count; ++b)
                {
                    for (int c = b + 1; c < _distinctItems.Count; ++c)
                    {
                        int countXandY = _transactions.Count(t => t.Contains(_distinctItems[a]) && t.Contains(_distinctItems[b]) && t.Contains(_distinctItems[c]));

                        int countX = _transactions.Count(t => t.Contains(_distinctItems[a]) && t.Contains(_distinctItems[b]));

                        float suport = (float)countXandY / _transactions.Count;

                        if (suport >= MinSuport)
                        {
                            float confidence = suport / ((float)countX / _transactions.Count);

                            var metric = new Metrics3Item<T>
                            {
                                Item1 = _distinctItems[a],
                                Item2 = _distinctItems[b],
                                Item3 = _distinctItems[c],
                                Suport = suport,
                                Confidence = confidence
                            };

                            metrics.Add(metric);
                        }
                    }
                }
            }

            return await Task.FromResult(metrics);
        }

        public async Task<List<Metrics4Item<T>>> GetReport4ItemSets()
        {
            if (_transactions is null)
            {
                throw new DataWareHouseNotLoadedException();
            }

            if (_distinctItems.Count < 4)
            {
                throw new DistinctItemsLengthTooLowException();
            }

            var metrics = new List<Metrics4Item<T>>();

            for (int a = 0; a < _distinctItems.Count; ++a)
            {
                for (int b = a + 1; b < _distinctItems.Count; ++b)
                {
                    for (int c = b + 1; c < _distinctItems.Count; ++c)
                    {
                        for (int d = c + 1; d < _distinctItems.Count; ++d)
                        {
                            int countXandY = _transactions.Count(t => t.Contains(_distinctItems[a]) && t.Contains(_distinctItems[b]) && t.Contains(_distinctItems[c]) && t.Contains(_distinctItems[d]));

                            int countX = _transactions.Count(t => t.Contains(_distinctItems[a]) && t.Contains(_distinctItems[b]) && t.Contains(_distinctItems[c]));

                            float suport = (float)countXandY / _transactions.Count;

                            if (suport >= MinSuport)
                            {
                                float confidence = suport / ((float)countX / _transactions.Count);

                                var metric = new Metrics4Item<T>
                                {
                                    Item1 = _distinctItems[a],
                                    Item2 = _distinctItems[b],
                                    Item3 = _distinctItems[c],
                                    Item4 = _distinctItems[d],
                                    Suport = suport,
                                    Confidence = confidence
                                };

                                metrics.Add(metric);
                            }
                        }
                    }
                }
            }

            return await Task.FromResult(metrics);
        }
    }
}