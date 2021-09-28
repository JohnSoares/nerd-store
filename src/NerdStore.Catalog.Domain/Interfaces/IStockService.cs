using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Interfaces
{
    public interface IStockService : IDisposable
    {
        Task<bool> DebitStock(Guid productId, int amount);
        Task<bool> ReplenishStock(Guid productId, int amount);
    }
}
