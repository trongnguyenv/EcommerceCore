using City_Shop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City_Shop.Data.Configurations
{
    public class PromitionConfiguration : IEntityTypeConfiguration<Promition>
    {
        public void Configure(EntityTypeBuilder<Promition> builder)
        {
            builder.ToTable("Promitions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
        }
    }
}