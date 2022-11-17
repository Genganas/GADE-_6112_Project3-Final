using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
   public abstract class Weapon : Item
    {
        protected int Damage;
        protected int range;
        protected int durability;
        protected int Cost;
        protected string WeaponType;

        public Weapon(int x, int y) : base(x, y)
        {
            WeaponType = string.Empty;

        }
        public int wDamage { get => Damage; }
        public virtual int weaponRange() { return range; } // Set as virtual to be later overridden
        public int Durability() { return durability; }
        public int weaponCost() { return Cost; }
        public string getWeaponType { get => WeaponType; set => WeaponType = value; }

        public abstract override string ToString();
    }
}
