using System;


namespace GADE_6112_Project2
{
    public abstract class Tile
    {
        private int x;
        private int y;

        public Tile(int x, int y) //Public accessor method
        {
            this.x = x;
            this.y = y;
        }
        //Tiletype enum for the types of tiles
        /// <summary>
        /// Hero, Enemy, Gold, Weapon, EmptyTile, Obstacle
        /// </summary>
        public enum Tiletype
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
            Obstacle,
            EmptyTile
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Tiletype Type { get; set; }
    }
}
