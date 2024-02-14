using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizer.Models.Entities;

namespace Quizer.DataAccess.Configurations;

internal class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.ToTable("Subscribers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier");
        builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.FullName).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
    }
}
