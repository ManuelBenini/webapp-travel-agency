namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Località { get; set; }
        public string? Descrizione { get; set; }
        public decimal Prezzo { get; set; }
    }
}
