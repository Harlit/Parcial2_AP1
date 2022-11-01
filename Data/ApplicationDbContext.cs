using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Parcial2_AP1.Data;

public class Contexto : IdentityDbContext
{
    public DbSet<Verduras> Verduras { get; set; }
    public DbSet<Vitaminas> Vitaminas { get; set; }
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vitaminas>().HasData(
            new Vitaminas { VitaminaId = 1, Nombre = "Vitamina C", Existencia = 0, UnidadMedida = "(mg)" },
            new Vitaminas { VitaminaId = 2, Nombre = "Betaina", Existencia = 0, UnidadMedida = "(mg)" },
            new Vitaminas { VitaminaId = 3, Nombre = "Vitamina K", Existencia = 0, UnidadMedida = "(mg)" },
            new Vitaminas { VitaminaId = 4, Nombre = "Vitamina D", Existencia = 0, UnidadMedida = "(mg)" },
            new Vitaminas { VitaminaId = 5, Nombre = "Vitamina A", Existencia = 0, UnidadMedida = "(mg)" }


        );
    }
}
