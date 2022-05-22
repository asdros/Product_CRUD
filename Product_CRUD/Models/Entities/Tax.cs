using System.ComponentModel.DataAnnotations.Schema;

namespace Product_CRUD.Models.Entities
{
    public class Tax
    {
        [Column("TaxId")]
        public byte Id { get; set; }

        public decimal Value { get; set; }

        public string DisplayValue { get; set; }
    }
}
