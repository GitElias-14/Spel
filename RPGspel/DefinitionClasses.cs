// Packar ihop statsen i en record struct för att kunna använda på ett smidigt sätt
public readonly record struct StatGroup(double Strength, double Agility, double Intelligence);

class Race //Ras grundklass: (i fil för grundklasser)
{   
    protected Race (StatGroup stats, int initialHP , string[] celebration) //Konstruktor (protected så att endast ärvande klasser kan skapa raser)
    {
        Stats = stats;
        this.initialHP = initialHP;
        Celebrations = new List<string>(celebration).AsReadOnly();
    }
//Variabler:
//- Styrka, Smidighet, Intelligens (låst efter skapande)
    public StatGroup Stats { get;}
//- Start HP (låst efter skapande)
    public int initialHP { get; }
//- En lista på firanden som rasen har när den vinner en strid (låst efter skapande)
    public IReadOnlyList<string> Celebrations { get; }

}

class Character //Karaktär grundklass: (i fil för grundklasser)
{
    protected Character (string name, Race race, double xp, StatGroup atkMult, StatGroup defMult) //Konstruktor (protected så att endast ärvande klasser kan skapa karaktärer)
    {
        Name = name;
        Race = race;
        XP = xp;
        MaxHP = race.initialHP;
        HP = MaxHP; // Sätter HP till start HP när karaktären skapas (hämtat från rasen)
        atkMultipliers = atkMult;
        defMultipliers = defMult;
        onAttack = string.Empty;
        onDefense = string.Empty;
    }

    //Variabler:
    public string Name { get; } //- Namn (låst efter skapande genom att inte ha set;)
    public Race Race { get; } //- Ras från klass (låst efter skapande)
    public int MaxHP { get; } //- HP maxvärde (hämtat från rasen)
    private int hp; // Hjälpvariabel för HP propertyn
    public int HP // Aktuell HP (ska kunna modifieras under spelets gång)
    { 
        get { return hp; } 
        set // Körs varje gång HP ändras så att den inte går under 0 eller över MaxHP (händer det så får vi se över koden då exeption inte ska ske i normala fall)
        { 
            if (value < 0 || value > MaxHP) throw new ArgumentOutOfRangeException(nameof(HP), $"HP must be between 0 and {MaxHP}");    
            hp = value;
        } 
    }
    private double xp; // Hjälpvariabel för XP propertyn
    public double XP //- XP (ska kunna modifieras under spelets gång)
    { 
        get { return xp; } 
        set 
        { 
            if (value < 0 || value > 10) throw new ArgumentOutOfRangeException(nameof(XP), "XP must be between 0 and 10");
            xp = value;
        } 
    }

// - Meddelande onAttack
    protected string onAttack { get; set; }
// - Meddelande onDefense
    protected string onDefense { get; set; }

//  - attackMultipliers(styrka, smidighet, intelligens)
    protected StatGroup atkMultipliers { get; }
//  - defenseMultipliers(styrka, smidighet, intelligens)
    protected StatGroup defMultipliers { get; }

// Metoder:
// - OnAttack
//     - Multiplier för de olika kategorierna (styrka, smidighet och intelligens) som sedan ska multipliceras med rasens stats
    public (string message, double attackPoints) OnAttack()
    {
        Random rnd = new Random();
        double attackPoints = 
            ((atkMultipliers.Strength * Race.Stats.Strength) + 
            (atkMultipliers.Agility * Race.Stats.Agility) + 
            (atkMultipliers.Intelligence * Race.Stats.Intelligence))*xp;
        // Implementation for OnAttack method
        return (onAttack, attackPoints);            
    }        
//     - Meddelanden som ska skrivas ut beroende på kategori 
// - OnDefense
//     - Samma som OnAttack fast för försvar
    public (string message, double defensePoints) OnDefense()
    {
        double defensePoints = 
            ((defMultipliers.Strength * Race.Stats.Strength) + 
            (defMultipliers.Agility * Race.Stats.Agility) + 
            (defMultipliers.Intelligence * Race.Stats.Intelligence))*xp;
        return (onDefense, defensePoints);            
    }        
// - ToString
//     - Skriver ut karaktärens namn, ras, HP och XP
    public override string ToString()
    {
        return $"Name: {Name}, Race: {Race.GetType().Name}, HP: {HP}, XP: {XP:F2}";
    }

}