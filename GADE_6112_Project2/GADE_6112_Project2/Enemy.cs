using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    abstract class Enemy : Character
    {
        public Random random = new Random();

        protected Enemy(int x, int y, int hp, int maxHp, int damage) : base(x, y, hp, maxHp, damage)
        {
        }
        public override string ToString() //Output string for enemy
        {
            return ($"Enemy at: [{this.X}, {this.Y}]\n Damage amount: ({this.Damage})\n Health: {this.hp}");
        }


    }
}
