using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Database
{
    public partial class eProdajaContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JediniceMjere>().HasData(new StomatoloskaOrdinacija.WebAPI.Database.JediniceMjere()
            {
                JedinicaMjereId = 1,
                Naziv = "Test"
            });
        }
    }
}
