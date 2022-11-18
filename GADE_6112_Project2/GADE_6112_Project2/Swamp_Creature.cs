using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;



namespace GADE_6112_Project2
{
    internal class Swamp_Creature : Enemy
    {   // Sets the swamp creatures hp to 10 and damage to 1
        public Swamp_Creature(int x, int y, int hp = 10) : base(x, y, hp, 10, 1)
        {
            weapon = new MeleeWeapon(MeleeWeapon.Types.Dagger);
            goldAmount = 1;
        }
        // Creates random movement for the swamp creature and then checks for the an empty space to move
        public override Movement ReturnMove(Movement movement = Movement.NoMovement)
        {
            int RandomMove = 0;
            bool drloop = true;
            int filledTile = 0;

            //checking if all 4 tiles are full
            for (int i = 0; i < characterMoves.Length; i++)
            {
                if (characterMoves[i] is not EmptyTile or Item) filledTile++;
            }
            if (filledTile >= 4) return Movement.NoMovement;

            //picking a tile
            while (drloop)
            {
                RandomMove = random.Next(4);

                drloop = !(characterMoves[RandomMove] is EmptyTile or Item);
            }

            switch (RandomMove)
            {
                case 0:
                    return Movement.Up;

                case 1:
                    return Movement.Down;

                case 2:
                    return Movement.Left;

                case 3:
                    return Movement.Right;

                default:
                    return Movement.NoMovement;
            }


        }
    }

}
