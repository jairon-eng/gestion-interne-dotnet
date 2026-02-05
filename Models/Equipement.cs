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

    [Required, StringLength(80)]
    public string NumSerie { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string Statut { get; set; } = "Disponible"; // Disponible, Assigne, Reparation

    public DateTime? DateAchat { get; set; }
}
