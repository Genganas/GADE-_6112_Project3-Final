using System;


namespace GADE_6112_Project2
{
     public class Shop
    {
        private Weapon[] weapons;
        private Random rndm;
        private Character buyer;
        public Shop(Character buyer)
        {
            this.buyer = buyer;

            rndm = new Random();
            weapons = new Weapon[3];
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }
        private Weapon RandomWeapon()
        {
            return (rndm.Next(4)) switch
            {
                0 => new RangedWeapon(RangedWeapon.Types.Longbow),
                1 => new RangedWeapon(RangedWeapon.Types.Rifle),
                2 => new MeleeWeapon(MeleeWeapon.Types.LongSword),
                3 => new MeleeWeapon(MeleeWeapon.Types.Dagger),

                //unreachable but it doesnt think so hence it being here, this will never be called
                _ => new RangedWeapon(RangedWeapon.Types.Rifle)
            };
        }
        public void Buy(int index)
        {
            if (index == 1 || index == 2 || index == 3)
            {
                buyer.GoldAmount -= weapons[index].weaponCost;
                buyer.Pickup(weapons[index]);
                weapons[index] = RandomWeapon();
            }
        }

        public bool CanBuy(int index)
        {
            return (weapons[index].weaponCost < buyer.GoldAmount);
        }

        public string DisplayWeapon(int index)
        {
            return $"Buy {weapons[index].getWeaponType} ({weapons[index].weaponCost} Gold)";
        }
    }
}
