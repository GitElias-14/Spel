using System.Security;




class Client
{
    static void Main(string[] args)
    {
        // Inställningar för turnering
        double setXPgain = 0.5; // Hur mycket xp ska vinnaren få
        int setHealingPercent = 80; // Hur många procent ska deltagaren få tillbaka efter strid
        int setDrawLimit = 0; // Om man vill begränsa antalet attacker innan det blir oavgjort. Om skada är 0 för båda så blir det lika ändå

        // Lägg till dina karaktärer här
        List<Character> participants = new List<Character> {
            new Jedi("Yoda", new Alien()),
            new Jedi("Grogu", new Alien()),
            new Warrior("Conan", new Orc()),
            new Mage("Gandalf", new Fairy()),
            new Archer("Legolas", new Elf())
        };
        
        Tournament tournament = new Tournament(participants, setXPgain, setHealingPercent, setDrawLimit);
        tournament.StartTournament();   

    }
}


