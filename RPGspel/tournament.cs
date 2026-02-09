using System.Numerics;

class Tournament
{
    private List<Character> participants;
    private readonly double xpGain;
    private readonly int healingPercentage, drawLimit;
    private bool lastFightDraw;
    private readonly Random rng = new();

    public Tournament(List<Character> participants, double xpGain, int HealingPercentage, int drawLimit) // Konstruktor som tar in deltagare
    {
        this.participants = participants;
        this.xpGain = xpGain;
        this.healingPercentage = HealingPercentage;
        this.drawLimit = drawLimit;
    }  

    private void ShuffleParticipants() //Blanda deltagarlistan med Fisher-Yatesmetoden (https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle)
    {
        for (int i = participants.Count-1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (participants[i], participants[j]) = (participants[j], participants[i]);
        }
    }

    public void StartTournament()
    {
        Console.WriteLine("Tournament begins!");
        int roundNo = 1;
        while (participants.Count > 1 && !(lastFightDraw && participants.Count == 2))
        {
            Console.WriteLine($"\n--- Round {roundNo} ---\nParticipants: {participants.Count}");
            foreach (var p in participants) Console.WriteLine($"{p.ToString()}");

            StartRound();
            roundNo++;
            //Efter varje runda kan vi ta bort de karaktärer som har 0 HP från turneringen
            participants.RemoveAll(c => c.HP <= 0);
            //Återställ HP för kvarvarande karaktärer
            if (participants.Count != 1 && healingPercentage > 0 && !(lastFightDraw && participants.Count == 2))
            {
                Console.WriteLine("\n-- HP Recovery --");
                foreach (var p in participants)
                {
                    int lostHP = p.MaxHP - p.HP;
                    int recoverHP = (int)(lostHP * (healingPercentage / 100.0));
                    p.HP += recoverHP;
                    Console.WriteLine($"{p.Name} recovers {recoverHP} HP and now has {p.HP} HP.");
                }
            }
        }
        if (lastFightDraw) Console.WriteLine($"\nTournament ends in a draw between {participants[0].Name} and {participants[1].Name}!");
        else Console.WriteLine($"\nTournament ends! The winner is {participants[0].Name}!");
    }

    private void StartRound()
    {
        //Dela upp karaktärerna 2 och 2 i en turnering (random parning)
        ShuffleParticipants();
        for (int i = 0; i < participants.Count; i += 2)
        {
            Console.WriteLine($"\n-- Fight {(i / 2) + 1} --");

            if (i + 1 < participants.Count)
            {
                Character char1 = participants[i];
                Character char2 = participants[i + 1];
                Console.WriteLine($"\nFight between {char1.Name} and {char2.Name} begins!");
                Fight(char1, char2);
            }
            else
            {
                Console.WriteLine($"\n{participants[i].Name} gets a bye to the next round!");
                lastFightDraw = false; // En bye kan inte vara oavgjord så vi sätter den till false här
            }
        }
    }

    private void Fight(Character char1, Character char2)
    {
        Character attacker = char1;
        Character defender = char2;

        int lastDamage = -1; // För se om det är oavgjort
        for (int round = 0; round < 100; round++) // Max 100 ronder för att undvika oändliga loopar
        {   
            var attack = attacker.OnAttack();
            var defence = defender.OnDefense();
            int damage = Math.Max(0, Math.Min((int)Math.Ceiling(attack.attackPoints - defence.defensePoints), defender.HP)); // Beräkna skada men maximalt försvararens HP för att inte bli negativt
            Console.Write($"{attack.message}    {defence.message}   Damage dealt: {damage}   ");
            
            defender.HP -= damage;
            if ((damage == 0 && lastDamage == 0) || (drawLimit <= round && drawLimit > 0))
            {
                Console.WriteLine("\n The fight ended in a draw!");
                attacker.XP = Math.Min(10, attacker.XP + xpGain/2);
                defender.XP = Math.Min(10, defender.XP + xpGain/2);
                lastFightDraw = true;
                return;
            }
            lastDamage = damage;
            if (defender.HP <= 0) 
            {
                Console.WriteLine($"\n{defender.Name} has been defeated!");
                attacker.XP = Math.Min(10, attacker.XP + xpGain);
                string celebration = attacker.Race.Celebrations[rng.Next(attacker.Race.Celebrations.Count)]; // Slumpmässigt firande från rasen
                Console.WriteLine($"{attacker.Name}: {celebration}!");
                lastFightDraw = false;
                return; // Avsluta metoden när en karaktär har förlorat
            }
            Console.WriteLine($"{defender.Name} has {defender.HP} HP left.");

            // Byt mellan attack och försvar (tuple swap)
            (attacker, defender) = (defender, attacker);
        }
    }
}