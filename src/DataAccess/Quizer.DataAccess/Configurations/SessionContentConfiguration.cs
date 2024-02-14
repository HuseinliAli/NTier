using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizer.Models.Entities;

namespace Quizer.DataAccess.Configurations;

internal class SessionContentConfiguration : IEntityTypeConfiguration<SessionContent>
{
    public void Configure(EntityTypeBuilder<SessionContent> builder)
    {
        builder.ToTable("SessionContents");
        builder.HasKey(x => new { x.SessionId,x.QuestionId,x.SubscriberId });
        builder.Property(x => x.SessionId).HasColumnType("uniqueidentifier");
        builder.Property(x => x.SubscriberId).HasColumnType("uniqueidentifier");
        builder.Property(x => x.QuestionId).HasColumnType("uniqueidentifier");
        builder.Property(x => x.AnswerId).HasColumnType("uniqueidentifier");
        builder.Property(x => x.Success).HasColumnType("bit").IsRequired();

        builder.HasOne<Session>().WithMany().HasForeignKey(x => x.SessionId);
        builder.HasOne<Question>().WithMany().HasForeignKey(x => x.QuestionId);
        builder.HasOne<Subscriber>().WithMany().HasForeignKey(x => x.SubscriberId);
        builder.HasOne<Answer>().WithMany().HasForeignKey(x => x.AnswerId).IsRequired();
    }
}