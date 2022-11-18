using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class Gold : Item
    {

        private Random random = new Random();
        private int goldAmount;
        public int GoldAmount { get => goldAmount; set => goldAmount = value; }

        public Gold(int x, int y) : base(x, y)
        {
            goldAmount = random.Next(1, 6);
        }
        public override string ToString()
        {
            return "Gold";
        }
    }
}
