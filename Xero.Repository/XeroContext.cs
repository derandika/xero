using Microsoft.EntityFrameworkCore;
using Xero.Domain.Models;

namespace Xero.Repository
{
    /// <summary>
    /// Xero DbContext
    /// </summary>
    public class XeroContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        public XeroContext(DbContextOptions<XeroContext> options)
            : base(options)
        {

        }
    }
}
