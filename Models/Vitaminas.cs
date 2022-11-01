using System.ComponentModel.DataAnnotations;


public class Vitaminas
{
    [Key]
    public int VitaminaId { get; set; }
    [Required(ErrorMessage = "Digite la Nombre de la vitamina.")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Digite la unidad de medida de la vitamina.")]
    public string? UnidadMedida { get; set; }
    public double Existencia { get; set; }

}