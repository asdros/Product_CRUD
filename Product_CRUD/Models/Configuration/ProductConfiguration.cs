using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_CRUD.Models.Entities;
using System;

namespace Product_CRUD.Models.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wiśnia",
                    CategoryId = 1,
                    NetPrice = 37.22M,
                    TaxId = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jabłoń",
                    CategoryId = 1,
                    NetPrice = 13.57M,
                    TaxId = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rzodkiewka",
                    CategoryId = 3,
                    NetPrice = 7.22M,
                    TaxId = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Marchew",
                    CategoryId = 3,
                    NetPrice = 1.23M,
                    TaxId = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mak",
                    CategoryId = 2,
                    NetPrice = 37.22M,
                    TaxId = 4
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Śliwka",
                    CategoryId = 1,
                    NetPrice = 35.23M,
                    TaxId = 4
                }
                );
        }
    }
}
