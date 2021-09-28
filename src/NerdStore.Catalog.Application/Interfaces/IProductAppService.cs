using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductViewModel>> GetByCategory(int code);
        Task<ProductViewModel> GetById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task Add(ProductViewModel productViewModel);
        Task Update(ProductViewModel productViewModel);

        Task<ProductViewModel> DebitStock(Guid id, int amount);
        Task<ProductViewModel> ReplenishStock(Guid id, int amount);
    }
}
