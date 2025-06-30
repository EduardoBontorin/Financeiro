using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class ApontamentoMapping : IEntityTypeConfiguration<Apontamento>
    {
        public void Configure(EntityTypeBuilder<Apontamento> builder)
        {
            builder.ToTable("Apontamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataApontamento)
                .IsRequired();

            builder.Property(x => x.OrdemDeProducao)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Usuario)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
