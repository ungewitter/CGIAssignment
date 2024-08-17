# CGIAssignment

// INFO
Den här applikationen är ett REST API för att hantera visitkort. Den är kopplad till en lokal MongoDB databas, och klienten är byggd med Vue.

// HUR DEN BYGGS
Se till att man har följande installerat:

- Node.js
- MongoDB
- Vue CLI

Klona repot från GitHub (https://github.com/ungewitter/CGIAssignment).

// REST API
I API:et, gå till 'appsettings.json' och byt ut värdena under 'BusinessCardDatabase' så att det passar ens lokala MongoDB databas.
Välj 'https' och kör applikationen genom att trycka F5 i Visual Studio och ha den igång i bakgrunden.

// VUE
För installera Vue-klienten, öppna vue-projektet 'vue-cgi-assignment' och kör 'npm install'. För att öppna klienten i webbrowsern, kör 'npm run dev'.
Säkerställ att klienten går mot rätt URL genom att checka filen 'config.ts'. apiURI borde ha värdet som går mot servern, men om man kör https så borde det vara 'https://localhost:7088'.

// FUNDERINGAR OCH FÖRBÄTTRINGAR

- Ville egentligen fixa en Docker-fil som genererar MongoDB databasen automatiskt, men kände att jag hade ont om tid för att sätta mig in i det.
- Uppdatera visitkort-delen är jag minst nöjd med, hade egentligen varit snyggare om man valde vilket visitkort man ville uppdatera via "Visa alla"-viewn. Men fick brist på tid.
- Tog mig 11 timmar att göra uppgiften. En extra halvtimme för att skriva den här README-filen på lördagen.
- Saknar unit tests och har inte så bra error-hantering. Låter mycket krascha, men i klienten får man notis att något gick fel. Hade egentligen kunnat utöka error-hanteringen på allt.
- Inget fan av att bilderna sparas lokalt i API:et, men har inte hanterat bildlagring tidigare. Antar att det bättre alternativet är att ha bilderna på en cloud-server.
