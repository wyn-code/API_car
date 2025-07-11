using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Estado;
using CarDealerAPI.Models.Marcas;
using CarDealerAPI.Models.Modelos;
using CarDealerAPI.Models.Tipo_Auto;
using CarDealerAPI.Models.Provincia;
using Microsoft.EntityFrameworkCore;
using System;
using CarDealerAPI.Models.Es0Km;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CarDealerAPI.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Auto> Autos { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<TipoDeAuto> TiposDeAuto { get; set; } = null!;
        public DbSet<Marca> Marcas { get; set; } = null!;
        public DbSet<Modelo> Modelos { get; set; } = null!;
        public DbSet<Condicion> Condicion { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeAuto>().HasIndex(a => a.tipo_autos).IsUnique();
            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id_Marca = 1, Nombre_Marca = "Toyota" },
                new Marca { Id_Marca = 2, Nombre_Marca = "Ford" },
                new Marca { Id_Marca = 3, Nombre_Marca = "Honda" },
                new Marca { Id_Marca = 4, Nombre_Marca = "Chevrolet" },
                new Marca { Id_Marca = 5, Nombre_Marca = "BMW" }
            );


            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Id_Modelo = 1, Nombre_Modelo = "Corolla", },
                new Modelo { Id_Modelo = 2, Nombre_Modelo = "Hilux",  },
                new Modelo { Id_Modelo = 3, Nombre_Modelo = "F-150",  },
                new Modelo { Id_Modelo = 4, Nombre_Modelo = "Civic",  },
                new Modelo { Id_Modelo = 5, Nombre_Modelo = "Camaro",  },
                new Modelo { Id_Modelo = 6, Nombre_Modelo = "Serie 3",  }
            );


            modelBuilder.Entity<TipoDeAuto>().HasData(
                new TipoDeAuto { Id_Tipo_Auto = 1, tipo_autos = "Sedan" },
                new TipoDeAuto { Id_Tipo_Auto = 2, tipo_autos = "SUV" },
                new TipoDeAuto { Id_Tipo_Auto = 3, tipo_autos = "Pickup" },
                new TipoDeAuto { Id_Tipo_Auto = 4, tipo_autos = "Coupé" },
                new TipoDeAuto { Id_Tipo_Auto = 5, tipo_autos = "Hatchback" },
                new TipoDeAuto { Id_Tipo_Auto = 6, tipo_autos = "Convertible" }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, Nombre = "Disponible" },
                new Estado { Id = 2, Nombre = "Vendido" }
            );

            modelBuilder.Entity<Condicion>().HasData(

                new Condicion { Id_condicion = 1, condicionName = "0KM" },
                new Condicion { Id_condicion = 2, condicionName = "Usado" }

            );

            modelBuilder.Entity<Auto>().Property(a => a.fecha_creacion).HasDefaultValueSql("GETUTCDATE()");


            modelBuilder.Entity<Auto>().HasData(
                new Auto
                {
                    Id_Autos = 1,
                    Marca = "Toyota",
                    Id_condicion = 1,
                    Disponible = true,
                    Precio = 35000.00,
                    Descripcion = "Toyota Corolla usado, excelente estado, único dueño.",
                    Motor = "1.8L 4 cilindros",
                    Año_Modelo = 2019,
                    Id_Tipo_Auto = 1, // Sedan
                    EstadoId = 1,
                    Id_Modelo = 1,
                    fecha_creacion = new DateTime(2023, 1, 1)
                },
                new Auto
                {
                    Id_Autos = 2,
                    Marca = "Toyota",
                    Id_condicion = 2,
                    Disponible = true,
                    Precio = 40000.00,
                    Descripcion = "Toyota Hilux, pickup usada, ideal para trabajo.",
                    Motor = "2.8L diesel",
                    Año_Modelo = 2020,
                    Id_Tipo_Auto = 3, // Pickup
                    EstadoId = 1,
                    Id_Modelo = 2,
                    fecha_creacion = new DateTime(2023, 3, 15)
                },
                new Auto
                {
                    Id_Autos = 3,
                    Marca = "Ford",
                    Id_condicion = 1,
                    Disponible = true,
                    Precio = 45000.00,
                    Descripcion = "Ford F-150 0KM, versión full equipo.",
                    Motor = "3.3L V6",
                    Año_Modelo = 2024,
                    Id_Tipo_Auto = 3, // Pickup
                    EstadoId = 1,
                    Id_Modelo = 3,
                    fecha_creacion = new DateTime(2024, 5, 10)
                },
                new Auto
                {
                    Id_Autos = 4,
                    Marca = "Honda",
                    Id_condicion = 2,
                    Disponible = false,
                    Precio = 22000.00,
                    Descripcion = "Honda Civic usado, cuidado y mantenido, vendido recientemente.",
                    Motor = "2.0L 4 cilindros",
                    Año_Modelo = 2018,
                    Id_Tipo_Auto = 1, // Sedan
                    EstadoId = 2,
                    Id_Modelo = 4,
                    fecha_creacion = new DateTime(2022, 7, 20)
                },
                new Auto
                {
                    Id_Autos = 5,
                    Marca = "BMW",
                    Id_condicion = 1,
                    Disponible = true,
                    Precio = 52000.00,
                    Descripcion = "BMW Serie 3 convertible, edición especial 0KM.",
                    Motor = "2.0L turbo",
                    Año_Modelo = 2024,
                    Id_Tipo_Auto = 6, // Convertible
                    EstadoId = 1,
                    Id_Modelo = 6,
                    fecha_creacion = new DateTime(2024, 6, 5)
                }
            );

        }

    }
}
