﻿using StomatoloskaOrdinacija.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.WebAPI.Services.Interfaces;

namespace StomatoloskaOrdinacija.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisniciService _userService;
        public static Model.Korisnici PrijavljeniKorisnik;
        public static Model.Korisnici RegistrovaniKorisnik;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IKorisniciService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");
                
            
            //Model.Korisnici user = null;
            var context = "";
            try
            {
                
                context = Request.Headers["Context"];
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                
                
                if ("Registracija".Equals(context))
                {
                    RegistrovaniKorisnik = _userService.LoginMobile(new Model.Requests.KorisniciLoginRequest()//dodaj await
                    {
                        Username = username,
                        Password = password
                    });
                }
                else
                {
                    PrijavljeniKorisnik = _userService.Login( //dodaj await
                        new Model.Requests.KorisniciLoginRequest()
                        {
                            Username = username,
                            Password = password
                        }); //Authenticiraj(username, password);
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            var claims = new List<Claim>();
            if ("Registracija".Equals(context))
            {
                if (RegistrovaniKorisnik == null)
                    return AuthenticateResult.Fail("Invalid Username or Password");
            }
            else
            {
                if (PrijavljeniKorisnik == null)
                    return AuthenticateResult.Fail("Invalid Username or Password");

            }
            
            claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, PrijavljeniKorisnik.KorisnickoIme),
                new Claim(ClaimTypes.Name, PrijavljeniKorisnik.Ime),
            };

            claims.Add(new Claim(ClaimTypes.Role, PrijavljeniKorisnik.Uloga.Naziv));

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
