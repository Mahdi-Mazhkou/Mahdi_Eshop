using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.FeatureID);
            builder.Property(x => x.FeatureName).HasMaxLength(256).IsRequired();
            builder.HasMany(x=>x.CategoryFeatures).WithOne(x=>x.Feature)
                .HasForeignKey(x=>x.FeatureID).OnDelete(DeleteBehavior.NoAction);
        }
    }

}
