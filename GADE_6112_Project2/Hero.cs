using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class Hero : Character
    {


        public Hero(int x, int y, int hp, int maxHp) : base(x, y, hp, maxHp, 2)
        {

        }

        // Recieves the players movement from move and then creates then checks if a move can be made
        public override Movement ReturnMove(Movement move)
        {
            if (move == Movement.NoMovement) return move;
            return (CharacterMoves[(int)move].Type is Tiletype.EmptyTile or Tiletype.Gold) ? move : Movement.NoMovement;
        }

        public override string ToString() // String that displays the hero's stats
        {
            return $"Player Stats: \nHP: {this.hp}/{this.maxhp} \nDamage: {this.damage} \nGold: {this.goldAmount} \n[{this.X},{this.Y}]";
        }


    }
}
