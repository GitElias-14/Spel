/*
Skapa ett gäng karaktärer
Dela upp karaktärerna 2 och 2 i en turnering (random parning)
om det är ojämnt antal så får den sista karaktären en "bye" och går vidare automatiskt
varja strid ska gå i rundor
    - en attackerar, den andra försvarar varannan gång
    - skriv ut karaktärerenas actions tillsammans med uppdaterad status
    - Endast försvarare kan ta skada i rundan
    - Skada = attackpoäng - försvarspoäng (om skada < 0 så blir den 0)
    - vinnande karaktär får 0.50 xp och firar med ett slumpmässigt firande från sin ras
    - om det blir oavgjort (vad menas här, är det om skada = 0?) så får båda karaktärerna 0.25 xp och ingen firar
    - Efter vunnen match så får man tillbaka hp efter regler som vi satt upp själva (ex 80% av förlorad hp)
    parametrar för turneringen ska inte vara hårdkodade! dvs vi behöver sätta in dem i konstruktorn

*/