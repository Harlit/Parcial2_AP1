using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2_AP1.Data;

public class VerduraBLL
{
    private Contexto IdentityDbContext;

    public VerduraBLL(Contexto contexto)
    {
        IdentityDbContext = contexto;
    }

    public bool Existe(int verduraId)
    {
        return IdentityDbContext.Verduras.Any(o => o.VerduraId == verduraId);
    }

    private bool Insertar(Verduras verdura)
    {
        IdentityDbContext.Verduras.Add(verdura);
        return IdentityDbContext.SaveChanges() > 0;
    }

    private bool Modificar(Verduras verdura)
    {
        IdentityDbContext.Entry(verdura).State = EntityState.Modified;
        return IdentityDbContext.SaveChanges() > 0;
    }

    public bool Guardar(Verduras verdura)
    {
        if (!Existe(verdura.VerduraId))
            return this.Insertar(verdura);
        else
            return this.Modificar(verdura);
    }

    public bool Eliminar(Verduras verdura)
    {
        IdentityDbContext.Entry(verdura).State = EntityState.Deleted;
        return IdentityDbContext.SaveChanges() > 0;
    }

    public Verduras? Buscar(int verduraId)
    {
        return IdentityDbContext.Verduras
                .Where(o => o.VerduraId == verduraId)
                .AsNoTracking()
                .SingleOrDefault();

    }
    public List<Verduras> GetList(Expression<Func<Verduras, bool>> Criterio)
    {
        return IdentityDbContext.Verduras
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }

}