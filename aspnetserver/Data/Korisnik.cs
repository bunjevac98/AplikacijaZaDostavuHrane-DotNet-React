using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data
{
    internal sealed class Korisnik
    {
        [Key]
        public int KorisnikId { get; set; }
        [Required]
        [MaxLength(length:100)]
        public string Ime { get; set; } = string.Empty;
        [Required]
        [MaxLength(length: 100)]
        public string Prezime { get; set; } = string.Empty;
        [Required]
        [MaxLength(length: 100)]
        public string KorisnickoIme { get; set; } = string.Empty;

        [Required]
        [MaxLength(length: 100)]
        [MinLength(length: 8)]
        public string Lozinka { get; set; } = string.Empty;

        [Required]
        [MaxLength(length: 100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public TipKorisnika TipKorisnika { get; set; }
        [Required]
        public string Slika { get; set; } = string.Empty;


    }
}
