# Stomatološka ordinacija
# https://github.com/sinansubara/StomatoloskaOrdinacija

# - Pristupni podaci za desktop aplikaciju(WinUI)
## Username: Administrator | Password: test
## MedicinskoOsoblje | Password: test
## Stomatolog | Password: test

# - Pristupni podaci za mobilnu aplikaciju(UWP)
## Pacijent | Password: test

#####################################################################################
## Za testiranje, prvo treba pokrenuti WebApi preko dockera
> 1. Odraditi "docker-compose build"
> 2. Nakon toga "docker-compose up"
> 3. Kada server bude pokrenut, pokrenemo u visual studiu WinUI(Desktop) ili UWP(Mobile) projekt

## Ako se desi error pri pokretanju dockera(docker-compose up), drugi način za testiranje je, da u set startup projects, stavimo API, UWP i WinUI
> Automatski će se generisati baza podataka na localhostu, bilo da se pokrene preko dockera ili direktno iz visual studia


## Dodatni Admin acc Username: subarasinan | Password: test
## --------------------------------------------------------------

## Za testiranje funkcionalnosti "Zaboravljena lozinka", potrebno je
> 1. Nakon unosa maila za slanje koda(na formi za zaboravljenu lozinku)
> 2. Ući na gmail akaunt od aplikacije(pristupni podaci se nalaze u appsettings)
> 3. Pronaći u "SENT" dijelu zadnji poslani mail, jer svi mailovi od korisnika su izmisljeni
> 3. I ne mogu se isporučiti, ali ako mail postoji, naravno mail će se isporučiti na adresu.
> 4. Uzimanjem koda koji je poslat na adresu, popunjavamo formu za izmjenu lozinke sa tim kodom

## Za testiranje funkcionalnosti plaćanja računa
> 1. U djelu za račune se nalaze svi neplaćeni računi od pacijenta(Ako nema ni jednog računa oni se generišu odma poslije unosa pregleda u desktop dijelu)
> 2. Izbaremo račun koji želimo platit i popunimo formu
> 3. Koristiti kartice samo sa ovog linka https://stripe.com/docs/testing#international-cards
> 3. Samo one su validne za testiranje ove funkcionalnosti
> 4. Poslije toga će se generisati QR code koji treba sačuvati, da bi u ordinaciji(desktop dijelu) skenirali taj code

## Za testiranje funkcionalnosti Skeniranje QR Code
> 1. Trebate imati neku kameru konektovanu na PC
> 1. Možete se spojiti i s telefonom preko aplikacije "iVCam"
> 2. Generisanje koda će se obaviti automatski nakon izvršenja transakcije plaćanja računa
> 3. Radi lakšeg testiranja može se koristit bilo koji QR code koji posjedujete

## Za testiranje funkcionalnosti pretplate na izmjenu cjena i notifikacija
> 1. Treba u desktop aplikaciji dodati popust u odabranom vremenu
> 2. Ako smo pretplaćeni na uslugu koja je na popustu u odabranom vremenu, kad se logujemo
> 2. Dobit ćemo notifikaciju za sve pretplaćene usluge na popustu i kolika je njihova cijena
