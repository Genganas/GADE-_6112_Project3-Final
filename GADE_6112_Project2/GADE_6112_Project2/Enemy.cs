using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    abstract class Enemy : Character
    {
        public Random random = new Random();

        protected Enemy(int x, int y, int hp, int maxHp, int damage) : base(x, y, hp, maxHp, damage)
        {
        }
        public override string ToString() //Output string for enemy
        {
            if (weapon is null)
            {
                return this switch
                {
                    Swamp_Creature => $"Bare Handed: Swamp Creature ({hp}/{MaxHp}HP) at [{X}, {Y}] ({damage})",
                    Mage => $"Bare Handed: Mage ({hp}/{MaxHp}HP) at [{X}, {Y}] ({damage})",
                    Leader => $"Bare Handed: Leader ({hp}/{MaxHp}HP) at [{X}, {Y}] ({damage})",
                    _ => $"This is unreachable but the ToString thinks otherwise",
                };
            }
            else
            {
                return this switch
                {
                    Swamp_Creature => $"Equiped: Swamp Creature ({hp}/{MaxHp}HP) at [{X}, {Y}] with {weapon.getWeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    Mage => $"Equiped: Mage ({hp}/{MaxHp}HP) at [{X}, {Y}] with {weapon.getWeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    Leader => $"Equiped: Leader ({hp}/{MaxHp}HP) at [{X}, {Y}] with {weapon.getWeaponType} ({weapon.Durability} x {weapon.Dmg})",
                    _ => $"This is unreachable but the ToString thinks otherwise",
                };
            }
        }


    }
}
