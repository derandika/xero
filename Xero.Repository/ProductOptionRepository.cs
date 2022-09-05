using System;
using System.Collections.Generic;
using System.Text;
using Xero.Domain.Models;
using Xero.Repository.Interface;

namespace Xero.Repository
{
    /// <summary>
    /// Product Option Repository
    /// </summary>
    public class ProductOptionRepository : Repository<ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(XeroContext context)
            : base(context)
        {
        }

        public XeroContext XeroContext
        {
            get { return Context as XeroContext; }
        }
    }
}
