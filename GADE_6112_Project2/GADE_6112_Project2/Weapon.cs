using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    abstract class Weapon : Item
    {
        protected int Damage;

        protected int Durability;
        protected int Cost;
        protected string WeaponType;

        public virtual int Range
        {
            set { }

            get { return 0; }
        }
        public Weapon(int x, int y, Tile.Tiletype type) : base(x, y)
        {
            this.X = x;
            this.Y = y;

        }
        public int getWeaponDamage() { return Damage; }
        public virtual int getWeaponRange() { return Range; } // Set as virtual to be later overridden
        public int getWeaponDurability() { return Durability; }
        public int getWeaponCost() { return Cost; }
        public string getWeaponType() { return WeaponType; }
    }
}
