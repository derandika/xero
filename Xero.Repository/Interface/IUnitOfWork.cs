using System;
using System.Collections.Generic;
using System.Text;

namespace Xero.Repository.Interface
{
    /// <summary>
    /// UnitOfWork Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IProductOptionRepository ProductOptions { get; }
        IProductRepository Products { get; }
        int Complete();
    }
}
