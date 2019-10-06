using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.CloseRain.Infra.Data.Mapping
{
    public class IncidenteMapping : IEntityTypeConfiguration<Incidente>
    {
        public void Configure(EntityTypeBuilder<Incidente> builder)
        {
            //Table name
            builder.ToTable("TB_INCIDENTE");

            //Keys
            builder.HasKey(e => e.IdIncidente);

            //Props
            builder.Property(e => e.IdIncidente).HasColumnName("Id_Incidente");
            builder.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            builder.Property(e => e.IdRegiao).HasColumnName("Id_Regiao");
            builder.Property(e => e.TipoIncidente).HasColumnName("Dsc_TipoIncidente");
            builder.Property(e => e.Publicado).HasColumnName("Flag_Publicado");
            builder.Property(e => e.DataIncidente).HasColumnName("Dt_Incidente");
            builder.Property(e => e.DataPublicacao).HasColumnName("Dt_Publicacao");
        }
    }
}
