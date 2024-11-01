using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ITI_Project.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> entity)
        {





            entity.HasKey(e => e.TopicId).HasName("topic_topicid_primary");

            entity.ToTable("topic");

            entity.Property(e => e.TopicId)
                .ValueGeneratedNever()
                .HasColumnName("TopicID");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasMany(t => t.Courses)
                .WithOne(c => c.Topic)
                .HasForeignKey(c => c.TopicId)
                .OnDelete(DeleteBehavior.Restrict); 


        }
    }
}
