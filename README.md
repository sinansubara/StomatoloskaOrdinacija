# Stomatološka ordinacija
# https://github.com/sinansubara/StomatoloskaOrdinacija

# 
# Username: Administrator | Password: test
# MedicinskoOsoblje | Password: test
# Stomatolog | Password: test
# Pacijent | Password: test
#

# Odraditi restore baze ili preko .bak ili preko.mdf i .ldf fajlova
# Docker nije testiran, vjerovatno nije u funkciji, jer ne mogu pokrenut docker program
# Dodatni Admin acc Username: subarasinan | Password: test
# --------------------------------------------------------------

## Za testiranje funkcionalnosti "Zaboravljena lozinka", potrebno je
> nakon unosa maila za slanje koda(na formi za zaboravljenu lozinku),
> ući na gmail akaunt od aplikacije(pristupni podaci se nalaze u appsettings)
> i pronaći u "SENT" dijelu zadnji poslani mail, jer svi mailovi od korisnika su izmisljeni
> i ne mogu se isporučiti, ali ako mail postoji, naravno mail će se isporučiti na adresu.
> Uzimanjem koda koji je poslat na adresu, popunjavamo formu za izmjenu lozinke sa tim kodom

## Za testiranje funkcionalnosti plaćanja računa
> Koristiti kartice samo sa ovog linka https://stripe.com/docs/testing#international-cards
> Samo one su validne za testiranje ove funkcionalnosti

## Za testiranje funkcionalnosti Skeniranje QR Code
> Trebate imati neku kameru konektovanu na PC, 
> možete se spojiti i s telefonom preko aplikacije "iVCam"
> Generisanje koda će se obaviti automatski nakon izvršenja transakcije plaćanja računa
