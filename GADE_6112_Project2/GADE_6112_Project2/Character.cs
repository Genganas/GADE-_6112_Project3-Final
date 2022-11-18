﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{

   public abstract class Character : Tile
    {   ///Part 3 code
        protected Weapon? weapon;
   

        ///
        protected int hp; // Health points 
        protected int maxhp; // Max Health
        protected int damage; // Attack damage
        protected int goldAmount;
        protected Tile[] characterMoves = new Tile[4]; // Vision array
        /// Up, Down, Left, Right, NoMovement
        public enum Movement  // Movement Enum for character
        {
            Up,
            Down,
            Left,
            Right,
            NoMovement
        }
        public Character(int x, int y, int hp, int maxHp, int damage) : base(x, y) //Constuctor
        {
            this.hp = hp;
            this.maxhp = maxHp;
            this.damage = damage;
        }

        public Tile[] CharacterMoves { get { return characterMoves; } set { characterMoves = value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }
        public int MaxHp { get { return maxhp; } set { maxhp = value; } }
        public Weapon WeaponUsed { get { return weapon; } set { weapon = value; } }

        public virtual void Attack(Character target) //Attack method to decrease Hp
        {
            if (!CheckRange(target)) return;

            if (weapon is null)
            {
                target.hp -= this.damage;
            }
            else
            {
                target.hp -= weapon.Dmg;

                weapon.Durability -= 1;
                if (weapon.Durability <= 0 )
                {
                    weapon = null;
                }
            }
        }

        public bool isDead() // Checks if a character is dead 
        {
            return (Hp <= 0);

        }
        public virtual bool CheckRange(Character target) // Checks fot the range 
        {
            if (weapon is null) return (DistanceTo(target) <= 1);
            else return (DistanceTo(target) <= weapon.weaponRange);
        }

        private int DistanceTo(Character target)// Checks for the distance of the enemy from a character
        {
            int xDis = Math.Abs(target.X - this.X);  //this.x is who is calling class  target.x is we want the distance from
            int yDis = Math.Abs(target.Y - this.Y);  //this.y is who is calling class  target.y is we want the distance from
            return xDis + yDis;
        }

        public void Move(Movement move) // changes the movement of a character
        {
            switch (move)
            {
                case Movement.Up:
                    this.Y -= 1;
                    break;
                case Movement.Down:
                    this.Y += 1;
                    break;
                case Movement.Left:
                    this.X -= 1;
                    break;
                case Movement.Right:
                    this.X += 1;
                    break;
                case Movement.NoMovement:
                    break;
            }
        }

        public void Pickup(Item i)
        {
            switch (i)
            {
                case Gold tmp:

                    goldAmount += tmp.GoldAmount;
                    break;
        
                default:
                    Equip((Weapon)i);
                    break;
            }
        }
        public void Loot(Character dead)
        {
            goldAmount += dead.goldAmount;
            if (weapon is null && this is not Mage && dead.weapon is not null)
            {
                weapon = dead.weapon;
            }
        }
        private void Equip(Weapon w)
        {
            weapon = w;
        }
        public abstract Movement ReturnMove(Movement move = 0); // returns the direction 
        public abstract override string ToString();
    }

}