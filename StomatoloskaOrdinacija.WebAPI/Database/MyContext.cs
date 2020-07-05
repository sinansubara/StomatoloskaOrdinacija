using Microsoft.EntityFrameworkCore;
using StomatoloskaOrdinacija.WebAPI.Database;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {

        }
        public DbSet<Korisnici> Korisnici { get; set; }
        public DbSet<Pacijent> Pacijents { get; set; }
        public DbSet<Drzava> Drzavas { get; set; }
        public DbSet<Grad> Grads { get; set; }
        public DbSet<Lijek> Lijeks { get; set; }
        public DbSet<Skladiste> Skladistes { get; set; }
        public DbSet<MedicinskiKarton> MedicinskiKartons { get; set; }
        public DbSet<Pregled> Pregleds { get; set; }
        public DbSet<PromjenaLozinke> PromjenaLozinkes { get; set; }
        public DbSet<Racun> Racuns { get; set; }
        public DbSet<Termin> Termins { get; set; }
        public DbSet<UlazUSkladiste> UlazUSkladistes { get; set; }
        public DbSet<Usluga> Uslugas { get; set; }
        public DbSet<Dijagnoza> Dijagnozas { get; set; }
        public DbSet<Uloge> Uloges { get; set; }
        public DbSet<Ocjene> Ocjenes { get; set; }
        public DbSet<Popust> Popusts { get; set; }
        public DbSet<Pretplata> Pretplatas { get; set; }
        public DbSet<Materijali> Materijalis { get; set; }
    }
}
