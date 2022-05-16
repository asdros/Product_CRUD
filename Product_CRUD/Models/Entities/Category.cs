using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_CRUD.Models.Entities
{
    public class Category
    {
        [Column("CategoryId")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [MaxLength(20, ErrorMessage = "Maksymalna długość to 20 znaków.")]
        public string CategoryName { get; set; }
    }
}
