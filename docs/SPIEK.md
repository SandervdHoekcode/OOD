# OOD spiek (diagnostische toets)

Eén pagina om snel iets op te zoeken. Voorbeelden zijn gecompileerd en getest (.NET 8).
Patterns uitgebreid: https://refactoring.guru/design-patterns/catalog (kies bovenaan **C#**).
C# basics: https://kilo2071.github.io/ood/

## 0. Werkvolgorde

1. Lees de hele opdracht (2 min). Zie hoe groot het UML-deel is.
2. Diagram: eerst alleen boxes met namen, dan pijlen, dan inhoud. Maximaal 15 min.
3. Bouw in volgorde van de deelopdrachten. **Compileer na elk deel.** Een werkend half systeem is meer waard dan een mooi niet-compilerend geheel.
4. Main: controleer de verwachte waarden uit de opdracht.
5. Meer dan 5 min vast? Zet een commentaar met wat je wilde doen en ga door.

## 1. Welk pattern?

| In de opdracht staat... | Pattern | Kern |
|---|---|---|
| gedrag dat per moment wisselt, "verschillende manieren om X te berekenen", "er komen er nog bij" | **Strategy** | interface + een klasse per variant; de gebruiker houdt een interface-property |
| "op één plek aanmaken", object kiezen op basis van type of tekst | **Factory** | `static Maak(...)` met switch |
| "er mag maar één ... bestaan" | **Singleton** | private constructor + `static Instance` |
| iets melden aan anderen zonder dat de zender ze kent | **Observer** | lijst luisteraars + Abonneer / Afmelden / Meld |
| bestaande klasse past niet op de interface die je nodig hebt | **Adapter** | wrapper implementeert de doel-interface en roept de oude klasse aan |

## 2. Patterns in code

```csharp
// STRATEGY
public interface IKorting { decimal PasToe(decimal bedrag); }
public class GeenKorting : IKorting { public decimal PasToe(decimal b) => b; }
public class Procent10  : IKorting { public decimal PasToe(decimal b) => Math.Round(b * 0.90m, 2); }

public class Kassa
{
    public IKorting Korting { get; set; } = new GeenKorting();   // verwisselbaar
    public decimal Afrekenen(decimal bedrag) => Korting.PasToe(bedrag);
}
```

```csharp
// FACTORY (simple factory)
public static class VoertuigFactory
{
    public static Voertuig Maak(string regel)            // "scooter;S2;50"
    {
        string[] d = regel.Split(';');
        return d[0].Trim().ToLowerInvariant() switch
        {
            "scooter" => new Scooter(d[1], int.Parse(d[2])),
            _ => throw new ArgumentException($"Onbekend type: {d[0]}", nameof(regel))
        };
    }
}
```

```csharp
// SINGLETON
public sealed class Verhuurbedrijf
{
    private static readonly Verhuurbedrijf _instance = new();
    private Verhuurbedrijf() { }
    public static Verhuurbedrijf Instance => _instance;
}
// test: ReferenceEquals(Verhuurbedrijf.Instance, Verhuurbedrijf.Instance)  -> True
```

```csharp
// OBSERVER (met interface)
public interface IMeldingLuisteraar { void OntvangMelding(string tekst); }

public class Centrale
{
    private readonly List<IMeldingLuisteraar> _luisteraars = new();
    public void Abonneer(IMeldingLuisteraar l) => _luisteraars.Add(l);
    public void Afmelden(IMeldingLuisteraar l) => _luisteraars.Remove(l);
    public void Meld(string tekst)
    {
        foreach (IMeldingLuisteraar l in _luisteraars) l.OntvangMelding(tekst);
    }
}
public class Scherm : IMeldingLuisteraar
{
    public void OntvangMelding(string tekst) => Console.WriteLine($"[SCHERM] {tekst}");
}

// OBSERVER (met event, korter)
public class Sensor
{
    public event Action<double>? WaardeGewijzigd;
    public void Meet(double w) => WaardeGewijzigd?.Invoke(w);
}
// gebruik: sensor.WaardeGewijzigd += w => Console.WriteLine(w);
```

```csharp
// ADAPTER
public interface IBetaler { string Betaal(decimal bedrag); }
public class OudBetaalSysteem { public string DoePayment(double euro) => $"betaald {euro}"; }

public class OudBetaalAdapter : IBetaler
{
    private readonly OudBetaalSysteem _oud;
    public OudBetaalAdapter(OudBetaalSysteem oud) { _oud = oud; }
    public string Betaal(decimal bedrag) => _oud.DoePayment((double)bedrag);
}
```

