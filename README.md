### Introduktion til Rally Projektet

Rally projektet er en flerlagsapplikation designet til at håndtere flere brugere med forskellige adgangs privilegier. Projektet anvender Clean Architecture, som opdeler ansvarsområder i adskilte lag, hver med specifikke funktioner. Denne struktur forbedrer skalerbarhed, vedligeholdelse og muliggør evolution af applikationen over tid med minimal indvirkning på eksisterende kode. UI er sat op med Blazor Webassembly der henter data fra API'en.

### Opstarts Vejledning

- **Visual Studio Code**: Har sin egen [launch.json](/.vscode/launch.json) fil, der er konfigureret til at starte API og Web projektet. Kør "Rally All" i debuggerren for at starte applicationen.

- **Visual Studio**: Skal være sat til at køre både [Rally.Api](src/Rally.Api/Rally.Api.csproj) og [Rally.Blazor](src/Rally.Blazor/Rally.Blazor.csproj) som opstarts projekter. 

- **Database Adgang**: skal være sat op gennem Cisco eller UCL's netværk. Database konfigurationerne er sat op i [appsettings.json](/src/Rally.Api/appsettings.json).

#### Arkitektur og Laginteraktion

- **Rally.Api**: Fungere som indgangspunkt for HTTP-anmodninger og delegerer operationer til applikationslaget. Det er konfigureret i [src/Rally.Api/Program.cs](/src/Rally.Api/Program.cs#1%2C1-1%2C1), hvor tjenester som Swagger til API-dokumentation er opsat.

- **Rally.Application**: Indeholder forretningslogik og applikationstjenester. Dette lag fungerer som formidler mellem API og infrastrukturlagene, og orkestrerer dataflow og operationer. Tjenester i dette lag, såsom [SignBaseService](../../README.md#15%2C196-15%2C196) og [EquipmentService](/README.md#15%2C309-15%2C309), bruger grænseflader defineret i Core-laget til at interagere med data.

- **Rally.Core**: Definerer domænemodeller, grænseflader for repositories og specifikationer for forespørgsler. Dette lag indkapsler forretningsreglerne og fungerer som en kontrakt for dataoperationer.

- **Rally.Infrastructure**: Implementerer grænseflader fra Core-laget og leverer konkret dataadgangslogik ved hjælp af Entity Framework Core. Det interagerer med databasen og udfører operationer defineret af applikationslaget.

#### Designmønstre og Metodologier

- **Repository Pattern**: Abstraherer dataadgangslogik, hvilket gør applikationslagets kode mere vedligeholdelig og uafhængig af dataadgangslogikken.

- **Dependency Injection (DI)**: Opnår løs kobling mellem klasser og deres afhængigheder, konfigureret i [Program.cs](/src/Rally.Api/Program.cs#1%2C1-1%2C1) filerne for API og Web-projekter.

- **AutoMapper**: Faciliterer objektmapping mellem domæneenheder og DTO'er (Data Transfer Objects), hvilket reducerer mængden af boilerplate kode nødvendig for at transformere data mellem lagene.

- **Entity Framework Core**: Leverer ORM-understøttelse, som forenkler dataadgang og manipulation gennem LINQ-forespørgsler og stærkt typede modeller.

- **Fluent Validation**: Anvendes til at implementere valideringslogik på en deklarativ måde. Det giver mulighed for at definere valideringsregler for domænemodeller på en klar og konsis måde. Fluent Validation er brugt i 'Rally.Application' laget, hvor det fx er implementeret i [CategoryValidator.cs](/src/Rally.Application/Validators/CategoryValidator.cs#1%2C1-1%2C1).


### Blazor Projektet

Blazor projektet i Rally fungerer som brugergrænsefladen og anvender Blazor WebAssembly til at levere interaktive webbrugergrænseflader. Dette projekt er konfigureret til at consume API'et eksponeret af `Rally.Api`, hvilket betyder, at der ikke er en direkte kobling til `Rally.Application` laget, men snarere en kommunikation via HTTP-anmodninger.

#### Konfiguration og Opsætning

Blazor projektet er sat op til at køre som en klient-side applikation i brugernes browser. Det er konfigureret til at anvende moderne webteknologier og værktøjer for at sikre en responsiv og dynamisk brugeroplevelse.


- **HTTP Kommunikation**: Anvender `HttpClient` til at sende og modtage HTTP-anmodninger fra `Rally.Api`, hvilket gør det muligt for Blazor-applikationen at hente og sende data asynkront.

  ```razor:src/Rally.Blazor/_Imports.razor
  1|@using System.Net.Http
  ```
  En implementering af dette kan ses i [CategoryService.cs](/src/Rally.Blazor/Services/CategoryService.cs#1%2C1-1%2C1)

#### Komponentbaseret Arkitektur

Blazor projektet anvender en komponentbaseret arkitektur, der gør det muligt at opbygge brugergrænseflader med genbrugelige og isolerede komponenter. Et eksempel på dette er `CategoryDetails` komponenten, som håndterer visningen af detaljer for en specifik kategori.

- **CategoryDetails Komponent**: Denne komponent viser detaljeret information om en kategori. Den henter data ved hjælp af [CategoryService](/src/Rally.Blazor/Pages/CategoryPage/CategoryDetailsBase.cs#10%2C30-10%2C30) og viser navn og regler for den pågældende kategori. Komponenten giver også mulighed for at opdatere eller slette kategorien gennem navigationslinks.

#### Integration med Rally.Api

Blazor projektet integrerer med `Rally.Api` ved at forbruge de endpoints, der er defineret i API'et. Dette sikrer, at brugergrænsefladen kan opdatere og vise data dynamisk baseret på brugerinteraktioner og systemændringer.

- **Datahåndtering og Opdateringer**: Bruger asynkrone metoder til at håndtere data, hvilket sikrer en glat og responsiv brugeroplevelse selv under datahentning og -opdatering.

#### Teknologier og Værktøjer

- **Blazor WebAssembly**: Gør det muligt for .NET kode at køre i browseren ved hjælp af WebAssembly.
- **Bootstrap og CSS**: Anvendes til at style applikationen og sikre en moderne og tilgængelig brugergrænseflade.




