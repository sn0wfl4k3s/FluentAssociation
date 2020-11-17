using FluentAssociation.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentAssociation
{
    public interface IFluentAssociation<T>
    {
        /// <summary>
        /// The minimum support for results in reports itemsets. 
        /// The range should be from 0 to 1. 
        /// The value is 0.2 by default. 
        /// </summary>
        float MinSuport { get; set; }
        /// <summary>
        /// Return the distinct items in the transactions laded.
        /// </summary>
        List<T> GetDistinctItems { get; }
        /// <summary>
        /// This method is responsible by load the data and then separate the different elements.
        /// </summary>
        /// <param name="collection">Data warehouse collection or all transactions in a register.</param>
        void LoadDataWarehouse(List<List<T>> collection);
        /// <summary>
        /// get asynchronously an itemsets table with 1 combinations.
        /// </summary>
        Task<List<Metrics1Item<T>>> GetReport1ItemSets();
        /// <summary>
        /// get asynchronously an itemsets table with 2 combinations.
        /// </summary>
        Task<List<Metrics2Item<T>>> GetReport2ItemSets();
        /// <summary>
        /// get asynchronously an itemsets table with 3 combinations.
        /// </summary>
        Task<List<Metrics3Item<T>>> GetReport3ItemSets();
        /// <summary>
        /// get asynchronously an itemsets table with 4 combinations.
        /// </summary>
        Task<List<Metrics4Item<T>>> GetReport4ItemSets();
    }
}