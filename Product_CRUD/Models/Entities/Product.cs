using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_CRUD.Models.Entities
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość to 50 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        [Range(0, short.MaxValue, ErrorMessage = "Identyfikator kategorii musi być liczbą, mniejszą niż 32767.")]
        [ForeignKey(nameof(Category))]
        public short CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Stawka VAT jest wymagana.")]
        [Range(0, byte.MaxValue, ErrorMessage = "Identyfikator kategorii musi być liczbą, mniejszą niż 255.")]
        [ForeignKey(nameof(Tax))]
        public byte TaxId { get; set; }
        public virtual Tax Tax { get; set; }

        [Required(ErrorMessage = "Cena produktu jest wymagana.")]
        [DataType(DataType.Currency, ErrorMessage = "Nieprawidłowa cena!")]
        public decimal NetPrice { get; set; }
    }
}
