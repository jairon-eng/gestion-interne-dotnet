using System.ComponentModel.DataAnnotations;

namespace GestionInterne.Models
{
    public class Affectation
    {
        public int Id { get; set; }

        // FK
        [Display(Name = "Équipement")]
        public int EquipementId { get; set; }

        // Navigation
        public Equipement? Equipement { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Assigné à")]
        public string AssigneA { get; set; } = string.Empty;

        [Required, StringLength(80)]
        [Display(Name = "Département")]
        public string Departement { get; set; } = string.Empty;

        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; } = DateTime.Today;

        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime? DateFin { get; set; }

        [Required, StringLength(30)]
        [Display(Name = "Statut")]
        public string Statut { get; set; } = "Active";

        [StringLength(250)]
        [Display(Name = "Commentaire")]
        public string? Commentaire { get; set; }
    }
}
