using City_Shop.Data.Entities;
using City_Shop.Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace City_Shop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is homepage of City_Shop" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of City_Shop" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of City_Shop" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                }
                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm áo thời trang nam",
                    SeoTitle = "Sản phẩm áo thời trang nam"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men shift",
                    LanguageId = "en-US",
                    SeoAlias = "ao-nam",
                    SeoDescription = "The shift product for men",
                    SeoTitle = "The shift product for men"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Sản phẩm áo thời trang nữ",
                    SeoTitle = "Sản phẩm áo thời trang nữ"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women shift",
                    LanguageId = "en-US",
                    SeoAlias = "ao-nu",
                    SeoDescription = "The shift product for women",
                    SeoTitle = "The shift product for women"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0
                }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo Thun JP",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-thun-jp",
                    SeoDescription = "Áo thun JP thời trang nam",
                    SeoTitle = "Áo thun JP thời trang nam",
                    Details = "Mô tả sản phẩm",
                    Description = ""
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Men T-Shirt JP",
                    LanguageId = "en-US",
                    SeoAlias = "men-t-shift-jp",
                    SeoDescription = "T-shirt JP for men",
                    SeoTitle = "T-shirt JP for men",
                    Details = "Description of product",
                    Description = ""
                }
        );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    CategoryId = 1,
                    ProductId = 1
                }
                );
        }
    }
}