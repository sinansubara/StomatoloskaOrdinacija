using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StomatoloskaOrdinacija.WebAPI.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StomatoloskaOrdinacija.Model.Requests;
using StomatoloskaOrdinacija.WebAPI.Database;
using StomatoloskaOrdinacija.WebAPI.Filters;
using StomatoloskaOrdinacija.WebAPI.Services;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace StomatoloskaOrdinacija.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StomatoloskaOrdinacija API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });


            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var connection = Configuration.GetConnectionString("StomatoloskaOrdinacija");
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IKorisniciService, KorisniciService>();



            services.AddScoped<IService<Model.Lijek, object>, BaseService<Model.Lijek, object, Database.Lijek>>();
            services.AddScoped<IService<Model.Dijagnoza, object>, BaseService<Model.Dijagnoza, object, Database.Dijagnoza>>();
            services.AddScoped<IService<Model.Drzava, object>, BaseService<Model.Drzava, object, Database.Drzava>>();
            services.AddScoped<IService<Model.Uloge, object>, BaseService<Model.Uloge, object, Database.Uloge>>();
            services.AddScoped<IService<Model.MedicinskiKarton, MedicinskiKartonSearchRequest>, MedicinskiKartonService>();



            services.AddScoped<ICRUDService<Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<ICRUDService<Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest>, OcjeneService>();
            services.AddScoped<ICRUDService<Model.Usluga, UslugaSearchRequest, UslugaInsertRequest, UslugaInsertRequest>, UslugaService>();
            services.AddScoped<ICRUDService<Model.Termin, TerminSearchRequest, TerminInsertRequest, TerminInsertRequest>, TerminService>();
            services.AddScoped<ICRUDService<Model.UlazUSkladiste, UlazUSkladisteSearchRequest, UlazUSkladisteInsertRequest, UlazUSkladisteInsertRequest>, UlazUSkladisteService>();
            services.AddScoped<ICRUDService<Model.Skladiste, SkladisteSearchRequest, SkladisteInsertRequest, SkladisteInsertRequest>, SkladisteService>();
            services.AddScoped<ICRUDService<Model.Pretplata, PretplataSearchRequest, PretplataInsertRequest, PretplataInsertRequest>, PretplataService>();
            services.AddScoped<ICRUDService<Model.Popust, PopustSearchRequest, PopustInsertRequest, PopustInsertRequest>, PopustService>();
            services.AddScoped<ICRUDService<Model.Pregled, PregledSearchRequest, PregledInsertRequest, PregledInsertRequest>, PregledService>();
            services.AddScoped<ICRUDService<Model.Racun, RacunSearchRequest, RacunInsertRequest, RacunUpdateRequest>, RacunService>();



            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
