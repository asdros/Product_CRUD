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
                    Price = 37.22M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jabłoń",
                    CategoryId = 1,
                    Price = 13.57M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Rzodkiewka",
                    CategoryId = 3,
                    Price = 7.22M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Marchew",
                    CategoryId = 3,
                    Price = 1.23M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mak",
                    CategoryId = 2,
                    Price = 37.22M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Śliwka",
                    CategoryId = 1,
                    Price = 35.23M
                }
                );
        }
    }
}
