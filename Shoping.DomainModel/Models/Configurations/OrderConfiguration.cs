using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.AddressID).IsRequired();
            builder.Property(x => x.OrderDescription).HasMaxLength(400);
            builder.Property(x => x.OrderDate).IsRequired();
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
