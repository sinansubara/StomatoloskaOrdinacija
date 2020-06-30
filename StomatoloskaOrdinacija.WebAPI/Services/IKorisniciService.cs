using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Services
{
    public interface IKorisniciService
    {
        IList<Model.Korisnici> GetAll(KorisniciSearchRequest search);

        Model.Korisnici GetById(int id);

        Model.Korisnici Insert(KorisniciInsertRequest korisnici);

        Model.Korisnici Update(int id, KorisniciUpdateRequest korisnici);

        Model.Korisnici Login(KorisniciLoginRequest request);
    }
}
