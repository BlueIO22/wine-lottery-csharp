# wine-lottery-csharp
Dette er et vinlotteri api, som benytter seg av stripe som betalingsløsning

## formål
Å lage et vin lotteri som har ulike viner som loddes ut. Brukere kan kjøpe lodd, og lotteriet vil trekke ett tilfeldig lodd per vin. Fra vinen med lavest pris til den dyreste. 

## løsning
Løsningen er laget i .Net Core, og bruker .NET 6. Den er laget som et Web Api, og har flere endepunkt som ein kan se dokumentasjon på i swagger. Den bruker Stripe.Net til integrasjon med Stripe, denne er bare satt opp til test. APIet er laget med SOLID prinsippet til grunn. Og applikasjonen har noen enhetstester for å dekke at den funker som den skal. 

her er bilde av arkitektur: 

![lottery-csharp drawio (1)](https://user-images.githubusercontent.com/16582039/233932316-ade9e130-9cd2-4bec-bea5-dcb5dd569316.png)

## setup
Du kan bygge applikasjonen i .NET 6. Enten ved hjelp av cli eller Visual Studio

Ved Cli:
 ```dotnet build ```
 
 Applikasjonen kan kjøres ved:
 ``` dotnet run ```
 
 ## Database 
 ```ConnectionStrings``` finnes ikke i application.json, den er arvet i miljøvariabel i azure. 
 
 Diagram for databaseoppsett er her: 
 
