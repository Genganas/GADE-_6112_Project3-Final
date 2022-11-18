using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            map = new Map(15, 20, 15, 20, 5, 5,5);
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
                        if (item is not null)
                        {
                            map.HeroPlayer.Pickup(item);
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = map.GetItemAtPosition(map.HeroPlayer.Y + 1, map.HeroPlayer.X);
                        if (item2 is not null)
                        {
                            map.HeroPlayer.Pickup(item2);
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = map.GetItemAtPosition(map.HeroPlayer.Y, map.HeroPlayer.X - 1);
                        if (item3 is not null)
                        {
                            map.HeroPlayer.Pickup(item3);
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = map.GetItemAtPosition(map.HeroPlayer.Y, map.HeroPlayer.X + 1);
                        if (item4 is not null)
                        {
                            map.HeroPlayer.Pickup(item4);
                        }
                        break;
                        //Moves the player in the requested direction
                        
                }
                map.HeroPlayer.Move(direction);
                map.GameMap[map.HeroPlayer.Y, map.HeroPlayer.X] = map.HeroPlayer;
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
                map.UpdateVision();
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
                        if (item is not null)
                        {
                            map.Enemies[i].Pickup(item);
                        }
                        break;
                    case Character.Movement.Down:
                        Item? item2 = map.GetItemAtPosition(map.Enemies[i].Y + 1, map.Enemies[i].X);
                        if (item2 is not null)
                        {
                            map.Enemies[i].Pickup(item2);
                        }
                        break;
                    case Character.Movement.Left:
                        Item? item3 = map.GetItemAtPosition(map.Enemies[i].Y, map.Enemies[i].X - 1);
                        if (item3 is not null)
                        {
                            map.Enemies[i].Pickup(item3);
                        }
                        break;
                    case Character.Movement.Right:
                        Item? item4 = map.GetItemAtPosition(map.Enemies[i].Y, map.Enemies[i].X + 1);
                        if (item4 is not null)
                        {
                            map.Enemies[i].Pickup(item4);
                        }
                        break;
                }
                //Moves the enemies in the requested direction
                map.Enemies[i].Move(direction);
                map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = map.Enemies[i];


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
                    case Mage:
                        //attacking player
                        map.Enemies[i].Attack(map.HeroPlayer);
                        //attacking other enemies
                        for (int j = 0; j < map.Enemies.Length; j++)
                        {
                            //prevents mages from killing themselves, but not other mages
                            if (map.Enemies[i] == map.Enemies[j]) continue;
                            //attacking the enemy 
                            map.Enemies[i].Attack(map.Enemies[j]);

                            if (map.Enemies[j].isDead())
                            {
                                //loot the character they killed if they're in range.
                                if (map.Enemies[i].CheckRange(map.Enemies[j])) map.Enemies[i].Loot(map.Enemies[j]);

                                //ensures that the tile of a dead enemy that a player moves into doesn't get overwritten by a blank tile.
                                if (!(map.HeroPlayer.X == map.Enemies[j].X || map.HeroPlayer.Y == map.Enemies[j].Y)) map.GameMap[map.Enemies[j].Y, map.Enemies[j].X] = new EmptyTile(map.Enemies[j].X, map.Enemies[j].Y);
                            }
                        }
                        break;
                    default:
                        map.Enemies[i].Attack(map.HeroPlayer);
                        break;
                }
            
                if (map.Enemies[i].isDead())
                {
                    map.GameMap[map.Enemies[i].Y, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y) { Type = Tile.Tiletype.EmptyTile };
                }
            }
        }
        public void Save()
        {
            //saving all the data into XML tables
            DataSet dataSet = new DataSet();
            DataTable mapCreationTable = new DataTable();
            DataTable charactersTable = new DataTable();
            DataTable goldTable = new DataTable();
            DataTable weaponsTable = new DataTable();

            //map creation table
            dataSet.Tables.Add(mapCreationTable);
            mapCreationTable.Columns.Add(new DataColumn("Width", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("Height", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("EnemyCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("WeaponCount", typeof(int)));

            //characters table
            dataSet.Tables.Add(charactersTable);
            charactersTable.Columns.Add(new DataColumn("CharacterType", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("HP", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("GoldAmount", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Weapon", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("WeaponDurability", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("IsDead", typeof(bool)));


            //gold table
            dataSet.Tables.Add(goldTable);
            goldTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));

            //weapons table for in map weapons
            dataSet.Tables.Add(weaponsTable);
            weaponsTable.Columns.Add(new DataColumn("Type", typeof(string)));
            weaponsTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("durability", typeof(int)));


            //writing data into tables
            //map creation table
            mapCreationTable.Rows.Add(map.MapWidth, map.MapHeight, map.Enemies.Length, 4, 2);

            //characters table
            if (map.HeroPlayer.WeaponUsed is not null) charactersTable.Rows.Add("Hero", map.HeroPlayer.X, map.HeroPlayer.Y, map.HeroPlayer.Hp, map.HeroPlayer.GoldAmount, map.HeroPlayer.WeaponUsed.getWeaponType, map.HeroPlayer.WeaponUsed.Durability, map.HeroPlayer.isDead());
            else charactersTable.Rows.Add("Hero", map.HeroPlayer.X, map.HeroPlayer.Y, map.HeroPlayer.Hp, map.HeroPlayer.GoldAmount, "BareHands", -1, map.HeroPlayer.isDead());

            for (int i = 0; i < map.Enemies.Length; i++)
            {
                switch (map.Enemies[i])
                {
                    case Swamp_Creature:
                        charactersTable.Rows.Add("SwampCreature", map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp, map.Enemies[i].GoldAmount, map.Enemies[i].WeaponUsed.getWeaponType, map.Enemies[i].WeaponUsed.Durability, map.Enemies[i].isDead());
                        break;
                    case Mage:
                        charactersTable.Rows.Add("Mage", map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp, map.Enemies[i].GoldAmount, "BareHands", -1, map.Enemies[i].isDead());
                        break;
                    case Leader:
                        charactersTable.Rows.Add("Leader", map.Enemies[i].X, map.Enemies[i].Y, map.Enemies[i].Hp, map.Enemies[i].GoldAmount, map.Enemies[i].WeaponUsed.getWeaponType, map.Enemies[i].WeaponUsed.Durability, map.Enemies[i].isDead());
                        break;
                    default:
                        break;
                }
            }

            //gold and weapons table
            for (int i = 0; i < map.Items.Length; i++)
            {
                switch (map.Items[i])
                {
                    case Gold gold:
                        goldTable.Rows.Add(gold.X, gold.Y, gold.GoldAmount);
                        break;
                    case MeleeWeapon melee:
                        weaponsTable.Rows.Add(melee.getWeaponType, melee.X, melee.Y, melee.Durability);
                        break;
                    case RangedWeapon ranged:
                        weaponsTable.Rows.Add(ranged.getWeaponType, ranged.X, ranged.Y, ranged.Durability);
                        break;
                }
            }

            dataSet.WriteXml("Tables.xml");
        }
        public void Load()
        {
            DataSet loadingData = new DataSet();
            loadingData.ReadXml("Tables.xml");

            //Map Creation
            int width_MC, height_MC, enemies_MC, gold_MC, weapons_MC;
            width_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Width"]);
            height_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Height"]);
            enemies_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["EnemyCount"]);
            gold_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["GoldCount"]);
            weapons_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["WeaponCount"]);

            map = new Map(width_MC, width_MC, height_MC, height_MC, enemies_MC, gold_MC, weapons_MC);

            //emptying the map of its auto-generated content
            for (int i = 1; i < height_MC - 1; i++)
            {
                for (int j = 1; j < width_MC - 1; j++)
                {
                    map.GameMap[i, j] = new EmptyTile(j, i);
                }
            }
            map.Enemies = new Enemy[enemies_MC];
            map.Items = new Item[gold_MC + weapons_MC];

            //Characters
            foreach (DataRow row in loadingData.Tables[1].Rows) //Characters Table
            {
                string type_CH;
                int x_CH, y_CH, hp_CH, goldPurse_CH;
                string weapon_CH;
                int weaponDura_CH;
                bool dead_CH;

                type_CH = (string)row["CharacterType"];
                x_CH = Convert.ToInt32(row["Xposition"]);
                y_CH = Convert.ToInt32(row["Yposition"]);
                hp_CH = Convert.ToInt32(row["HP"]);
                goldPurse_CH = Convert.ToInt32(row["GoldAmount"]);
                weapon_CH = (string)row["Weapon"];
                weaponDura_CH = Convert.ToInt32(row["WeaponDurability"]);
                dead_CH = Convert.ToBoolean(row["IsDead"]);
                Weapon? w = weapon_CH switch
                {
                    "Rifle" => new RangedWeapon(RangedWeapon.Types.Rifle, weaponDura_CH),
                    "Longbow" => new RangedWeapon(RangedWeapon.Types.Longbow, weaponDura_CH),
                    "Dagger" => new MeleeWeapon(MeleeWeapon.Types.Dagger, weaponDura_CH),
                    "Longsword" => new MeleeWeapon(MeleeWeapon.Types.LongSword, weaponDura_CH),
                    _ => null
                };

                switch (type_CH)
                {
                    case "Hero":
                        Hero hero = new Hero(x_CH, y_CH, hp_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) hero.Pickup(w);
                        map.HeroPlayer = hero;
                        map.GameMap[y_CH, x_CH] = hero;
                        break;
                    case "SwampCreature":
                        Swamp_Creature sc = new Swamp_Creature(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) sc.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = sc;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.GameMap[y_CH, x_CH] = sc;
                        }
                        break;
                    case "Mage":
                        Mage mage = new Mage(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH };
                        if (w is not null) mage.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = mage;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.GameMap[y_CH, x_CH] = mage;
                        }
                        break;
                    case "Leader":
                        Leader leader = new Leader(x_CH, y_CH, hp_CH) { GoldAmount = goldPurse_CH, Target = map.HeroPlayer };
                        if (w is not null) leader.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = leader;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.GameMap[y_CH, x_CH] = leader;
                        }
                        break;

                }
            }

            //gold
            foreach (DataRow row in loadingData.Tables[2].Rows) //gold table
            {
                int x_GO, y_GO, gold_GO;

                x_GO = Convert.ToInt32(row["Xposition"]);
                y_GO = Convert.ToInt32(row["Yposition"]);
                gold_GO = Convert.ToInt32(row["GoldCount"]);


                Gold gold = new Gold(x_GO, y_GO) { GoldAmount = gold_GO };
                for (int i = 0; i < map.Items.Length; i++)
                {
                    if (map.Items[i] is null)
                    {
                        map.Items[i] = gold;
                        break;
                    }
                }
                map.GameMap[y_GO, x_GO] = gold;
            }

            //weapons on gameMap
            foreach (DataRow row in loadingData.Tables[3].Rows) //weapons table
            {
                string type;
                int x_W, y_W, durability_W;

                type = (string)row["Type"];
                x_W = Convert.ToInt32(row["Xposition"]);
                y_W = Convert.ToInt32(row["Yposition"]);
                durability_W = Convert.ToInt32(row["durability"]);

                if (x_W == 0 || y_W == 0)
                {
                    continue;
                }
                switch (type)
                {
                    case "Rifle":
                        RangedWeapon rifle = new RangedWeapon(RangedWeapon.Types.Rifle, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = rifle;
                                break;
                            }
                        }
                        map.GameMap[y_W, x_W] = rifle;
                        break;
                    case "LongBow":
                        RangedWeapon longbow = new RangedWeapon(RangedWeapon.Types.Longbow, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = longbow;
                                break;
                            }
                        }
                        map.GameMap[y_W, x_W] = longbow;
                        break;
                    case "Dagger":
                        MeleeWeapon dagger = new MeleeWeapon(MeleeWeapon.Types.Dagger, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = dagger;
                                break;
                            }
                        }
                        map.GameMap[y_W, x_W] = dagger;
                        break;
                    case "Longsword":
                        MeleeWeapon longsword = new MeleeWeapon(MeleeWeapon.Types.LongSword, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = longsword;
                                break;
                            }
                        }
                        map.GameMap[y_W, x_W] = longsword;
                        break;
                }
            }
            map.UpdateVision();
        }
        public override string ToString() // Symbols generator for the map
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < map.GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < map.GameMap.GetLength(1); j++)
                {
                    switch (map.GameMap[i, j])
                    {
                        case Hero:
                            stringBuilder.Append(HeroChar);
                            break;
                        case Obstacle:
                            stringBuilder.Append(ObstacleChar);
                            break;
                        case Swamp_Creature:
                            stringBuilder.Append(SwampCreatureChar);
                            break;
                        case Mage:
                            stringBuilder.Append(MageChar);
                            break;
                        case RangedWeapon ranwep:
                            if (ranwep.getWeaponType == "Rifle")
                            {
                                stringBuilder.Append(RifleChar);
                            }
                            else
                                stringBuilder.Append(BowChar);
                            break;
                            case MeleeWeapon melee:
                            if (melee.getWeaponType == "Dagger")
                            {
                                stringBuilder.Append(DaggerChar);
                            }
                            else
                                stringBuilder.Append(LongSwordChar);
                            break;
                        case Leader:
                            stringBuilder.Append(Leaderchar);
                            break;
                        case EmptyTile:
                            stringBuilder.Append(EmptyChar);
                            break;
                        case Gold:
                            stringBuilder.Append(GoldChar);//3.1
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
