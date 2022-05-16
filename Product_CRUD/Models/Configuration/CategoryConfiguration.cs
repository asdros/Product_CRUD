using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Models.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                 (
                 new Category
                 {
                     Id = 1,
                     CategoryName = "Drzewka owocowe"
                 },
                 new Category
                 {
                     Id = 2,
                     CategoryName = "Kwiaty"
                 },
                 new Category
                 {
                     Id = 3,
                     CategoryName = "Nasiona warzyw"
                 }

                 );
        }
    }
}
