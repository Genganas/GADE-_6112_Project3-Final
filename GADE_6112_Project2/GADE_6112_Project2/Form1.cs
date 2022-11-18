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
            gameEngine.Save();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            gameEngine.Load();
            UpdateMap();
            DispPlayerStats();
            UpdateEnemyComboBox();
            UpdateShop();

        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (cmbEnemy.SelectedIndex == -1) return;
            if (gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].isDead()) return; ;//Checking if the enemy is dead before attacking
            bool success = gameEngine.Map.HeroPlayer.CheckRange(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex]);
            gameEngine.Map.HeroPlayer.Attack(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex]);
            if (success) UpdateSelectedEnemyStats();
            else cmbEnemy.Text = "Attack Unsucessful";
            //checking if the enemy is dead after attacking
            if (gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].isDead())
            {
                gameEngine.Map.HeroPlayer.Loot(gameEngine.Map.Enemies[cmbWeapon.SelectedIndex]); //looting

                //setting the tile to be Empty
                gameEngine.Map.GameMap[gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].Y, gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].X]
                    = new EmptyTile(gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].X, gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].Y);

                //Updating the Drop down
                cmbEnemy.Items[cmbEnemy.SelectedIndex] = "Enemy Dead";
            }
            else
            {
                //updating the Drop down
                cmbEnemy.Items[cmbEnemy.SelectedIndex] = gameEngine.Map.Enemies[cmbEnemy.SelectedIndex].ToString();
            }

            DispPlayerStats();
            UpdateMap();
            UpdateVision();
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
            UpdateVision();
            gameEngine.MoveEnemy();
            UpdateVision();
            gameEngine.EnemyAttack();
            UpdateVision();

            DispPlayerStats();
            UpdateEnemyComboBox();
            UpdateMap();
        }

       
        private void UpdateShop()
        {
            cmbWeapon.Text = "";
            cmbWeapon.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                cmbWeapon.Text += "`" + gameEngine.GameShop.DisplayWeapon(i);
                cmbWeapon.Text += Environment.NewLine;

                cmbWeapon.Items.Add(gameEngine.GameShop.DisplayWeapon(i));
            }
        }
        private void gameForm_Activated(object sender, EventArgs e)
        {
            
        }

        private void gameForm_Load(object sender, EventArgs e)
        {
     
            DispPlayerStats();
            UpdateEnemyComboBox();
            UpdateVision();
            UpdateMap();
            UpdateShop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameEngine.GameShop.Buy(cmbWeapon.SelectedIndex);

            UpdateShop();
            UpdateMap();
            DispPlayerStats();
        }
    }
}