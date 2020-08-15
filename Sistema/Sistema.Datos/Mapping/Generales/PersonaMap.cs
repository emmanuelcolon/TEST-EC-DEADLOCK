using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Almacen
{
    public class Posicion_TrabajoMap : IEntityTypeConfiguration<Posicion_Trabajo>
    {
        public void Configure(EntityTypeBuilder<Posicion_Trabajo> builder)
        {
            builder.ToTable("Posicion_Trabajo")
               .HasKey(c => c.PosicionTrabajoId);
            builder.Property(c => c.Nombre)
                .HasMaxLength(255);
        }
    }
}
