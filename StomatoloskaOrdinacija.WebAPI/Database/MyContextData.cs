using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public partial class MyContext
    {

       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Drzava() { DrzavaId = 1, Naziv = "Bosna i Hercegovina" },
                new StomatoloskaOrdinacija.WebAPI.Database.Drzava() { DrzavaId = 2, Naziv = "Hrvatska" },
                new StomatoloskaOrdinacija.WebAPI.Database.Drzava() { DrzavaId = 3, Naziv = "Srbija" },
                new StomatoloskaOrdinacija.WebAPI.Database.Drzava() { DrzavaId = 4, Naziv = "Crna Gora" }  );

            modelBuilder.Entity<Grad>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Grad() { GradId = 1, DrzavaId = 1, Naziv = "Jablanica", PostanskiBroj = "88420" },
                new StomatoloskaOrdinacija.WebAPI.Database.Grad() { GradId = 2, DrzavaId = 1, Naziv = "Mostar", PostanskiBroj = "74000" }, 
                new StomatoloskaOrdinacija.WebAPI.Database.Grad() { GradId = 3, DrzavaId = 1, Naziv = "Sarajevo", PostanskiBroj = "71000" },
                new StomatoloskaOrdinacija.WebAPI.Database.Grad() { GradId = 4, DrzavaId = 1, Naziv = "Konjic", PostanskiBroj = "88400" },
                new StomatoloskaOrdinacija.WebAPI.Database.Grad() { GradId = 5, DrzavaId = 1, Naziv = "Stolac", PostanskiBroj = "74500" });

            modelBuilder.Entity<Uloge>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Uloge() { UlogaId = 1, Naziv = "Administrator", Opis = "Administracija" },
                new StomatoloskaOrdinacija.WebAPI.Database.Uloge() { UlogaId = 2, Naziv = "Stomatolog", Opis = "Stomatolog" },
                new StomatoloskaOrdinacija.WebAPI.Database.Uloge() { UlogaId = 3, Naziv = "Medicinsko Osoblje", Opis = "Medicinsko Osoblje" },
                new StomatoloskaOrdinacija.WebAPI.Database.Uloge() { UlogaId = 4, Naziv = "Pacijent", Opis = "Pacijent" });

            modelBuilder.Entity<Korisnici>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Korisnici()
                {
                    KorisnikId = 1,
                    Ime = "Sinan",
                    Prezime = "Šubara",
                    Email = "sinan.subara@gmail.com",
                    KorisnickoIme = "subarasinan",
                    LozinkaHash = "51fj6EFNklXOT2n6JbP4qBC50Zo=",
                    LozinkaSalt = "OG/4MWdlSQQWaHd9+wehfA==",
                    Kreirano = DateTime.Now.AddDays(-5),
                    JMBG = "0206995150007",
                    DatumRodjenja = new DateTime(1995,6,2),
                    Mobitel = "38762516238",
                    Adresa = "Komune Vejle 14",
                    GradId = 1,
                    Spol = "Muško",
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg"),
                    UlogaId = 1,
                    Status = true
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Korisnici()
                {
                    KorisnikId = 2,
                    Ime = "Admin",
                    Prezime = "Sistema",
                    Email = "admin.ordinacija@gmail.com",
                    KorisnickoIme = "Administrator",
                    LozinkaHash = "dPN0un+0GqlXLR0Au1MJ795SJhc=",
                    LozinkaSalt = "CfEPCI/ScIKCo53UZX/MIA==",
                    Kreirano = DateTime.Now,
                    JMBG = "0101990150000",
                    DatumRodjenja = new DateTime(1990, 1, 1),
                    Mobitel = "38762225883",
                    Adresa = "Komune Vejle 12",
                    GradId = 1,
                    Spol = "Muško",
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg"),
                    UlogaId = 1,
                    Status = true
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Korisnici()
                {
                    KorisnikId = 3,
                    Ime = "Medicinsko",
                    Prezime = "Osoblje",
                    Email = "osoblje.ordinacija@gmail.com",
                    KorisnickoIme = "MedicinskoOsoblje",
                    LozinkaHash = "2/uMWISR22lQEqk0LGGRiMH5l3k=",
                    LozinkaSalt = "lVe6oAsC7FMxZRlDKMB+Cw==",
                    Kreirano = DateTime.Now,
                    JMBG = "0206992150008",
                    DatumRodjenja = new DateTime(1992, 6, 2),
                    Mobitel = "38762516615",
                    Adresa = "Mostarska BB",
                    GradId = 2,
                    Spol = "Žensko",
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg"),
                    UlogaId = 3,
                    Status = true
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Korisnici()
                {
                    KorisnikId = 4,
                    Ime = "Stomatolog",
                    Prezime = "Osoblje",
                    Email = "stomatolog.ordinacija@gmail.com",
                    KorisnickoIme = "Stomatolog",
                    LozinkaHash = "EbAIgM1peBqerunMY9/Efjdpju4=",
                    LozinkaSalt = "pMlLkvhpuQjpQ1IjPDOiQQ==",
                    Kreirano = DateTime.Now,
                    JMBG = "0206985150009",
                    DatumRodjenja = new DateTime(1985, 6, 2),
                    Mobitel = "38762225883",
                    Adresa = "Druga Tita 7",
                    GradId = 1,
                    Spol = "Muško",
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg"),
                    UlogaId = 2,
                    Status = true
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Korisnici()
                {
                    KorisnikId = 5,
                    Ime = "Pacijent",
                    Prezime = "Mobile",
                    Email = "pacijent.mobile@gmail.com",
                    KorisnickoIme = "Pacijent",
                    LozinkaHash = "qEkPhwY9P2FiDqx1Rgg26GoapxE=",
                    LozinkaSalt = "fVZy3b4Z1cvYNep/oXc7aA==",
                    Kreirano = DateTime.Now,
                    JMBG = "0206998150007",
                    DatumRodjenja = new DateTime(1998, 6, 2),
                    Mobitel = "38762226238",
                    Adresa = "Kolonija BB",
                    GradId = 1,
                    Spol = "Žensko",
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg"),
                    UlogaId = 4,
                    Status = true
                });

            modelBuilder.Entity<UlazUSkladiste>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.UlazUSkladiste() 
                {
                    UlazUSkladisteID = 1,
                    KorisnikId = 3,
                    BrojFakture = "Faktura001",
                    Datum = DateTime.Now.AddDays(-1),
                    IznosRacuna = 250
                },
                new StomatoloskaOrdinacija.WebAPI.Database.UlazUSkladiste()
                {
                    UlazUSkladisteID = 2,
                    KorisnikId = 3,
                    BrojFakture = "Faktura002",
                    Datum = DateTime.Now,
                    IznosRacuna = 100
                });

            modelBuilder.Entity<Skladiste>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 1,
                    UlazUSkladisteId = 1,
                    Naziv = "Evetric",
                    Opis = "Ispun nakon popravke zuba",
                    Vrsta = "Kompozitni ispuni",
                    Proizvodjac = "EvetCom",
                    Kolicina = 19,
                    MjernaJedinica = "kom",
                    Cijena = 7,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 2,
                    UlazUSkladisteId = 1,
                    Naziv = "Genial flo",
                    Opis = "Tećni ispun nakon popravke zuba",
                    Vrsta = "Tečni ispun",
                    Proizvodjac = "GenCom",
                    Kolicina = 30,
                    MjernaJedinica = "l",
                    Cijena = 25,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 3,
                    UlazUSkladisteId = 1,
                    Naziv = "Ultrablend",
                    Opis = "Podloga prije ispuna",
                    Vrsta = "Podloga",
                    Proizvodjac = "Ultra",
                    Kolicina = 16,
                    MjernaJedinica = "kom",
                    Cijena = 75,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 4,
                    UlazUSkladisteId = 2,
                    Naziv = "Colgate",
                    Opis = "Za ispiranje usta",
                    Vrsta = "Tečno",
                    Proizvodjac = "Kolg",
                    Kolicina = 20,
                    MjernaJedinica = "l",
                    Cijena = 10,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 5,
                    UlazUSkladisteId = 2,
                    Naziv = "Parmaseal",
                    Opis = "Zalivac nakon plombe",
                    Vrsta = "Zalivac",
                    Proizvodjac = "Zalv",
                    Kolicina = 7,
                    MjernaJedinica = "l",
                    Cijena = 10,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Skladiste()
                {
                    SkladisteId = 6,
                    UlazUSkladisteId = 2,
                    Naziv = "Septodont",
                    Opis = "Ljekovito dejstvo nakon upale živaca",
                    Vrsta = "Ljekovito dejstvo",
                    Proizvodjac = "Septo",
                    Kolicina = 40,
                    MjernaJedinica = "kom",
                    Cijena = 20,
                    Slika = File.ReadAllBytes("Helper/no_image.jpeg")
                });

            modelBuilder.Entity<Materijali>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 1,
                    SkladisteId = 1,
                    Naziv = "Evetric",
                    Kolicina = 2,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 2,
                    SkladisteId = 2,
                    Naziv = "Genial flo",
                    Kolicina = 5,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 3,
                    SkladisteId = 3,
                    Naziv = "Ultrablend",
                    Kolicina = 4,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 4,
                    SkladisteId = 4,
                    Naziv = "Colgate",
                    Kolicina = 1,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 5,
                    SkladisteId = 5,
                    Naziv = "Parmaseal",
                    Kolicina = 7,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 6,
                    SkladisteId = 6,
                    Naziv = "Septodont",
                    Kolicina = 5,
                    Datum = DateTime.Now
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Materijali()
                {
                    MaterijaliId = 7,
                    SkladisteId = 1,
                    Naziv = "Evetric",
                    Kolicina = 4,
                    Datum = DateTime.Now
                });
            modelBuilder.Entity<Pacijent>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Pacijent()
                {
                    PacijentId = 1,
                    KorisnikId = 5,
                    AlergijaNaLijek = false,
                    Proteza = false,
                    Terapija = true,
                    Navlake = false,
                    Aparatic = true,
                });

            modelBuilder.Entity<Usluga>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 1, Naziv = "Čišćenje zubnog kamenca", Cijena = 15 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 2, Naziv = "Zalivanje fisura", Cijena = 20 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 3, Naziv = "Uklanjanje mekih naslaga", Cijena = 20 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 4, Naziv = "Kompozitni ispuni", Cijena = 25 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 5, Naziv = "Promjena lijeka", Cijena = 15 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 6, Naziv = "Izbjeljivanje zuba", Cijena = 50 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 7, Naziv = "Vađenje zuba", Cijena = 10 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 8, Naziv = "Popravak zuba", Cijena = 25 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 9, Naziv = "Privremena krunica", Cijena = 70 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 10, Naziv = "Mobilni ortodonski aparati", Cijena = 500 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 11, Naziv = "Plombiranje", Cijena = 25 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 12, Naziv = "FRC konzervativna nadogradnja", Cijena = 350 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 13, Naziv = "Ekstripacija pulpe", Cijena = 35 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 14, Naziv = "Uklanjanje kamenca i poliranje zuba", Cijena = 30 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 15, Naziv = "Hirurško vađenje zuba", Cijena = 50 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 16, Naziv = "Apikotomija", Cijena = 35 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 17, Naziv = "Implatanti", Cijena = 400 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 18, Naziv = "Fisura", Cijena = 60 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 19, Naziv = "Flurisanje zuba", Cijena = 35 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 20, Naziv = "Postavljanje i terapija fiksnih aparata", Cijena = 250 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 21, Naziv = "Izrada monobloka", Cijena = 300 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 22, Naziv = "Izrada krunica", Cijena = 250 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 23, Naziv = "Izrada totanlnih i parcijalnih proteza", Cijena = 450 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 24, Naziv = "Reparature totalnih i parcijalnih proteza", Cijena = 100 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 25, Naziv = "Preoblikovanje zuba kompozitom", Cijena = 25 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 26, Naziv = "Izrada i terapija mobilnih aparata", Cijena = 700 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 27, Naziv = "Izrada jednokorjenih i višekorjenih", Cijena = 75 },
                new StomatoloskaOrdinacija.WebAPI.Database.Usluga() { UslugaId = 28, Naziv = "Izrada navlaka", Cijena = 300 });

            modelBuilder.Entity<Termin>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Termin() 
                { 
                    TerminId = 1,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(2),
                    Razlog = "Termin 1 razlog",
                    Hitan = true,
                    IsOdobren = true,
                    IsNaCekanju = false,
                    UslugaId = 1
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Termin()
                {
                    TerminId = 2,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(4),
                    Razlog = "Termin 2 razlog",
                    Hitan = false,
                    IsOdobren = true,
                    IsNaCekanju = false,
                    UslugaId = 2
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Termin()
                {
                    TerminId = 3,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(5),
                    Razlog = "Termin 3 razlog",
                    Hitan = false,
                    IsOdobren = false,
                    IsNaCekanju = false,
                    UslugaId = 3
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Termin()
                {
                    TerminId = 4,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(10),
                    Razlog = "Termin 4 razlog",
                    Hitan = false,
                    IsOdobren = false,
                    IsNaCekanju = true,
                    UslugaId = 4
                });

            modelBuilder.Entity<Lijek>().HasData( 
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 1, Naziv = "Pencilin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 2, Naziv = "Brufen" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 3, Naziv = "Fenoksim etilpencilin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 4, Naziv = "Eritromicin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 5, Naziv = "Aspirin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 6, Naziv = "Analgin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 7, Naziv = "Bacitracin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 8, Naziv = "Neomacin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 9, Naziv = "Cefalosporin" },
                new StomatoloskaOrdinacija.WebAPI.Database.Lijek() { LijekId = 10, Naziv = "Klindamicin" });

            modelBuilder.Entity<Dijagnoza>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 1, Naziv = "Nekroza pulpe" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 2, Naziv = "Generacija pulpe" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 3, Naziv = "Abnormalno formiranje tvrdog tkiva pulpi" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 4, Naziv = "Apikalna cista" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 5, Naziv = "Periapikalna cista" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 6, Naziv = "Uglavljeni zubi" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 7, Naziv = "Nabijeni zubi" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 8, Naziv = "Erozija zuba" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 9, Naziv = "Toksični celulitis" },
                new StomatoloskaOrdinacija.WebAPI.Database.Dijagnoza() { DijagnozaId = 10, Naziv = "Periodontitis" });

            modelBuilder.Entity<Pregled>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Pregled() 
                { 
                    PregledId = 1,
                    KorisnikId = 4,
                    TerminId = 1,
                    TrajanjePregleda = 50,
                    Napomena = "Pacijent se javio sa velikim upalama oko zuba, meko tkivo i živci",
                    SkladisteId = 1,
                    KolicinaOdabranogMaterijala = 3,
                    DijagnozaId = 1,
                    LijekId = 1
                });

            modelBuilder.Entity<MedicinskiKarton>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.MedicinskiKarton()
                {
                    MedicinskiKartonId = 1,
                    PregledId = 1,
                    PacijentId = 1,
                    Datum = DateTime.Now,
                    Napomena = "Pacijent se javio sa velikim upalama oko zuba, meko tkivo i živci"
                });

            modelBuilder.Entity<Racun>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Racun()
                {
                    RacunId = 1,
                    KorisnikId = 4,
                    PregledId = 1,
                    UkupnaCijena = 36,
                    DatumIzdavanjaRacuna = DateTime.Now,
                    IsPlatio = false
                });


            modelBuilder.Entity<Ocjene>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Ocjene()
                {
                    OcjenaId = 1,
                    PacijentId = 1,
                    UslugaId = 1,
                    Kreirano = DateTime.Now,
                    Ocjena = 9,
                    Komentar = "Dobra obavljena usluga, vrlo profesionalno."
                },
                new StomatoloskaOrdinacija.WebAPI.Database.Ocjene()
                {
                    OcjenaId = 2,
                    PacijentId = 1,
                    UslugaId = 2,
                    Kreirano = DateTime.Now,
                    Ocjena = 7,
                    Komentar = "Dobra usluga."
                });

            modelBuilder.Entity<Popust>().HasData(
                new StomatoloskaOrdinacija.WebAPI.Database.Popust() 
                {
                    PopustId = 1,
                    UslugaId = 10,
                    KorisnikId = 3,
                    PopustOdDatuma = DateTime.Now,
                    PopustDoDatuma = DateTime.Now.AddDays(5),
                    VrijednostPopusta = 20
                });

        }
    }
}
