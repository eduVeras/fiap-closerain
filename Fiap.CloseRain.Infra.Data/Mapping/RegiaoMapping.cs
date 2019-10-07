using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.CloseRain.Infra.Data.Mapping
{
    public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            //Table name

            builder.ToTable("TB_REGIAO");
            //Key
            builder.HasKey(e => e.IdRegiao);

            builder.Property(e => e.IdRegiao).HasColumnName("Id_Regiao");
            builder.Property(e => e.Cep).HasColumnName("Dsc_Cep");
            builder.Property(e => e.Logradouro).HasColumnName("Dsc_Logradouro");
            builder.Property(e => e.Numero).HasColumnName("Nr_Numero");
            builder.Property(e => e.Complemento).HasColumnName("Dsc_Complemento");
            builder.Property(e => e.Bairro).HasColumnName("Dsc_Bairro");
            builder.Property(e => e.Municipio).HasColumnName("Dsc_Municipio");
            builder.Property(e => e.Uf).HasColumnName("Dsc_Uf");
            builder.Property(e => e.Latitude).HasColumnName("Nr_Latitude");
            builder.Property(e => e.Longitude).HasColumnName("Nr_Longitude");
        }
    }
}
