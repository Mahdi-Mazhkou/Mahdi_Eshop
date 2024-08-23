using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models.Configurations
{
    public class KeyWordConfiguration : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasKey(x=>x.KeyWordID);
            builder.Property(x => x.KeyWordText).HasMaxLength(100).IsRequired();
            //builder.HasMany(x => x.ProductKeywords)
            //    .WithOne(x => x.KeyWord)
            //    .HasForeignKey(x => x.keywordID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
