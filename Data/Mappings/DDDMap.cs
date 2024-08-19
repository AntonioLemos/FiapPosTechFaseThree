using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Data.Mappings
{
    public class DDDMap : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Codigo)
                .IsRequired();

            builder.Property(d => d.Regiao)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(d => d.Estado)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasMany(d => d.Contatos)
                .WithOne(c => c.DDD)
                .HasForeignKey(c => c.DDDId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}