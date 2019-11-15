using FluentAssociation.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentAssociation.Library.Interface
{
    public interface IFluentAssociation<T>
    {
        float Suport { get; set; }
        float Confidence { get; set; }
        void LoadDataWarehouse(List<List<T>> collection);
        Task<List<Metrics1Item<T>>> Get1ItemSets();
        Task<List<Metrics2Item<T>>> Get2ItemSets();
        Task<List<Metrics3Item<T>>> Get3ItemSets();
        Task<List<Metrics4Item<T>>> Get4ItemSets();
    }
}