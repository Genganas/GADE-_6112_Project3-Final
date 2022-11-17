using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6112_Project2
{
    internal class Map
    {
        private Tile[,] map;
        private Hero hero;   //A Hero object to represent the player character
        private Enemy[] enemies;   //An Enemy array for the enemies
        private Item?[] items;////3.1 Items array
        private int mapHeight, mapWidth;   //Variables for storing the map’s width and height
        private Random rnd = new Random();   // A Random object for randomising numbers.

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount, int goldCount)
        {
            enemies = new Enemy[enemyCount];
            items = new Item[goldCount];
            mapWidth = rnd.Next(minWidth, maxWidth);
            mapHeight = rnd.Next(minHeight, maxHeight);
            map = new Tile[mapWidth, mapHeight];

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {

                    if ((i == 0 || i == mapWidth - 1) || (j == 0 || j == mapHeight - 1))
                    {
                        map[i, j] = new Obstacle(i, j) { Type = Tile.Tiletype.Obstacle };
                    }
                    else
                    {
                        map[i, j] = new EmptyTile(i, j) { Type = Tile.Tiletype.EmptyTile };
                    }

                }
            }
            hero = (Hero)Create(Tile.Tiletype.Hero);
            hero.Hp = 99;
            hero.MaxHp = 99;
          ///3.1 amount

            for (int j = 0; j < enemyCount; j++)
            {
                Create(Tile.Tiletype.Enemy);
            }
            for (int j = 0; j <goldCount; j++) ////3.1 
            {
                Create(Tile.Tiletype.Gold);
            }
            UpdateVision();
        
        }
        public int MapWidth { get => mapWidth; }
        public int MapHeight { get => mapHeight; }
        public Tile[,] GameMap { get { return map; } set { GameMap = value; } }
        public Hero HeroPlayer { get { return hero; } set { hero = value; } }
        public Enemy[] Enemies { get { return enemies; } set { enemies = value; } }
        public Item[] Items { get { return items; } set { items = value; } } //3.1
       
       
        // Updates the vision for each player
        public void UpdateVision()
        {
            //Hero 
            Tile[] vision = new Tile[4];
            vision[0] = map[hero.Y-1, hero.X]; //up
            vision[1] = map[hero.Y+1,hero.X ]; //down
            vision[2] = map[hero.Y, hero.X-1]; //left
            vision[3] = map[hero.Y, hero.X+1]; //right
            hero.CharacterMoves = vision;


            //Enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                Tile[] enemyVision = new Tile[4];
                enemyVision[0] = map[enemies[i].Y + 1,enemies[i].X ]; //up
                enemyVision[1] = map[enemies[i].Y - 1,enemies[i].X ]; //down
                enemyVision[2] = map[enemies[i].Y, enemies[i].X-1]; //left
                enemyVision[3] = map[enemies[i].Y, enemies[i].X+1]; //right
                enemies[i].CharacterMoves = enemyVision;

            }
        }
        public Item? GetItemAtPosition(int y, int x)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is null) continue;

                if (items[i].X == x && items[i].Y == y)
                {
                    Item item = items[i];
                    items[i] = null;
                    return item;
                }
            }
            return null;
        }

        private Tile Create(Tile.Tiletype type)
        {
            bool loop;
            int rndmX, rndmY;
            int randWeapon = 0;
            int randEnemy = 0;

            for (int i = 0; i < 1; i++)
            {
                randWeapon = rnd.Next(0, 4);
            }
            for (int i = 0; i < 1; i++)
            {
                randEnemy = rnd.Next(0, 2);
            }
            do
            {
                rndmX = rnd.Next(2, mapWidth - 2);
                rndmY = rnd.Next(2, mapHeight - 2);

                if (map[rndmY, rndmX] == null)
                {
                    loop = false;
                }
                else
                {
                    loop = (map[rndmY, rndmX].Type != Tile.Tiletype.EmptyTile);
                }
            } while (loop);
           
            switch (type)
            {
                case Tile.Tiletype.Hero:
                    Hero tmp = new Hero(rndmX, rndmY, 99, 99);
                    map[rndmX, rndmY] = tmp;
                    map[rndmY, rndmX].Type = Tile.Tiletype.Hero;
                    return tmp;
                case Tile.Tiletype.Enemy:
                    if (randEnemy == 0)
                    {
                        Swamp_Creature swampCreature = new Swamp_Creature(rndmX, rndmY);
                        map[rndmY, rndmX] = swampCreature;
                        map[rndmY, rndmX].Type = Tile.Tiletype.Enemy;
                        AddEnemy(swampCreature);
                        return swampCreature;
                    }
                    else
                    if (randEnemy == 1)
                    {
                        Mage mage = new Mage(rndmX, rndmY);
                        map[rndmY, rndmX] = mage;
                        map[rndmY, rndmX].Type = Tile.Tiletype.Enemy;
                        AddEnemy(mage);
                        return mage;
                    }
                    else
                    {
                        Leader leader = new Leader(rndmX, rndmY);
                        map[rndmY, rndmX] = leader;
                        map[rndmY, rndmX].Type = Tile.Tiletype.Enemy;
                        AddEnemy(leader);
                        return leader;
                    }
                case Tile.Tiletype.Gold:
                    Gold gold = new Gold(rndmX, rndmY);
                    map[rndmX, rndmY] = gold;
                    AddItem(gold);
                    map[rndmY, rndmX].Type = Tile.Tiletype.Gold;
                    return gold;
                case Tile.Tiletype.Weapon:
                    if (randWeapon == 0)
                    {
                        Weapon dagger = new MeleeWeapon(rndmX,rndmY, MeleeWeapon.Types.Dagger);
                        map[rndmX, rndmY] = dagger;
                        AddItem(dagger);
                        map[rndmY, rndmX].Type = Tile.Tiletype.Weapon;
                        return dagger;
                    }
                    else
                    if (randWeapon == 1)
                    {
                        Weapon longsword = new MeleeWeapon( rndmX,rndmY, MeleeWeapon.Types.LongSword);
                        map[rndmX, rndmY] = longsword;
                        AddItem(longsword);
                        map[rndmY, rndmX].Type = Tile.Tiletype.Weapon;
                        return longsword;
                    }
                    else
                    if (randWeapon == 2)
                    {
                        Weapon rifle = new RangedWeapon(rndmX, rndmY, RangedWeapon.Types.Rifle);
                        map[rndmX, rndmY] = rifle;
                        AddItem(rifle);
                        map[rndmY, rndmX].Type = Tile.Tiletype.Weapon;
                        return rifle;
                    }
                    else
                        if (randWeapon == 3)
                    {
                        Weapon longbow = new RangedWeapon(rndmX, rndmY, RangedWeapon.Types.Longbow);
                        map[rndmX, rndmY] = longbow;
                        AddItem(longbow);
                        map[rndmY, rndmX].Type = Tile.Tiletype.Weapon;
                        return longbow;
                    }
                    else
                        return null;
                  
                
                default:
                    EmptyTile empty = new EmptyTile(rndmX, rndmY);
                    map[rndmY, rndmX] = empty;
                    map[rndmY, rndmX].Type = Tile.Tiletype.EmptyTile;
                    return empty;
            }
        }

        private void AddEnemy(Enemy enemy)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null)
                {
                    enemies[i] = enemy;
                    break;
                }
            }
        }
    
        private void AddItem(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    break;
                }
            }
        }
    }
}
