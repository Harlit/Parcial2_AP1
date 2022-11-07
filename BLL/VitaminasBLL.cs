using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2_AP1.Data;

public class VitaminasBLL
{
    private Contexto IdentityDbContext;

    public VitaminasBLL(Contexto contexto)
    {
        IdentityDbContext = contexto;
    }

    public bool Existe(int vitaminaId)
    {
        return IdentityDbContext.Vitaminas.Any(o => o.VitaminaId == vitaminaId);
    }

    private bool Insertar(Vitaminas vitamina)
    {
        IdentityDbContext.Vitaminas.Add(vitamina);
        return IdentityDbContext.SaveChanges() > 0;
    }

    private bool Modificar(Vitaminas vitamina)
    {
        IdentityDbContext.Entry(vitamina).State = EntityState.Modified;
        return IdentityDbContext.SaveChanges() > 0;
    }

    public bool Guardar(Vitaminas vitamina)
    {
        if (!Existe(vitamina.VitaminaId))
            return this.Insertar(vitamina);
        else
            return this.Modificar(vitamina);
    }

    public bool Eliminar(Vitaminas vitamina)
    {
        IdentityDbContext.Entry(vitamina).State = EntityState.Deleted;
        return IdentityDbContext.SaveChanges() > 0;
    }

    public Vitaminas? Buscar(int vitaminaId)
    {
        return IdentityDbContext.Vitaminas
                .Where(o => o.VitaminaId == vitaminaId)
                .AsNoTracking()
                .SingleOrDefault();

    }
    public List<Vitaminas> GetList(Expression<Func<Vitaminas, bool>> Criterio)
    {
        return IdentityDbContext.Vitaminas
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }

}