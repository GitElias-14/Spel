// Specifika karaktärsklasser: (du kan lägga till nya karaktärsklasser här)
// Här använder vi statiska variabler för att kunna återanvända värdena för varje ny karaktär av samma typ
class Warrior : Character {
    private static readonly double InitialXP = 3.70;
    private static readonly Multipliers charAtkMult = new Multipliers(  //För attackformel
        Strength: 0.6, Agility: 0.3, Intelligence: 0.1);
    private static readonly Multipliers charDefMult = new Multipliers(  //För försvarsformel
        Strength: 0.3, Agility: 0.3, Intelligence: 0.2);
    public Warrior(string name, Race race) : base(name, race, InitialXP, charAtkMult, charDefMult) {
        onAttack = $"{name} swings a mighty sword!";
        onDefense = $"{name} blocks with a shield!";
}}

class Mage : Character {
    private static readonly double InitialXP = 2.75;
    private static readonly Multipliers charAtkMult = new Multipliers(
        Strength: 0.2, Agility: 0.2, Intelligence: 1.0);
    private static readonly Multipliers charDefMult = new Multipliers(
        Strength: 0.1, Agility: 0.4, Intelligence: 0.8);
    public Mage(string name, Race race) : base(name, race, InitialXP, charAtkMult, charDefMult) {
        onAttack = $"{name} casts a fireball!";
        onDefense = $"{name} creates a magical barrier!";
}}

class Archer : Character {
    private static readonly double InitialXP = 3.15;
    private static readonly Multipliers charAtkMult = new Multipliers(
        Strength: 0.3, Agility: 0.7, Intelligence: 0.2);
    private static readonly Multipliers charDefMult = new Multipliers(
        Strength: 0.2, Agility: 0.7, Intelligence: 0.4);
    public Archer(string name, Race race) : base(name, race, InitialXP, charAtkMult, charDefMult) {
        onAttack = $"{name} shoots an arrow!";
        onDefense = $"{name} dodges swiftly!";
}}

class Jedi : Character {
    private static readonly double InitialXP = 4.00;
    private static readonly Multipliers charAtkMult = new Multipliers(
        Strength: 0.4, Agility: 0.4, Intelligence: 0.8);
    private static readonly Multipliers charDefMult = new Multipliers(
        Strength: 0.3, Agility: 0.5, Intelligence: 0.9);
    public Jedi(string name, Race race) : base(name, race, InitialXP, charAtkMult, charDefMult) {
        onAttack = $"{name} uses the force!";
        onDefense = $"{name} defends with the force!";
}}