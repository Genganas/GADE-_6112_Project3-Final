using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class RangedWeapon:Weapon
    {
        private Types _type;
        public RangedWeapon(int x, int y, Types _type) : base(x, y, Tile.Tiletype.Weapon)
        {
            this._type = _type;
            this.Y = y;
            this.X = x;
            if (_type == Types.Longbow)
            {
                WeaponType = "LongBow";
                Durability = 10;
                Damage = 3;
                Cost = 3;
            }
            if (_type == Types.Rifle)
            {
                WeaponType = "Rifle";
                Durability = 6;
                Damage = 4;
                Cost = 5;
            }
        }
        public enum Types
        {
            Rifle,
            Longbow
        }
        public override string ToString()
        {
            string meleeInfo;
            meleeInfo = "No information added";
            if (_type == Types.Rifle)
            {
                meleeInfo = "Weapon Type: Ranged \n  Name: " + WeaponType + " \n  Damage: " + Damage + "\n Cost: " + Cost;
                return meleeInfo;
            }
            if (_type == Types.Longbow)
            {
                meleeInfo = "Weapon Type: Ranged \n  Name: " + WeaponType + " \n  Damage: " + Damage + "\n Cost: " + Cost;
                return meleeInfo;
            }
            else return meleeInfo;
        }
        public override int Range
        {
            set { }

            get { return base.Range; }

        }
        
        

    }
}
