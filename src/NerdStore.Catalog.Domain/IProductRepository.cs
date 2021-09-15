using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(int code);
        Task<IEnumerable<Category>> GetCategories();

        void Add(Category category);
        void Update(Category category);
    }
}
