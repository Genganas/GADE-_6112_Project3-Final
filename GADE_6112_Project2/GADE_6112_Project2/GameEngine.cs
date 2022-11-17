using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class GameEngine
    {
        private Map map;
        private Shop shop;
        private static readonly string
            HeroChar = "ඞ",
            SwampCreatureChar = "Ω",
            ObstacleChar = "║",
            EmptyChar = ".",
            GoldChar = "⌬",
            MageChar = "m",
            BowChar = "🏹",
            DaggerChar = "🗡",
            LongSwordChar = "⚔",
            RifleChar = "𒌙",
            Leaderchar = "♔";///3.1
        public GameEngine()
        {
            map = new Map(10, 15, 10, 15, 5, 5);
            shop = new Shop(map.HeroPlayer);
        }

        public Map Map { get { return map; } }
        public Shop GameShop { get => shop; }

        public bool MovePlayer(Character.Movement direction) //Movement for player 
        {
            //checks if the move is valid
            if (map.HeroPlayer.ReturnMove(direction) == direction)
            {
                switch (direction)
                {
                    case Character.Movement.Up:
                        Item? item = map.GetItemAtPosition(map.HeroPlayer.Y - 1, map.HeroPlayer.X);
                        if (item is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item;
                            map.HeroPlayer.GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = map.GetItemAtPosition(map.HeroPlayer.Y + 1, map.HeroPlayer.X);
                        if (item2 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item2;
                            map.HeroPlayer.GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = map.GetItemAtPosition(map.HeroPlayer.Y, map.HeroPlayer.X - 1);
                        if (item3 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item3;
                            map.HeroPlayer.GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = map.GetItemAtPosition(map.HeroPlayer.Y, map.HeroPlayer.X + 1);
                        if (item4 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item4;
                            map.HeroPlayer.GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                }
                //Moves the player in the requested direction
                map.HeroPlayer.Move(direction);

                map.GameMap[map.HeroPlayer.Y, map.HeroPlayer.X] = new Hero(map.HeroPlayer.X, map.HeroPlayer.Y, map.HeroPlayer.Hp, map.HeroPlayer.MaxHp) { Type = Tile.Tiletype.Hero };
                switch (direction)
                {
                    //makes the tile the player was in empty after they leave.
                    case Character.Movement.Up:
                        map.GameMap[map.HeroPlayer.Y + 1, map.HeroPlayer.X] = new EmptyTile(map.HeroPlayer.X, map.HeroPlayer.Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Down:
                        map.GameMap[map.HeroPlayer.Y - 1, map.HeroPlayer.X] = new EmptyTile(map.HeroPlayer.X, map.HeroPlayer.Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Left:
                        map.GameMap[map.HeroPlayer.Y, map.HeroPlayer.X + 1] = new EmptyTile(map.HeroPlayer.X, map.HeroPlayer.Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Right:
                        map.GameMap[map.HeroPlayer.Y, map.HeroPlayer.X - 1] = new EmptyTile(map.HeroPlayer.X, map.HeroPlayer.Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                }
                return true;
            }
            else
            {
                map.UpdateVision();
                return false;
            }
        }

        public void MoveEnemy(Character.Movement direction = Character.Movement.NoMovement)
        {
            for (int i = 0; i < map.Enemies.Length; i++)
            {
                if (map.Enemies[i].isDead()) return;


                direction = map.Enemies[i].ReturnMove(direction);

                switch (direction)
                {
                    case Character.Movement.Up:
                        Item? item = map.GetItemAtPosition(map.Enemies[i].Y - 1, map.Enemies[i].X);
                        if (item is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item;
                            map.Enemies[i].GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = map.GetItemAtPosition(map.Enemies[i].Y + 1, map.Enemies[i].X);
                        if (item2 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item2;
                            map.Enemies[i].GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = map.GetItemAtPosition(map.Enemies[i].Y, map.Enemies[i].X - 1);
                        if (item3 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item3;
                            map.Enemies[i].GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = map.GetItemAtPosition(map.Enemies[i].Y, map.Enemies[i].X + 1);
                        if (item4 is Gold)
                        {
                            Gold goldItem;
                            goldItem = (Gold)item4;
                            map.Enemies[i].GoldAmount += goldItem.GoldAmount;
                        }
                        break;
                }
                //Moves the enemies in the requested direction
                map.Enemies[i].Move(direction);
                switch (map.Enemies[i])
                {
                    case Swamp_Creature:
                        map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = new Swamp_Creature(map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp) { Type = Tile.Tiletype.Enemy };
                        break;
                    case Mage:
                        map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = new Mage(map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp) { Type = Tile.Tiletype.Enemy };
                        break;
                    case Leader:
                        map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = new Leader(map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp) { Type = Tile.Tiletype.Enemy };
                        break;
                }
                switch (direction)
                {
                    //makes the tile the enemy was in empty after they leave.
                    case Character.Movement.Up:
                        map.GameMap[map.Enemies[i].Y + 1, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Down:
                        map.GameMap[map.Enemies[i].Y - 1, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Left:
                        map.GameMap[map.Enemies[i].Y, map.Enemies[i].X + 1] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                    case Character.Movement.Right:
                        map.GameMap[map.Enemies[i].Y, map.Enemies[i].X - 1] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                        break;
                }
            }
        }
        public void EnemyAttack()
        {
            for (int i = 0; i < map.Enemies.Length; i++)
            {
                if (map.Enemies[i].isDead()) continue;
                switch (map.Enemies[i])
                {
                    case Swamp_Creature:
                        map.Enemies[i].Attack(map.HeroPlayer);
                        break;
                    case Mage:
                        map.Enemies[i].Attack(map.HeroPlayer);
                        for (int j = 0; j < map.Enemies.Length; j++)
                        {
                            if (map.Enemies[i] == map.Enemies[j]) continue;
                            map.Enemies[i].Attack(map.Enemies[j]);
                        }
                        break;
                    case Leader:
                        map.Enemies[i].Attack(map.HeroPlayer);
                        break;
                    default:
                        break;
                }
                if (map.Enemies[i].isDead())
                {
                    map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                }
            }
        }
        public override string ToString() // Symbols generator for the map
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < map.GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < map.GameMap.GetLength(1); j++)
                {
                    switch (map.GameMap[i, j].Type)
                    {
                        case Tile.Tiletype.Hero:
                            stringBuilder.Append(HeroChar);
                            break;
                        case Tile.Tiletype.Obstacle:
                            stringBuilder.Append(ObstacleChar);
                            break;
                        case Tile.Tiletype.Enemy:
                            if (map.GameMap[i, j] is Swamp_Creature) stringBuilder.Append(SwampCreatureChar);
                            else
                                if (map.GameMap[i,j] is Mage) stringBuilder.Append(MageChar);
                           
                            stringBuilder.Append(Leaderchar);
                            break;
                        case Tile.Tiletype.EmptyTile:
                            stringBuilder.Append(EmptyChar);
                            break;
                        case Tile.Tiletype.Gold:
                            stringBuilder.Append(GoldChar);//3.1
                            break;
     


                        default:
                            break;
                    }
                    stringBuilder.Append(' ');
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
        
       
    }
}
