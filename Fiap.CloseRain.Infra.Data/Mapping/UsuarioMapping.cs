using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.CloseRain.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Table name
            builder.ToTable("TB_USUARIO");

            //Key
            builder.HasKey(e => e.IdUsuario);

            //Props
            builder.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            builder.Property(e => e.IdRegiao).HasColumnName("Id_Regiao");
            builder.Property(e => e.Nome).HasColumnName("Dsc_Nome");
            builder.Property(e => e.Email).HasColumnName("Dsc_Email");
            builder.Property(e => e.Senha).HasColumnName("Dsc_Senha");
            builder.Property(e => e.Nascimento).HasColumnName("Dt_Nasc");
            builder.Property(e => e.Telefone).HasColumnName("Dsc_Telefone");
            builder.Property(e => e.Ativo).HasColumnName("Flag_Ativo");
            builder.Property(e => e.DataCadastro).HasColumnName("Dt_Cadastro");
            builder.Property(e => e.DataUltimaAtualizacao).HasColumnName("Dt_UltimaAtualizacao");
        }
    }
}
