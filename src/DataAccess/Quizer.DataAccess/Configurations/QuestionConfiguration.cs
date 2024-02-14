using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizer.Models.Entities;

namespace Quizer.DataAccess.Configurations;

internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier");
        builder.Property(x => x.Text).HasColumnType("nvarchar").HasMaxLength(700).IsRequired();
        builder.Property(x => x.Point).HasColumnType("tinyint").IsRequired();
        builder.Property(x => x.QuestionSetId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasOne<QuestionSet>().WithMany().HasForeignKey(x=>x.QuestionSetId);
    }
}
