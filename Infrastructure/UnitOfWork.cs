using Core.Interfaces;
using Core.Models;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<CategoryProp> CategoryProps { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<ProductPropValues> ProductPropValues { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Categories = new BaseRepository<Category>(_context);
            CategoryProps = new BaseRepository<CategoryProp>(_context);
            Products = new BaseRepository<Product>(_context);
            ProductPropValues = new BaseRepository<ProductPropValues>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
