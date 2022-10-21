using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Validations;

namespace webapp_travel_agency.Models
{
    public class Messaggio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo testo è obbligatorio")]
        public string Testo { get; set; }

        [Required(ErrorMessage = "Il campo email è obbligatorio")]
        [EmailAddress(ErrorMessage = "L'email inserita deve essere valida")]
        public string Email { get; set; }
        public int PacchettoViaggioId { get; set; }

        [AllowNull]
        public PacchettoViaggio? PacchettoViaggio { get; set; }
    }
}
