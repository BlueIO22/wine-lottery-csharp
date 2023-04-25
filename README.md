# wine-lottery-csharp
Dette er et vinlotteri api, som benytter seg av stripe som betalingsløsning

## Formål
Å lage et vin lotteri som har ulike viner som loddes ut. Brukere kan kjøpe lodd, og lotteriet vil trekke ett tilfeldig lodd per vin. Fra vinen med lavest pris til den dyreste. 

## Løsningen
Løsningen er laget i .Net Core, og bruker .NET 6. Den er laget som et Web Api, og har flere endepunkt som en kan se dokumentasjon på i swagger. Den bruker Stripe.Net til integrasjon med Stripe, denne er bare satt opp til test. Apiet benytter *Interface segregation principle* for å skille mellom de ulike lagene. koden skiller seg med Controllers som er ytterpunktet. Deretter er det meste av buisness logikken satt i LotteryOrchestrator, som orkestrerer kjøringen av lotteriet og i Handlerene. Det siste laget er *Data Access Layer* som jeg har benevnet med Repositories, de har ansvar for operasjoner med databasen. Den siste tingen som må nevnes er PaymentService som jeg laget som et lag som knytter seg til Stripe. Alle lagene er skile med interfaces. 

Jeg hadde veldig lyst å legge til testing, men jeg fikk endel problemer med å sette opp test prosjektet, og for lite tid denne omgang til å gjøre det skikkelig.

her er bilde av arkitektur: 

![lottery-csharp drawio (1)](https://user-images.githubusercontent.com/16582039/233932316-ade9e130-9cd2-4bec-bea5-dcb5dd569316.png)

## Setup
Du kan bygge applikasjonen i .NET 6. Enten ved hjelp av cli eller Visual Studio

Ved Cli:
 ```dotnet build ```
 
 Applikasjonen kan kjøres ved:
 ``` dotnet run ```
 
 ## Database 
 ```ConnectionStrings``` finnes ikke i application.json, den er arvet i miljøvariabel i azure. 
 
 Diagram for databaseoppsett er her: 

 <img width="803" alt="image" src="https://user-images.githubusercontent.com/16582039/234012633-0a453097-71b5-4a70-b47d-20b6e2df8cb9.png">
 
 ## Ting som gjenstår
  - Enhetstester
  - BDD testing med Gherkin
  - Lage en pool av tråder, slik at man kan kjøre flere operasjoner på samtidig
  - Legge til cancellation token

