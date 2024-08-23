using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryName).HasMaxLength(20).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Children).WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentID).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.ParentID).IsRequired(false);

            builder.Property(x => x.LineAge).IsRequired(false).HasMaxLength(400);
        }
    }
}
