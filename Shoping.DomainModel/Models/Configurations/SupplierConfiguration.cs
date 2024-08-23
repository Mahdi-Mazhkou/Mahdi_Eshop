using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierID);
            builder.Property(x => x.SupplierName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SupplierDescription).HasMaxLength(4000);
            builder.HasMany(x => x.Products).WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
