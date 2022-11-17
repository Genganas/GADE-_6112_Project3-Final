using System.Data;

namespace GADE_6112_Project2
{
    public partial class gameForm : Form
    {
        private GameEngine gameEngine;
        public gameForm()
        {
            InitializeComponent();
            gameEngine = new GameEngine();
            UpdateMap();
            DispPlayerStats();
            UpdateEnemyComboBox();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            DataSet? dataSet = new DataSet();
            DataTable? dataTable = new DataTable();

            //saving
            dataSet.Tables.Add(dataTable);
            dataTable.Columns.Add(new DataColumn("ObjectType", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Xpos", typeof(int)));
            dataTable.Columns.Add(new DataColumn("YPos", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Hp", typeof(int)));
            dataTable.Columns.Add(new DataColumn("MaxHp", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Gold", typeof(int)));

            //adding the hero to the data table
            dataTable.Rows.Add("Hero", gameEngine.Map.HeroPlayer.X, gameEngine.Map.HeroPlayer.Y, gameEngine.Map.HeroPlayer.Hp, gameEngine.Map.HeroPlayer.MaxHp, gameEngine.Map.HeroPlayer.GoldAmount);

            for (int i = 0; i < gameEngine.Map.Enemies.Length; i++)
            {
                switch (gameEngine.Map.Enemies[i])
                {
                    case Mage:
                        dataTable.Rows.Add("Mage", gameEngine.Map.Enemies[i].X, gameEngine.Map.Enemies[i].Y, gameEngine.Map.Enemies[i].Hp, gameEngine.Map.Enemies[i].MaxHp, gameEngine.Map.Enemies[i].GoldAmount);
                        break;
                    case Swamp_Creature:
                        dataTable.Rows.Add("Swamp Creature", gameEngine.Map.Enemies[i].X, gameEngine.Map.Enemies[i].Y, gameEngine.Map.Enemies[i].Hp, gameEngine.Map.Enemies[i].MaxHp, gameEngine.Map.Enemies[i].GoldAmount);
                        break;
                }
            }
            for (int i = 0; i < gameEngine.Map.Items.Length; i++)
            {
                switch (gameEngine.Map.Items[i])
                {
                    case Gold:
                        dataTable.Rows.Add("Gold", gameEngine.Map.Items[i].X, gameEngine.Map.Items[i].Y, -1, -1, ((Gold)gameEngine.Map.Items[i]).GoldAmount);
                        break;
                }
            }

            dataSet.WriteXml("SavedData.xml");
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            gameEngine.Load();
            
        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (cmbEnemy.SelectedIndex == -1) return;
            if (CheckDead()) return; ;//Checking if the enemy is dead before attacking
            bool success = gameEngine.Map.HeroPlayer.CheckRange(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex]);
            gameEngine.Map.HeroPlayer.Attack(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex]);
            if (success) UpdateSelectedEnemyStats();
            else cmbEnemy.Text = "Attack Unsucessful";
            CheckDead(); //checking if the enemy is dead after attacking

         

            gameEngine.EnemyAttack();
        }
        
        private void cmbEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedEnemyStats();
        }
        private void UpdateEnemyComboBox() //Tells if enemy is dead
        {
            cmbEnemy.Items.Clear();
            for (int i = 0; i < gameEngine.Map.Enemies.Length; i++)
            {
                if (gameEngine.Map.Enemies[i].isDead()) cmbEnemy.Items.Add("Enemy dead.");
                else cmbEnemy.Items.Add(gameEngine.Map.Enemies[i].ToString());
            }
        }

        private void DispPlayerStats() // Player stats
        {
            playerStats.Text = gameEngine.Map.HeroPlayer.ToString();
        }

        private void UpdateMap() // Update tile map
        {
            redMap.Text = gameEngine.ToString();
        }

        private void UpdateVision() // Update hero or enemy vision
        {
            gameEngine.Map.UpdateVision();
        }
       

        private void UpdateSelectedEnemyStats() // if enemy is dead is tells us
        {
            if (gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].isDead())
            {
                enemyStats.Text = "Enemy is already dead.";
            }
            else enemyStats.Text = gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].ToString();

        }
       

        private void btnRight_Click(object sender, EventArgs e)
        {

            DirectionHandler(Character.Movement.Right);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.Movement.Left);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.Movement.Down);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.Movement.Up);
        }
        private void btnNoMove_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.Movement.NoMovement);
        }
        private void DirectionHandler(Character.Movement movement)
        {
            gameEngine.MovePlayer(movement);
            gameEngine.MoveEnemy();
            gameEngine.EnemyAttack();
            DispPlayerStats();

            UpdateEnemyComboBox();
            UpdateVision();

           
            UpdateMap();
        }

        private bool CheckDead()
        {
            if (gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].isDead())
            {
                enemyStats.Text = "Enemy Dead";
                gameEngine.Map.GameMap[gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].Y,
                               gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].X]
                    = new EmptyTile(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].X, gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].Y)
                    {
                        Type = Tile.Tiletype.EmptyTile
                    };
                UpdateMap();
                DispPlayerStats();
                UpdateEnemyComboBox();
                return true;
            }
            return false;
        }

        private void gameForm_Activated(object sender, EventArgs e)
        {
            
        }

        private void gameForm_Load(object sender, EventArgs e)
        {
            // Message will appear in the beginning of the program to explain what the player must do in order to play the game
            string message = "Please before pressing any other buttons, press the save button and the load button in order to play a new game. If you want to play a previous game,please press the load button before playing. ";
            string title = "Welcome";
            MessageBox.Show(message, title);
        }
    }
}