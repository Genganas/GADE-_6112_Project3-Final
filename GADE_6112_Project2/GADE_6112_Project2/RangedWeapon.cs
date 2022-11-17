using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class RangedWeapon:Weapon
    {
     
        public RangedWeapon(Types weaponType,int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponType)
            {
                case Types.Longbow:
                    this.WeaponType = "Longbow";
                    durability = 4;
                    range = 2;
                    Damage = 4;
                    Cost = 6;
                    break;
                case Types.Rifle:
                    this.WeaponType = "Rifle";
                    Durability = 3;
                    range = 3;
                    Damage = 5;
                    Cost = 7;
                    break;
            }

        }
        public enum Types
        {
            Rifle,
            Longbow
        }
        public RangedWeapon(Types weaponType, int durability) : base(-1, -1)
        {
            switch (weaponType)
            {
                case Types.Longbow:
                    this.WeaponType = "Longbow";
                    this.Durability = durability;
                    range = 2;
                    Damage = 4;
                    Cost = 6;
                    break;
                case Types.Rifle:
                    this.WeaponType = "Rifle";
                    this.Durability = durability;
                    range = 3;
                    Damage = 5;
                    Cost = 7;
                    break;
            }
        }

        public override int weaponRange { get => base.range; }
        public override string ToString()
        {
            return WeaponType;
        }



    }
}
