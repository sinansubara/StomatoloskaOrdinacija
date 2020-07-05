using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Korisnici, Model.Korisnici>(); // means you want to map from User to UserDTO
            CreateMap<KorisniciInsertRequest, Korisnici>(); // means you want to map from User to UserDTO
            CreateMap<KorisniciUpdateRequest, Korisnici>(); // means you want to map from User to UserDTO
            CreateMap<KorisniciRegistracijaRequest, Korisnici>();
            CreateMap<KorisniciPacijentUpdateRequest, Korisnici>();
            CreateMap<KorisniciPacijentUpdateRequest, Pacijent>();
            CreateMap<Pacijent, Model.Pacijent>();
            CreateMap<Pacijent, Model.KorisnikPacijent>();
            CreateMap<Korisnici, Model.KorisnikPacijent>();

            CreateMap<Materijali, Model.Materijali>();
            CreateMap<Uloge, Model.Uloge>();

            CreateMap<Grad, Model.Grad>();
            CreateMap<GradUpsertRequest, Grad>();

            CreateMap<Drzava, Model.Drzava>();

            CreateMap<Lijek, Model.Lijek>();

            CreateMap<Dijagnoza, Model.Dijagnoza>();

            CreateMap<OcjeneUpsertRequest, Ocjene>();
            CreateMap<Ocjene, Model.Ocjene>();

            

            CreateMap<Usluga, Model.Usluga>();
            CreateMap<UslugaInsertRequest, Usluga>();



            CreateMap<Termin, Model.Termin>(); 
            CreateMap<TerminInsertRequest, Termin>(); 

            CreateMap<UlazUSkladiste, Model.UlazUSkladiste>(); 
            CreateMap<UlazUSkladisteInsertRequest, UlazUSkladiste>(); 

            CreateMap<Skladiste, Model.Skladiste>(); 
            CreateMap<SkladisteInsertRequest, Skladiste>(); 

            CreateMap<Pretplata, Model.Pretplata>(); 
            CreateMap<PretplataInsertRequest, Pretplata>(); 

            CreateMap<Popust, Model.Popust>(); 
            CreateMap<PopustInsertRequest, Popust>(); 

            CreateMap<Pregled, Model.Pregled>(); 
            CreateMap<PregledInsertRequest, Pregled>(); 

            CreateMap<MedicinskiKarton, Model.MedicinskiKarton>(); 

            CreateMap<Racun, Model.Racun>(); 
            CreateMap<RacunInsertRequest, Racun>(); 
            CreateMap<RacunUpdateRequest, Racun>();
        }
    }
}
