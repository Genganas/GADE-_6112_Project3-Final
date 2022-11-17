using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GADE_6112_Project2.Tile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GADE_6112_Project2
{
    public class Leader:Enemy
    {
        private Tile target;
        Random leaderMove = new Random();
        public Leader(int x, int y,int hp = 20) : base(x, y,hp, 20,2)
        {
            weapon = new MeleeWeapon(MeleeWeapon.Types.LongSword);
            goldAmount = 2;

        }

        public Tile? Target { get => target; set => target = value; }
        public override Movement ReturnMove(Movement move = Movement.Up)
        {
            return Movement.NoMovement;
        }
    }
}
