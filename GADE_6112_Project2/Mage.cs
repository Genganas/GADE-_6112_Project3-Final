using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GADE_6112_Project2
{
    internal class Mage : Enemy
    {
        public Mage(int x, int y, int hp = 5) : base(x, y, hp, 5, 5)
        {
            this.hp = hp;
        }
        public override Movement ReturnMove(Movement movement = Movement.NoMovement)
        {
            return Movement.NoMovement;
        }
        public override bool CheckRange(Character target) // Checks the range of a target
        {
            return (Math.Abs(target.X - this.X) <= 1 && Math.Abs(target.Y - this.Y) <= 1);
        }
    }
}
