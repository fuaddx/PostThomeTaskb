using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Dal.Configurations
{
    public class PostConfiguration:IEntityTypeConfiguration<Post>
    {
       public void Configure(EntityTypeBuilder<Post> builder) {

            builder.Property(x => x.Content).IsRequired()
                .HasMaxLength(512);
            builder.Property(x => x.UpdatedCount).IsRequired()
                .HasDefaultValue(0);
            builder.HasOne(x => x.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(x => x.AppUserId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
