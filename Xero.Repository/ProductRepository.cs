using System;
using System.Collections.Generic;
using System.Text;
using Xero.Domain.Models;
using Xero.Repository.Interface;

namespace Xero.Repository
{
    /// <summary>
    /// Product Repository 
    /// </summary>
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(XeroContext context)
            : base(context)
        {
        }

        public XeroContext XeroContext
        {
            get { return Context as XeroContext; }
        }
    }
}
