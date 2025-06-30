using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Serialization;

namespace Dima.Api.Data.Mappings
{
    public class LocalMapping : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            builder.ToTable("Local");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CodigoLocal)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.LocalDeApontamento)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
        }
    }
}
