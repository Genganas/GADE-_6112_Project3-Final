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
        public int Dmg { get => Damage; }
        public virtual int weaponRange { get => range; } // Set as virtual to be later overridden
        public int Durability { get => durability; set => durability = value; }
        public int weaponCost { get => Cost; }
        public string getWeaponType { get => WeaponType; set => WeaponType = value; }

        public abstract override string ToString();
    }
}
