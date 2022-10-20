using System.ComponentModel.DataAnnotations;
using Validations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "Il campo località è obbligatorio")]
        public string Località { get; set; }

        [Required(ErrorMessage = "Il campo immagine è obbligatorio")]
        public string Immagine { get; set; }

        public string? Descrizione { get; set; }

        [MoreThanZeroValidation]
        [Required(ErrorMessage = "il campo prezzo è obbligatorio")]
        public decimal? Prezzo { get; set; }
    }
}
