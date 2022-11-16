using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GADE_6112_Project2.Tile;

namespace GADE_6112_Project2
{
    internal class Leader:Enemy
    {
        private Tile Target;
        Random leaderMove = new Random();
        public Leader(int x, int y) : base(x, y, 20, 20,2)
        {
            this.X = x;
            this.Y = y;
            weapon = new MeleeWeapon(MeleeWeapon.Types.LongSword);

        }
        public void setLeaderTarget(Hero target)
        {
            Target = target;
        }
        public Tile getLeaderTarget() { return Target; }
        public int getLeaderX() { return X; }
        public int getLeaderY() { return Y; }
        public override Movement ReturnMove(Movement direction = 0) // Leader needs to try and move towards the player at all times COME BACK AND CHANGE LATER NOT EVEN REMOTELY FINISHED
        {
            Leader leader = new Leader(this.X, this.Y);
            int leaderX = leader.X;
            int leaderY = leader.Y;
            int targetX = Target.X;
            int targetY = Target.Y;

            int moveDirection; // Local variable used for assigning random direction
            moveDirection = leaderMove.Next(5); // randomly generates a number which is then correlated with a direction.
            if (leaderX < targetX && currentVision[1].GetType() == typeof(EmptyTile) || leaderX < targetX && currentVision[1].Type == Tile.Tiletype.Gold)
            {
                Move(Movement.Down);
                return Movement.Down;
            }
            if (leaderX > targetX && currentVision[0].GetType() == typeof(EmptyTile) || leaderX > targetX && currentVision[0].Type == Tile.Tiletype.Gold)
            {
                Move(Movement.Up);
                return Movement.Up;
            }
            if (leaderY < targetY && currentVision[3].GetType() == typeof(EmptyTile) || leaderY < targetY && currentVision[3].Type == Tile.Tiletype.Gold)
            {
                Move(Movement.Right);
                return Movement.Right;
            }
            if (leaderY > targetY && currentVision[2].GetType() == typeof(EmptyTile) || leaderY > targetY && currentVision[2].Type == Tile.Tiletype.Gold)
            {
                Move(Movement.Left);
                return Movement.Left;
            }
            else
            {
                if (moveDirection == 0 && currentVision[0].GetType() == typeof(EmptyTile) || moveDirection == 0 && currentVision[0].Type == Tile.Tiletype.Gold) // if random num is 0 then get tiles around Character and their respective Tiletypes. And if they are empty then move in the returned direction.
                {
                    Move(Movement.Up);
                    return Movement.Up;

                }
                if (moveDirection == 1 && currentVision[1].GetType() == typeof(EmptyTile) || moveDirection == 1 && currentVision[1].Type == Tile.Tiletype.Gold)
                {
                    Move(Movement.Down);
                    return Movement.Down;
                }
                if (moveDirection == 2 && currentVision[2].GetType() == typeof(EmptyTile) || moveDirection == 2 && currentVision[2].Type == Tile.Tiletype.Gold)
                {
                    Move(Movement.Left);
                    return Movement.Left;
                }
                if (moveDirection == 3 && currentVision[3].GetType() == typeof(EmptyTile) || moveDirection == 3 && currentVision[3].Type == Tile.Tiletype.Gold)
                {
                    Move(Movement.Right);
                    return Movement.Right;
                }
                else
                {
                    Move(Movement.NoMovement);
                    return Movement.NoMovement;
                }
            }

        }
    }
}
