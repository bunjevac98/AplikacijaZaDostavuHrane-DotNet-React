using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class KorisnikRepository
    {

        internal async static Task<List<Korisnik>> GetPostAsync() 
        {
            using (var db = new AppDBContext()) {
                return await db.Korisnici.ToListAsync();
            }
        }
        //Ovde Warning sto vraca null pregledati
        internal async static Task<Korisnik> GetKorisnikAsyncById(int korisnikId) {
            using (var db = new AppDBContext()) {
                return await db.Korisnici.FirstOrDefaultAsync(korisnik => korisnik.KorisnikId == korisnikId);
            }
        }

        internal async static Task<bool> CreateKorisnikAsync(Korisnik createdKorisnik) {
            using (var db = new AppDBContext()) {
                try
                {
                    await db.Korisnici.AddAsync(createdKorisnik);
                    //ako je ispunjen uslov vratice true ako nije vraca false
                    //Save changes Async vraca broj(stanje)
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            
            }
        }

        internal async static Task<bool> UpdateKorisnikAsync(Korisnik korisnikToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                     db.Korisnici.Update(korisnikToUpdate);
                    //ako je ispunjen uslov vratice true ako nije vraca false
                    //Save changes Async vraca broj(stanje)
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        internal async static Task<bool> DeleteKorisnikAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Korisnik korisnikToDelete= await GetKorisnikAsyncById(postId);
                    db.Remove(korisnikToDelete);
                    //ako je ispunjen uslov vratice true ako nije vraca false
                    //Save changes Async vraca broj(stanje)
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }




    }
}
