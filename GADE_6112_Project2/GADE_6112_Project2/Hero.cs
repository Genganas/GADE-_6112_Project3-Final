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
            return (CharacterMoves[(int)move] is EmptyTile or Item) ? move : Movement.NoMovement;
        }

        public override string ToString() // String that displays the hero's stats
        {
            if (weapon is null)
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{MaxHp} {Environment.NewLine}Current weapon: Bare Hands {Environment.NewLine}Weapon range: 1 {Environment.NewLine}Weapon damage: {Damage} {Environment.NewLine}[{X}, {Y}]{Environment.NewLine}Gold Amount: {goldAmount}";
            }
            else
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{MaxHp} {Environment.NewLine}Current weapon: {weapon.getWeaponType} {Environment.NewLine}Weapon range: {weapon.weaponRange} {Environment.NewLine}Weapon damage: {weapon.Dmg} {Environment.NewLine}Weapon Durability: {weapon.Durability} {Environment.NewLine}[{X}, {Y}]{Environment.NewLine}Gold Amount: {goldAmount}";

            }
        }


    }
}
