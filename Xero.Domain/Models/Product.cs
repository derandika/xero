using System.Collections.Generic;

namespace Xero.Domain.Models
{
    /// <summary>
    /// Product Domain model
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public IList<ProductOption> ProductOptions { get; set; }
    }
}
