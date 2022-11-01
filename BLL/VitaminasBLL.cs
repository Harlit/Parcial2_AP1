using Microsoft.EntityFrameworkCore;
using Parcial2_AP1.Data;

public class VitaminasBLL
{
    private Contexto IdentityDbContext;
    public VitaminasBLL(Contexto contexto)
    {
        IdentityDbContext = contexto;
    }


    public Vitaminas? Buscar(int Id)
    {
        return IdentityDbContext.Vitaminas
            .Where(p => p.VitaminaId == Id)
            .AsNoTracking()
            .SingleOrDefault();
    }
    public string getNombre(int vitamina)
    {
        var vit = IdentityDbContext.Vitaminas
        .Where(c => c.VitaminaId == vitamina)
        .AsNoTracking()
        .SingleOrDefault();
        return vit.Nombre;
    }
    public string GetUnidadMedida(int vitamina)
    {
        var vit = IdentityDbContext.Vitaminas
        .Where(c => c.VitaminaId == vitamina)
        .AsNoTracking()
        .SingleOrDefault();
        return vit.UnidadMedida;
    }
    public List<Vitaminas> GetList()
    {
        return IdentityDbContext.Vitaminas
            .AsNoTracking()
            .ToList();
    }
}