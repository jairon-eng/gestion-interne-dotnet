using System;
using System.ComponentModel.DataAnnotations;

namespace GestionInterne.Models;

public class Equipement
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Nom { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string Type { get; set; } = string.Empty;

    [Required, StringLength(80), Display(Name = "Numéro de série")]
    public string NumSerie { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string Statut { get; set; } = "Disponible"; // Disponible, Assigne, Reparation
    
    public List<Affectation> Affectations { get; set; } = new();
[Display(Name = "Date d’achat")]
[DataType(DataType.Date)]
[CustomValidation(typeof(Equipement), nameof(ValidateDateAchat))]
public DateTime? DateAchat { get; set; }

public static ValidationResult? ValidateDateAchat(DateTime? date, ValidationContext context)
{
    if (date.HasValue && date.Value > DateTime.Today)
        return new ValidationResult("La date d’achat ne peut pas être dans le futur.");

    return ValidationResult.Success; // null, OK
}


}
