using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class CONTATOMap : IEntityTypeConfiguration<CONTATO>
    {
        public void Configure(EntityTypeBuilder<CONTATO> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasOne(c => c.DDD)
                .WithMany(d => d.Contatos)
                .HasForeignKey(c => c.DDDId)
                .IsRequired();
        }
    }
}
