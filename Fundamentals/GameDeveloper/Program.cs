


List<Attack> goblinAttacks = new List<Attack>();


Attack Smash= new Attack("smash", 20);
Attack Cleave= new Attack("cleave", 10);
Attack WhirleyBolt= new Attack("whirley-bolt", 30);

goblinAttacks.Add(Smash);
goblinAttacks.Add(Cleave);
goblinAttacks.Add(WhirleyBolt);



Enemy Goblin = new Enemy("Harvey", goblinAttacks);

Goblin.RandomAttack();
Goblin.RandomAttack();
Goblin.RandomAttack();