## 3. Logging met ILogger (interface + implementatie + injectie)

```csharp
public interface ILogger
{
    void Info(string melding);
    void Fout(string melding);
}

public class ConsoleLogger : ILogger
{
    public void Info(string melding) => Console.WriteLine($"[INFO] {melding}");
    public void Fout(string melding) => Console.WriteLine($"[FOUT] {melding}");
}

public class BestandLogger : ILogger                       // later inpluggen, bedrijf blijft gelijk
{
    private readonly string _pad;
    public BestandLogger(string pad) { _pad = pad; }
    public void Info(string melding) => File.AppendAllText(_pad, $"[INFO] {melding}{Environment.NewLine}");
    public void Fout(string melding) => File.AppendAllText(_pad, $"[FOUT] {melding}{Environment.NewLine}");
}

// in de klasse die logt: alleen het TYPE ILogger kennen
private readonly ILogger _logger;
public Bedrijf(ILogger logger) { _logger = logger; }                 // via constructor
// of: public ILogger Logger { get; set; } = new ConsoleLogger();    // via property

// Loggen van een weigering: EERST loggen, DAN throwen (code na throw draait nooit)
_logger.Fout(melding);
throw new MijnException(id, melding);

// in Program: var bedrijf = new Bedrijf(new ConsoleLogger());
```

Let op: gebruik je eigen `ILogger`, geen `using Microsoft.Extensions.Logging;` (die heeft ook een ILogger).

## 4. Syntax-kaartjes

```csharp
// ABSTRACT, BASE-CONSTRUCTOR, OVERRIDE, TOSTRING
public abstract class Voertuig
{
    public string Id { get; }                         // alleen get
    public bool IsBeschikbaar { get; set; }
    protected Voertuig(string id)
    {
        if (string.IsNullOrWhiteSpace(id))            // vangt null, "" en spaties
            throw new ArgumentException("Id mag niet leeg zijn.", nameof(id));
        Id = id;
        IsBeschikbaar = true;
    }
    public abstract decimal BerekenPrijs(int minuten);
    public override string ToString() => $"{Id} (beschikbaar: {IsBeschikbaar})";
}

// INTERFACE + SUBKLASSE + SETTER MET VALIDATIE
public interface IOplaadbaar { int AccuPercentage { get; } void LaadOp(); }

public class Scooter : Voertuig, IOplaadbaar
{
    private int _accu;
    public int AccuPercentage
    {
        get => _accu;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "0 t/m 100");
            _accu = value;
        }
    }
    public Scooter(string id, int accu) : base(id) { AccuPercentage = accu; }
    public override decimal BerekenPrijs(int minuten) => 1.00m + 0.25m * minuten;
    public void LaadOp() => AccuPercentage = 100;
    public override string ToString() => $"{base.ToString()}, accu {AccuPercentage}%";
}
```

```csharp
// EIGEN EXCEPTION
public class MijnException : Exception
{
    public string Id { get; }
    public MijnException(string id, string melding) : base(melding) { Id = id; }
}

// TRY / CATCH / FINALLY: specifiek bovenaan, algemeen onderaan
try { /* ... */ }
catch (MijnException ex) { Console.WriteLine(ex.Message); }
catch (Exception ex)     { Console.WriteLine(ex.Message); }
finally { /* draait altijd */ }
// opnieuw gooien: "throw;"  (niet "throw ex;")
```

```csharp
// COLLECTIES EN UPCASTING
private readonly List<Voertuig> _voertuigen = new();
public IReadOnlyList<Voertuig> Voertuigen => _voertuigen;           // naar buiten alleen lezen

List<IOplaadbaar> lijst = _voertuigen.OfType<IOplaadbaar>().ToList();   // using System.Linq;
foreach (IOplaadbaar o in lijst) o.LaadOp();

if (v is Scooter s) { /* s is hier een Scooter */ }                 // downcast met check
```

