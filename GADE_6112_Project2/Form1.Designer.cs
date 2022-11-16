namespace GADE_6112_Project2
{
    partial class gameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.redMap = new System.Windows.Forms.RichTextBox();
            this.playerStats = new System.Windows.Forms.RichTextBox();
            this.enemyStats = new System.Windows.Forms.RichTextBox();
            this.cmbEnemy = new System.Windows.Forms.ComboBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNoMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(712, 391);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(94, 29);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(712, 301);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(94, 29);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(712, 346);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(94, 29);
            this.btnAttack.TabIndex = 2;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(600, 346);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(94, 29);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(816, 346);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(94, 29);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // redMap
            // 
            this.redMap.Location = new System.Drawing.Point(12, 12);
            this.redMap.Name = "redMap";
            this.redMap.Size = new System.Drawing.Size(451, 431);
            this.redMap.TabIndex = 5;
            this.redMap.Text = "\n";
            // 
            // playerStats
            // 
            this.playerStats.Location = new System.Drawing.Point(473, 12);
            this.playerStats.Name = "playerStats";
            this.playerStats.Size = new System.Drawing.Size(172, 182);
            this.playerStats.TabIndex = 6;
            this.playerStats.Text = "";
            // 
            // enemyStats
            // 
            this.enemyStats.Location = new System.Drawing.Point(667, 12);
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.Size = new System.Drawing.Size(172, 182);
            this.enemyStats.TabIndex = 7;
            this.enemyStats.Text = "";
            // 
            // cmbEnemy
            // 
            this.cmbEnemy.FormattingEnabled = true;
            this.cmbEnemy.Location = new System.Drawing.Point(896, 12);
            this.cmbEnemy.Name = "cmbEnemy";
            this.cmbEnemy.Size = new System.Drawing.Size(151, 28);
            this.cmbEnemy.TabIndex = 8;
            this.cmbEnemy.SelectedIndexChanged += new System.EventHandler(this.cmbEnemy_SelectedIndexChanged);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(894, 414);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(94, 29);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(994, 414);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNoMove
            // 
            this.btnNoMove.Location = new System.Drawing.Point(953, 241);
            this.btnNoMove.Name = "btnNoMove";
            this.btnNoMove.Size = new System.Drawing.Size(94, 29);
            this.btnNoMove.TabIndex = 11;
            this.btnNoMove.Text = "NoMove";
            this.btnNoMove.UseVisualStyleBackColor = true;
            this.btnNoMove.Click += new System.EventHandler(this.btnNoMove_Click);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 455);
            this.Controls.Add(this.btnNoMove);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cmbEnemy);
            this.Controls.Add(this.enemyStats);
            this.Controls.Add(this.playerStats);
            this.Controls.Add(this.redMap);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Name = "gameForm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.gameForm_Activated);
            this.Load += new System.EventHandler(this.gameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDown;
        private Button btnUp;
        private Button btnAttack;
        private Button btnLeft;
        private Button btnRight;
        private RichTextBox redMap;
        private RichTextBox playerStats;
        private RichTextBox enemyStats;
        private ComboBox cmbEnemy;
        private Button btnsave;
        private Button btnLoad;
        private Button btnNoMove;
    }
}