using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizer.Models.Entities;

namespace Quizer.DataAccess.Configurations;

internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnType("uniqueidentifier");
        builder.Property(x => x.Text).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
        builder.Property(x => x.IsCorrect).HasColumnType("bit").IsRequired();
        builder.Property(x => x.QuestionId).HasColumnType("uniqueidentifier").IsRequired();

        builder.HasOne<Question>().WithMany().HasForeignKey(x=>x.QuestionId);
    }
}
