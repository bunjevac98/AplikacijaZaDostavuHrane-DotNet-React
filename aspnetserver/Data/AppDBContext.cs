using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/appDB.db");

        //Ovde smo napravili jednog korisnika cisto da imamo u bazi podataka
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Korisnik podaciZaBazuKorisnika = new Korisnik
            {
                KorisnikId = 1,
                Ime = "Aleksandar",
                Prezime = "Basic",
                KorisnickoIme = "Aco",
                Lozinka = "Aco12345",
                Email = "basic.aco@hotmail.com",
                DatumRodjenja = DateTime.Parse("07/11/1998"),
                TipKorisnika = 0,
                Slika = string.Empty
            }; 
        
            modelBuilder.Entity<Korisnik>().HasData(podaciZaBazuKorisnika); 
        }
    }
}
