using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class MeleeWeapon: Weapon
    {
        public enum Types
        {
            Dagger,
            LongSword
        };
        public Types _type;
        public MeleeWeapon(int x, int y,Types _type) : base(x, y,Tile.Tiletype.Weapon)
        {
            this._type = _type;
            this.Y = y;
            this.X = x;
            if (_type == Types.Dagger)
            {
                WeaponType = "Dagger";
                Durability = 10;
                Damage = 3;
                Cost = 3;
            }
            if (_type == Types.LongSword)
            {
                WeaponType = "LongSword";
                Durability = 6;
                Damage = 4;
                Cost = 5;
            }
        }

     

        public override string ToString()
        {
            string meleeInfo;
            meleeInfo = "No information added";
            if (_type == Types.Dagger)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: " + WeaponType + "\n  Damage: " + Damage + "\n Cost: " + Cost;
                return meleeInfo;
            }
            if (_type == Types.LongSword)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: " + WeaponType + "\n  Damage: " + Damage + "\n Cost: " + Cost;
                return meleeInfo;
            }
            else return meleeInfo;
        }

        public override int Range
        {
            set { }

            get { return 1; }

        }
        
    }
}
