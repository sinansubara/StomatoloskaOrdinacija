using Microsoft.EntityFrameworkCore;
using StomatoloskaOrdinacija.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI
{
    public class SetupService
    {
        public static void Init(MyContext context)
        {
            context.Database.Migrate();
        }
    }
}
