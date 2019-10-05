using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.CloseRain.Infra.Data.Mapping
{
    public class TweetMapping : IEntityTypeConfiguration<Tweeteds>
    {
        public void Configure(EntityTypeBuilder<Tweeteds> builder)
        {
            builder.ToTable("TB_TWEET");

            builder.HasKey(e => e.IdTweet);

            builder.Property(e => e.IdTweet).HasColumnName("Id_Tweet");
            builder.Property(e => e.IdIncidente).HasColumnName("Id_Incidente");
            builder.Property(e => e.DataPublicacao).HasColumnName("Dt_Publicacao");
            builder.Property(e => e.Mensagem).HasColumnName("Dsc_Mensagem");
        }
    }
}
