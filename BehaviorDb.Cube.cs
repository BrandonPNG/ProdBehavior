Cube god behavior that i worked on. In the XML for cube god change the HP to 15,000 and ajust drop tables to what you want. 
This is used on Dream Realms so the loot is boosted quite heavily. Enjoy

Please credit - 
Bork

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.realm;


namespace wServer.logic
{
partial class BehaviorDb
{
    private _ Cube = () => Behav()
.Init("Cube Overseer",
            new State(
            new Orbit(0.25, 7, target: "Cube God"),
            new Protect(1, "Cube God", protectionRange: 8, acquireRange: 10, reprotectRange: 8),
            new Shoot(10, count: 4, shootAngle: 10, predictive: 0.9, projectileIndex: 0, coolDown: 500)
            )
        )
        .Init("Cube Defender",
            new State(
            new Wander(0.5),
            new StayCloseToSpawn(0.5, range: 29),
            new Protect(1.5, "Cube God", protectionRange: 16, acquireRange: 20, reprotectRange: 16),
            new Follow(1, acquireRange: 12, range: 8),
            new Shoot(10, count: 2, shootAngle: 10, coolDown: 1000, predictive: 1, projectileIndex: 0)
            )
        )
        .Init("Cube Blaster",
            new State(
            new Orbit(2, 4, target: "Cube Defender"),
            new StayCloseToSpawn(0.5, range: 29),
            new Protect(1.5, "Cube God", protectionRange: 20, acquireRange: 24, reprotectRange: 20),
            new Follow(1.5, acquireRange: 14, range: 10),
            new Shoot(10, count: 2, shootAngle: 10, predictive: 1, projectileIndex: 0, coolDown: 1500),
            new Shoot(10, count: 1, predictive: 0.9, projectileIndex: 0, coolDown: 1000)
              )
        )
    .Init("Cube God",
        new State(
        new State("Attack",
           new Wander(.3),
           new StayAbove(.2, 150),
	         new Spawn("Cube Overseer", maxChildren: 3, initialSpawn: 1, coolDown: 100000),
	         new Spawn("Cube Defender", maxChildren: 3, initialSpawn: 2, coolDown: 100000),
	         new Spawn("Cube Blaster", maxChildren: 3, initialSpawn: 3, coolDown: 100000),
	         new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 10, predictive: 1, coolDown: 750),
	         new HpLessTransition(0.50, "Transition")
            ),
	        new State("Transition",
	        new Wander(.3),
	        new StayAbove(.2, 150),
	        new Flash(0xfFF0000, 1, 9000001),
	        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
	        new TimedTransition(5000, "Attack2")
	        ),
	        new State("Attack2",
	        new Wander(.3),
	        new StayAbove(.2, 150),
	        new Reproduce("Cube Overseer", 10, 10, 15000),
	        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 10, predictive: 1, coolDown: 750),
	        new HpLessTransition(0.25, "Transition2")
	        ),
	        new State("Transition2",
	        new Wander(.3),
	        new StayAbove(.2, 150),
	        new Flash(0xfFF0000, 1, 9000001),
	        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
	        new ConditionalEffect(ConditionEffectIndex.StunImmune, true),
	        new TimedTransition(5000, "Attack3")
	        ),
	        new State("Attack3",
	        new Wander(.3),
	        new StayAbove(.2, 150),
	        new Reproduce("Cube Overseer", 10, 10, 15000),
	        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 10, predictive: 1, coolDown: 750),
	        new Shoot(25, projectileIndex: 1, shootAngle: 10, count: 4, coolDown: 750)
                  )
                ),
            new MostDamagers(1,
            new ItemLoot("Dirk of Cronus", .003)
            ),
            new MostDamagers(2,
            new ItemLoot("Potion of Attack", .3),
            new ItemLoot("Potion of Defense", .3),
            new ItemLoot("Potion of Dexterity", 1),
            new ItemLoot("Potion of Wisdom", 1),
            new ItemLoot("Potion of Vitality", 1),
            new ItemLoot("Potion of Speed", 1)
            ),
            new Threshold(0.05,
            new TierLoot(8, ItemType.Weapon, .15),
            new TierLoot(9, ItemType.Weapon, .10),
            new TierLoot(8, ItemType.Armor, .14),
            new TierLoot(9, ItemType.Armor, .09),
            new TierLoot(4, ItemType.Ability, .09),
            new TierLoot(3, ItemType.Ring, .15)
            ),
            new Threshold(.18,
            new TierLoot(11, ItemType.Weapon, .04),
            new TierLoot(12, ItemType.Armor, .008)
            ),
            new Threshold(.10,
            new TierLoot(10, ItemType.Weapon, .05),
            new TierLoot(10, ItemType.Armor, .04),
            new TierLoot(11, ItemType.Armor, .03),
            new TierLoot(4, ItemType.Ability, .03),
            new TierLoot(4, ItemType.Ring, .05),
            new TierLoot(5, ItemType.Ring, .009)
           )
  );
}
}
