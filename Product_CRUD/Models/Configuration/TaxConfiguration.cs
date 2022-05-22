using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Models.Configuration
{
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasData(
                new Tax
                {
                    Id = 1,
                    Value = 1.23M,
                    DisplayValue = "23%"
                },
                new Tax
                {
                    Id = 2,
                    Value = 1.08M,
                    DisplayValue="8%"
                },
                new Tax
                {
                    Id = 3,
                    Value = 1.05M,
                    DisplayValue="5%"
                },
                new Tax
                {
                    Id = 4,
                    Value = 1.00M,
                    DisplayValue="0%"
                });
        }
    }
}
