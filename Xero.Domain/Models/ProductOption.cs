using System;


namespace Xero.Domain.Models
{
    /// <summary>
    /// Product Option Domain model
    /// </summary>
    public class ProductOption
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
