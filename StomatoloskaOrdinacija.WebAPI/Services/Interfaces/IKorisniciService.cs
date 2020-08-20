using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Services.Interfaces
{
    public interface IKorisniciService : ICRUDService<Model.Korisnici, KorisniciSearchRequest, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        Model.Korisnici Login(KorisniciLoginRequest request);
        Model.Korisnici LoginMobile(KorisniciLoginRequest request);
        Model.Korisnici Registracija(KorisniciRegistracijaRequest request);
        IList<Model.Pacijent> GetAllPacijenti(KorisniciSearchRequest search = default);
        Model.Pacijent Update(int id, KorisniciPacijentUpdateRequest request);
        IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisniciSearchRequest search = default);
        Model.KorisnikPacijent GetByIdKorisnikPacijent(int id);
        Model.KorisnikPacijent UpdateKorisniciPacijent(int id, KorisniciPacijentUpdateRequest request);
        Model.Korisnici GetNajboljiStomatolog();
        Model.Korisnici GetNajboljeOsoblje();
        Model.Korisnici GetNajBoljiPacijent();
        IList<Model.Korisnici> GetAllDatumOdDo(KorisniciSearchRequest search = default);
        IList<Model.Korisnici> TopPacijenti(KorisniciSearchRequest search = default);
    }
}