```csharp
// GENERIEK MET CONSTRAINT
public interface IHeeftErnst { int Ernst { get; } }
public class Logboek<T> where T : IHeeftErnst
{
    private readonly List<T> _items = new();
    public void Voeg(T item) => _items.Add(item);
    public IEnumerable<T> Filter(int minErnst) => _items.Where(i => i.Ernst >= minErnst);
}

// ENUM, SWITCH EXPRESSION, PARSE
public enum Formaat { Small, Medium, Large }
decimal toeslag = f switch { Formaat.Small => 0m, Formaat.Medium => 2m, Formaat.Large => 4m,
                             _ => throw new ArgumentOutOfRangeException(nameof(f)) };
Formaat f = Enum.Parse<Formaat>("medium", ignoreCase: true);

// GELD EN REKENEN
decimal x = 8.00m;                 // m-suffix, geen double
Math.Round(x * 0.90m, 2);          // afronden op 2 decimalen
Math.Max(0m, bedrag - 2.00m);      // nooit onder nul
double pct = aantal / 100.0;       // let op: aantal / 100 is integer-deling (5 / 100 = 0), gebruik 100.0
```

## 5. UML-pijlen

| Relatie | Lijn | Kop |
|---|---|---|
| Overerving (erft van) | hele lijn | holle driehoek bij de **basisklasse** |
| Implementeert interface | stippellijn | holle driehoek bij de **interface** |
| Associatie (kent / gebruikt) | hele lijn | open pijl, met kardinaliteit (1, 0..*, 1..*) |
| Aggregatie (heeft, kan los bestaan) | hele lijn | **lege** ruit bij het geheel |
| Compositie (onderdeel, bestaat niet los) | hele lijn | **gevulde** ruit bij het geheel |
| Afhankelijkheid (maakt / gooit / gebruikt kort) | stippellijn | open pijl |

Notatie: `+` public, `-` private, `#` protected. Abstracte klasse of methode: cursief of `<<abstract>>`. Interface: `<<interface>>`. Enum: `<<enumeration>>`. In een subklasse alleen wat nieuw of overridden is.

## 6. Mijn eigen valkuilen

- Hoofdlettergevoelig: Klasse / Property / Methode met hoofdletter, veld / parameter / variabele klein. `Zone` is niet `zones`.
- `Naam = naam`: links staat wat gevuld wordt. Omgedraaid geeft geen fout maar blijft leeg.
- Geen `;` na `foreach (...)`, `if (...)` of een methodekop.
- `Gebouw.Naam` (klasse) werkt niet, `gebouw.Naam` (object) wel. Binnen de klasse zelf gewoon `Naam`.
- `static` en `Main` horen alleen bij Program, niet in domeinklassen.
- Eén constructor met alle parameters, niet één per veld.
- Interface vergeten achter `:` en `OfType<...>()` slaat de klasse stil over. Geen foutmelding.
- `: base(melding)` vergeten in een eigen exception. `catch (Exception)` boven een specifieke catch is een compileerfout. Geen lege catch.
- Een ingebouwde `ArgumentException` wordt niet gevangen door `catch (EigenException)`.
- Een alarm of normaal verloop is geen exception. Een exception is voor een ongeldige toestand waar de methode zelf niets mee kan.
- Na een `throw` wordt de rest overgeslagen en blijft de oude waarde staan.
- Compileerfout `no argument given that corresponds to ... 'id'`: je mist `: base(...)`.
- `override` vergeten bij een abstracte methode: compileerfout.

## 7. Waar staat het in mijn eigen repo?

Op GitHub: druk op `t` en zoek op bestandsnaam. Controleer de namen hieronder in je repo.

| Concept | Zoek naar |
|---|---|
| abstracte klasse, virtual / override, polymorfisme | `HardwareComponent`, `Apparaat`, `Sensor`, `Thermostaat`, `DimbareLamp` |
| interfaces | `IAanstuurbaar`, `IEnergieverbruiker`, `IAlertbaar` |
| `OfType<...>()`, upcasting via interface | `CampusManager` |
| eigen exceptions + `: base(...)` | `BigBrutusException` en de drie subklassen |
| setter met validatie + throw | `Thermostaat`, `DimbareLamp` (`GrenswaardeOverschredenException`) |
| try / catch / finally | `Program.cs` (Main) |
| generiek met constraint | `Logboek<T>` |
| IReadOnlyList / encapsulatie | `Zone`, `Gebouw`, `Campus` |

Niet in mijn repo: Strategy, Factory, Singleton, Observer, Adapter. Gebruik sectie 2 of refactoring.guru.

## 8. Rider

- `Alt+Enter`: snelle oplossing (interface implementeren, ontbrekende using).
- `Alt+Insert`: genereren (constructor, nieuwe klasse).
- `Shift+F10`: uitvoeren.
- Controleer dat alle AI- en inline-completion-functies uit staan (zoek in Settings op "AI" en "completion").
- De keymap op school kan anders zijn dan de standaard.
