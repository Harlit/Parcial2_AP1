using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class VerdurasDetalle
{
    [Key]
    public int VerdurasDetalleId { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "Un detalle debe tener a una verdura.")]
    public int VerduraId { get; set; }
    [Required(ErrorMessage = "Digite el nombre de la verduraId.")]
    public int VitaminaId { get; set; }
    [Required(ErrorMessage = "Digite el nombre de la VitaminaId.")]
    public double Cantidad { get; set; }
    public string? Descripcion { get; set; }
    

}