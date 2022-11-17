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
        public MeleeWeapon(Types weaponTypes, int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponTypes)
            {
                case Types.LongSword:
                    this.WeaponType = "Longsword";
                    Durability = 6;
                    Damage = 4;
                    Cost = 3;
                    break;
                case Types.Dagger:
                    this.WeaponType = "Dagger";
                    durability = 10;
                    Damage = 3;
                    Cost = 3;
                    break;
            }
        }

     

       
        public MeleeWeapon(Types weaponType, int durability) : base(-1, -1)
        {
            switch (weaponType)
            {
                case Types.LongSword:
                    this.WeaponType = "Longsword";
                    this.durability = durability;
                    Damage = 4;
                    Cost = 3;
                    break;
                case Types.Dagger:
                    this.WeaponType = "Dagger";
                    this.Durability = durability;
                    Damage = 3;
                    Cost = 3;
                    break;
            }
        }

        public override int weaponRange { get => 1; }
        public override string ToString()
        {
            return WeaponType;
        }

    }
}
