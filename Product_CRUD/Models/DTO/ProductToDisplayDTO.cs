using System;

namespace Product_CRUD.Models.DTO
{
    public class ProductToDisplayDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string TaxDisplayValue { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
    }
}
