


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

List<Attack> MeleeAttacks = new List<Attack>();
    Attack Punch = new Attack("punch", 20);
    Attack Kick =new Attack("kick", 15);
    Attack Tackle= new Attack( "tackle", 25);

    MeleeAttacks.Add(Punch);
    MeleeAttacks.Add(Kick);
    MeleeAttacks.Add(Tackle);


List<Attack> RangedAttacks = new List<Attack>();
    Attack ShootAnArrow = new Attack("shoot an arrow", 20);
    Attack ThrowAKnife =new Attack("throw a knife", 15);

    RangedAttacks.Add(ShootAnArrow);
    RangedAttacks.Add(ThrowAKnife);

List<Attack> MagicAttacks = new List<Attack>();
    Attack Fireball = new Attack("fireball", 20);
    Attack LightningBolt =new Attack("lightning bolt", 15);
    Attack StaffStrike =new Attack("staff strike", 15);

    MagicAttacks.Add(Fireball);
    MagicAttacks.Add(LightningBolt);
    MagicAttacks.Add(StaffStrike);

MeleeFighter Warrior =new MeleeFighter("Harlen", MeleeAttacks);
RangedFighter Hunter =new RangedFighter("Larnahu", RangedAttacks);
MagicCaster Shaman = new MagicCaster("Shamwow", MagicAttacks);

Warrior.PerformAttack(Hunter, Kick);
Warrior.Rage(Shaman, Punch);
if(Hunter.Distance>20)
{
Hunter.PerformAttack(Warrior, ShootAnArrow);
}
Hunter.Dash(Hunter);
Hunter.PerformAttack(Warrior,ShootAnArrow);
Shaman.PerformAttack(Warrior, Fireball);
Shaman.Heal(Hunter);
Shaman.Heal(Shaman);
// MeleeFighter.Rage(Hunter, Kick);