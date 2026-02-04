class Elf : Race {
    public Elf() : base(
        stats: new StatGroup(Strength: 4, Agility: 6, Intelligence: 7),
        initialHP: 30,
        celebration: new string[] { "jippi", "hurra", "fantastiskt" })
{  }}

class Fairy : Race {
    public Fairy() : base(
        stats: new StatGroup(Strength: 2, Agility: 5, Intelligence: 9),
        initialHP: 20,
        celebration: new string[] { "fantabulöst", "magiskt", "mipp" })
{  }}

class Orc : Race {
    public Orc() : base(
        stats: new StatGroup(Strength: 10, Agility: 3, Intelligence: 2),
        initialHP: 40,
        celebration: new string[] { "öööh", "höhöhö", "jag krossa" })
{  }}

class Alien : Race {    
    public Alien() : base(
        stats: new StatGroup(Strength: 2, Agility: 5, Intelligence: 10),
        initialHP: 35,
        celebration: new string[] { "Luminous beings are we, not this crude matter.", "If so powerful you are, why leave?", "Killed him I did" })
{  }}
