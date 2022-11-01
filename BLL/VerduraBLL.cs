using Microsoft.EntityFrameworkCore;
using Parcial2_AP1.Data;

public class VerdurasBLL
{
    private Contexto IdentityDbContext;

    public VerdurasBLL(Contexto contexto)
    {
        IdentityDbContext = contexto;
    }
    public bool Existe(int Id)
    {
        return IdentityDbContext.Verduras.Any(c => c.VerduraId == Id);
    }
    public bool Guardar(Verduras verdura)
    {
        bool paso = false;

        if (!Existe(verdura.VerduraId))
            paso = Insertar(verdura);
        else
            paso = Modificar(verdura);
        return paso;

    }
    private bool Insertar(Verduras verdura)
    {
        IdentityDbContext.Verduras.Add(verdura);

        foreach (var item in verdura.Detalle)
        {
            var vitamina = IdentityDbContext.Vitaminas.Find(item.VitaminaId);
            vitamina!.Existencia += item.Cantidad;
        }

        bool insertar = IdentityDbContext.SaveChanges() > 0;
        IdentityDbContext.Entry(verdura).State = EntityState.Detached;
        return insertar;
    }

    private bool Modificar(Verduras verdura)
    {
        var anterior = IdentityDbContext.Verduras
       .Where(c => c.VerduraId == verdura.VerduraId)
       .Include(c => c.Detalle)
       .AsNoTracking()
       .SingleOrDefault();

        foreach (var item in anterior!.Detalle)
        {
            var vitamina = IdentityDbContext.Vitaminas.Find(item.VitaminaId);

            vitamina!.Existencia -= item.Cantidad;
        }
        IdentityDbContext.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerduraId={verdura.VerduraId};");

        foreach (var item in verdura.Detalle)
        {
            var vitamina = IdentityDbContext.Vitaminas.Find(item.VitaminaId);
            vitamina!.Existencia += item.Cantidad;


            IdentityDbContext.Entry(item).State = EntityState.Added;
        }

        IdentityDbContext.Entry(verdura).State = EntityState.Modified;

        var guardo = IdentityDbContext.SaveChanges() > 0;
        IdentityDbContext.Entry(verdura).State = EntityState.Detached;
        return guardo;
    }
    public bool Eliminar(Verduras verdura)
    {
        IdentityDbContext.Verduras.Add(verdura);

        foreach (var item in verdura.Detalle)
        {
            var vitamina = IdentityDbContext.Vitaminas.Find(item.VitaminaId);
            vitamina!.Existencia -= item.Cantidad;

        }
        IdentityDbContext.Entry(verdura).State = EntityState.Deleted;

        bool elimino = IdentityDbContext.SaveChanges() > 0;
        IdentityDbContext.Entry(verdura).State = EntityState.Detached;

        return elimino;
    }

    public Verduras? Buscar(int verdura)
    {
        return IdentityDbContext.Verduras
        .Include(c => c.Detalle)
        .Where(c => c.VerduraId == verdura)
        .AsNoTracking()
        .SingleOrDefault();
    }
    public List<Verduras> GetList()
    {
        return IdentityDbContext.Verduras.AsNoTracking().ToList();
    }

    
}