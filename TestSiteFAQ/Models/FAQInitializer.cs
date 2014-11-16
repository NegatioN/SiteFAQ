using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class FAQInitializer : DropCreateDatabaseIfModelChanges<FAQContext>
    {
        public FAQInitializer()
        {
            FAQContext db = new FAQContext();

            try
            {
                if (db.Faqs.ToList().Count() == 0)
                    Seed(db);
            }
            catch (Exception e)
            {
                Seed(db);
        
            }
        }
        protected override void Seed(FAQContext context)
        {
            Debug.WriteLine("db-Init start");
            var faqs = new List<FAQ>{
              
                //Siden (I dont even know what)
                new FAQ{Heading = "Hvorfor startet vi denne siden?", Category=FAQ.Categories[1],Description="Det har alltid vært en stor drøm for oss å kunne selge tastatur, så det var med en gang klart for oss at dette var det riktige valget.\nHvorfor ellers ville vi ha startet noe så rart som en tastaturbutikk? Ja det kan du spørre deg selv...."},
                new FAQ{Heading ="Tastatur i deler?", Category=FAQ.Categories[1], Description="Har du ikke behov for et helt tastatur tilbyr vi også oppgraderingspakker og PCer i deler. I tillegg er det selvfølgelig også mulig å plukke ut de komponentene man vil ha fra de øvrige kategoriene presentert på venstre side av skjermen."},
                new FAQ{Heading="Har du lyst til å bidra?", Category=FAQ.Categories[1], Description="Har du tid og lyst til å hjelpe med å holde denne siden oppdatert, oppfordres du til å ta kontakt."},
                new FAQ{Heading="Annonsering?", Category=FAQ.Categories[1], Description="Vi har tilgjengelig annonseplass for rett pris. Kontakt oss på tlf 933383838."},

                //Handel (How-to osv)
                new FAQ{Heading = "Ny på Tast-1-tur?", Category=FAQ.Categories[3], Description = "Er du ny på Tast-1-tur kan du opprette en konto hos oss på denne siden. Du vil så bli bedt om å fylle inn informasjon vi trenger om deg gjennom en lettfattelig registrering i to steg. En konto hos oss vil gi deg muligheten til å handle fra vårt store utvalg, samt at du kan få tilsendt vårt ukentlige nyhetsbrev. Du kan lese mer om dette på Min side"},
                new FAQ{Heading = "Hvordan finne produktet?", Category=FAQ.Categories[3], Description = "For å hjelpe deg å finne varen du leter etter, kan du bla deg gjennom kategoriene på venstre siden av vår side. Kategoriene er inndelt med underkategorier som leder deg til ønsket varetype. I alle produktlister vil du også kunne sortere varer på pris og tilgjengelighet. Du vil også finne et utvalg anbefalte produkter i hver kategori. Dette er produkter vi anbefaler pga. pris, spesifikasjoner og tilgjengelighet.\nDersom du vet eksakt hva du leter etter, kan du også bruke vår søkefunksjon som du finner på toppen av vår side til enhver tid. For å søke, skriv inn søkeordene i søkeboksen og trykk Enter eller klikk Søk for å se relevante produkter og sider. Vi viser bare produkter som inneholder alle søkeordene, men vi tar ikke hensyn til rekkefølgen på søkeordene. For å få gode resultater, er det viktig at du velger fornuftige søkeord."},
                new FAQ{Heading = "Gjennomføre handel", Category=FAQ.Categories[3], Description = "For å gjøre det så enkelt som overhodet mulig for deg som kunde og gjennomføre en handel hos oss, har vi lagt stor vekt på å gjøre handlevogn og kasse så lett forståelig som mulig. Når du trykker kjøp på en vare blir varen lagt til i handlevognen som også du vil bli overført til. Her velger du om du ønsker å fortsette å handle eller gå videre til kassen. Når du er ferdig med din handel går du videre fra handlevognen til kassen. I kassen vil du enkelt kunne velge fraktmåte, betalingsform, leveringsadresse med mer. Du vil også se kostnaden for frakt beregnet ut i fra vekt og kolli."},
                new FAQ{Heading="Pakkesporing", Category=FAQ.Categories[3], Description= "Lagervarer sendes normalt i løpet av en til to virkedager. Vi forsøker naturligvis å sende samme dag, men dette avhenger av sesong og bestillingstidspunkt. Transporttiden varierer avhengig av leveringsadresse og hvilken fraktmåte du velger. Sjekk Ordrebekreftelsen din for nærmere detaljer. Tidspunktet du bestiller avgjør når vi kan plukke, pakke og sende din ordre.\nNår varene er klargjort for forsendelse fra vårt lager, sender vi en leveringsbekreftelse pr e-post til adressen du har oppgitt. Leveringsbekreftelsen sendes før transportøren henter varene hos oss, derfor kan det ta noen timer før pakken kan spores. For å spore forsendelsen din, kan du bruke Pakkesporing direkte fra ordrestatus på Min side slik at du slipper å kontakte oss for å finne ut hvor pakken er."},
                new FAQ{Heading="Åpent kjøp", Category=FAQ.Categories[3], Description="Vi tilbyr våre kunder en utvidet returrett på opptil 45 dager fra varen er mottatt. Ordningen gjelder ikke for bedrift eller annen offentlig institusjon/forvaltning. Denne returretten følger samme kriterier som angrefris"},

                //Financing (Betaling o.l.)
                new FAQ{Heading = "Kortbetaling med Visa og Mastercard", Category=FAQ.Categories[0], Description = "Betaling med kort er trygt og enkelt. Du taster inn kortnummeret ditt, utløpsdatoen og en verifiseringskode (CVV2) og kan deretter vente på leveringen. Vi samarbeider tett med VISA og Mastercard for å sørge for en kjapp prosessering av din kortinformasjon og alt foregår i meget sikre former med vår kryptering. Ingen får fysisk se ditt kortnummer gjennom hele betalingsprosessen. \nNår du legger en ordre hos oss med ditt kort blir det gjort en autorisasjon på kortet ditt. Dette betyr at vi sjekker at kortet er ekte og at det er dekning på det. Vi gjør så en reservasjon, hvor beløpet du handler for blir reservert for sitt bruk. Dette vil si at pengene fremdeles er på kortet ditt, men at de ikke kan røres av andre enn Komplett så lenge ordren eksisterer."},
                new FAQ{Heading = "Betaling kontant ved henting", Category=FAQ.Categories[0], Description = "Vi aksepterer kontanter, BankAxept-kort, Visa og Mastercard i våre Pick-up-Point."},
                new FAQ{Heading = "Online gavekort", Category=FAQ.Categories[0], Description = "Du kan enkelt kjøpe online gavekort til noen du kjenner ved å trykke på gavekortet over. Der trykker man på kjøpsknappen og på neste side velger du selv hvor mange gavekort du ønsker å kjøpe med beløpsgrense på opptil kr 20 000,-. Deretter fyller du inn til og fra samt en personlig hilsen. Trykk deretter gå til kassen og fullfør din ordre. Vi sender så gavekortet pr e-post til ønsket e-postadresse innen 12 timer. Gavekortet kan ikke kjøpes sammen med andre varer og må betales med kredittkort, vi kan også tilby faktura til bedrifter. Gavekortet har en gyldighet på 18 måneder."},
                
                //General FAQ (Om oss)
                new FAQ{Heading = "Personopplysninger", Category=FAQ.Categories[2], Description = "Når du handler hos oss trenger vi navn, adresse og e-post. Dette er nødvendig for å kunne sende din bestilling til riktig leveringsadresse og kontakte deg hvis det skulle være behov. Vi er pålagt å oppbevare informasjonen i forbindelse med regnskapsføring, avgifts håndtering og eventuell garanti-/returhåndtering. Denne historikken slettes ikke. Vi oppbevarer av sikkerhetshensyn også IP-adressen som er benyttet for å registrere bestillingen. Informasjonen er tilgjengelig på Min side."},
                new FAQ{Heading = "Hvor befinner vi oss?", Category=FAQ.Categories[2], Description = "Hovedkontoret vårt med bl.a. direktesalg (Internett, telefon o.l.), administrasjon og lager ligger i Sandefjord."}
            };
            foreach(var faq in faqs){
                context.addFAQ(faq);
                Debug.WriteLine(faq.Heading + " added.");
            }
            context.SaveChanges();
            Debug.WriteLine("Db-init complete");
        }
    }
}