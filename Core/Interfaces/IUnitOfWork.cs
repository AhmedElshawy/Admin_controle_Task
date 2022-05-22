using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Product> Products { get; }
        IBaseRepository<ProductPropValues> ProductPropValues { get; }
        IBaseRepository<CategoryProp> CategoryProps { get; }

        Task<int> CompleteAsync();
    }
}
