using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Verduras
{
    [Key]
    public int VerduraId { get; set; }
    [Required(ErrorMessage = "Digite el nombre de la verdura.")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Digite la fecha.")]
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string? Observacion { get; set; }
    [ForeignKey("VerduraId"), Required(ErrorMessage = "Una verdura necesita vitaminas.")]
    public List<VerdurasDetalle> Detalle { get; set; } = new List<VerdurasDetalle>();
}