using fair.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fair.infra.Configuration
{
    public class FairConfiguration : IEntityTypeConfiguration<Fair>
    {
        public void Configure(EntityTypeBuilder<Fair> builder)
        {
            builder.ToTable("DEINFO_AB_FEIRASLIVRES_2014");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("ID")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(o => o.Latitude)
           .HasColumnName("LAT")
           .HasColumnType("bigint")
           .IsRequired();

            builder.Property(o => o.Longitude)
           .HasColumnName("LONG")
           .HasColumnType("bigint")
           .IsRequired();

            builder.Property(o => o.SetCens)
           .HasColumnName("SETCENS")
           .HasColumnType("varchar(32)")
           .IsRequired();

            builder.Property(o => o.AreaP)
           .HasColumnName("AREAP")
           .HasColumnType("varchar(32)")
           .IsRequired();

            builder.Property(o => o.DistrictCode)
           .HasColumnName("CODDIST")
           .HasColumnType("int")
           .IsRequired();

            builder.Property(o => o.District)
           .HasColumnName("DISTRITO")
           .HasColumnType("varchar(128)")
           .IsRequired();

            builder.Property(o => o.SubCityHallCode)
            .HasColumnName("CODSUBPREF")
           .HasColumnType("int")
           .IsRequired();

            builder.Property(o => o.SubCityHall)
           .HasColumnName("SUBPREFE")
           .HasColumnType("varchar(128)")
           .IsRequired();

            builder.Property(o => o.Region5)
           .HasColumnName("REGIAO5")
           .HasColumnType("varchar(128)")
           .IsRequired();


            builder.Property(o => o.Region8)
            .HasColumnName("REGIAO8")
           .HasColumnType("varchar(128)")
           .IsRequired();

            builder.Property(o => o.FairName)
           .HasColumnName("NOME_FEIRA")
           .HasColumnType("varchar(128)")
           .IsRequired();

            builder.Property(o => o.Register)
           .HasColumnName("REGISTRO")
           .HasColumnType("varchar(32)")
           .IsRequired();

            builder.Property(o => o.Address)
           .HasColumnName("LOGRADOURO")
           .HasColumnType("varchar(256)")
           .IsRequired();

            builder.Property(o => o.Number)
           .HasColumnName("NUMERO")
           .HasColumnType("varchar(32)");

            builder.Property(o => o.Neighborhood)
           .HasColumnName("BAIRRO")
           .HasColumnType("varchar(128)")
           .IsRequired();

            builder.Property(o => o.Reference)
           .HasColumnName("REFERENCIA")
           .HasColumnType("varchar(128)");
        }
    }
}
