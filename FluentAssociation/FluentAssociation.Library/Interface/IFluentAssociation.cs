using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public interface IFluentAssociation<T>
    {
        float MinSuport { get; set; }
        void LoadDataWarehouse(List<List<T>> collection);
        Task<List<Metrics1Item<T>>> GetReport1ItemSets();
        Task<List<Metrics2Item<T>>> GetReport2ItemSets();
        Task<List<Metrics3Item<T>>> GetReport3ItemSets();
        Task<List<Metrics4Item<T>>> GetReport4ItemSets();
    }
}