using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class Avis
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string? Prenom { get; set; }

        [Required(ErrorMessage = "Le genre est obligatoire")]
        public string? Genre { get; set; } = "Sélectionnez un sexe";

        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string? Adresse { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres.")]
        public string? CodePostal { get; set; }

        [Required(ErrorMessage = "La ville est obligatoire")]
        public string? Ville { get; set; }

        [Required(ErrorMessage = "Le mail est obligatoire")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Format d'email invalide.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La date de début est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "Le type de formation est obligatoire")]
        public string? Cours { get; set; } = "Sélectionnez une formation";

        public string? Cobol { get; set; }

        public string? CSharp { get; set; }
    }
}