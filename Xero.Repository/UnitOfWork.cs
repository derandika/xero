using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xero.Repository.Interface;

namespace Xero.Repository
{
    /// <summary>
    /// UnitOfWork for EF operations
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly XeroContext _context;

        public UnitOfWork(XeroContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            ProductOptions = new ProductOptionRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IProductOptionRepository ProductOptions { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
