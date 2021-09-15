using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetByCategory(int code)
        {
            return await _context.Products.AsNoTracking()
                .Include(p => p.Category)
                .Where(c => c.Category.Code == code).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
