using System.Security;

class Client
{
    static void Main(string[] args)
    {
        List<Character> participants = new List<Character> {
            new Jedi("Yoda", new Alien()),
            new Jedi("Grogu", new Alien()),
            new Warrior("Conan", new Orc()),
            new Mage("Gandalf", new Fairy()),
            new Archer("Legolas", new Elf())
        };
        Tournament tournament = new Tournament(participants, 0.5, 80, 0);
        tournament.StartTournament();   

    }
}


