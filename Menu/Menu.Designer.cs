
namespace Menu
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.CluedoLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.ExitGameButton = new System.Windows.Forms.Button();
            this.StartGamePanel = new System.Windows.Forms.Panel();
            this.MovePlayersBox = new System.Windows.Forms.CheckBox();
            this.FinalGuessesBox = new System.Windows.Forms.NumericUpDown();
            this.TimeLimitBox = new System.Windows.Forms.NumericUpDown();
            this.MovePlayersLabel = new System.Windows.Forms.Label();
            this.FinalGuessesLabel = new System.Windows.Forms.Label();
            this.TimeLimitLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxP6 = new System.Windows.Forms.ComboBox();
            this.labelP6 = new System.Windows.Forms.Label();
            this.comboBoxP5 = new System.Windows.Forms.ComboBox();
            this.labelP5 = new System.Windows.Forms.Label();
            this.comboBoxP4 = new System.Windows.Forms.ComboBox();
            this.labelP4 = new System.Windows.Forms.Label();
            this.comboBoxP3 = new System.Windows.Forms.ComboBox();
            this.labelP3 = new System.Windows.Forms.Label();
            this.comboBoxP2 = new System.Windows.Forms.ComboBox();
            this.labelP2 = new System.Windows.Forms.Label();
            this.comboBoxP1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelP1 = new System.Windows.Forms.Label();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.ThemeLabel = new System.Windows.Forms.Label();
            this.ConfirmStartGame = new System.Windows.Forms.Button();
            this.toolTipTimeLimit = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipFinalGuesses = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipMovePlayers = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipTheme = new System.Windows.Forms.ToolTip(this.components);
            this.StartGamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinalGuessesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CluedoLabel
            // 
            this.CluedoLabel.AutoSize = true;
            this.CluedoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CluedoLabel.Location = new System.Drawing.Point(13, 13);
            this.CluedoLabel.Name = "CluedoLabel";
            this.CluedoLabel.Size = new System.Drawing.Size(100, 31);
            this.CluedoLabel.TabIndex = 0;
            this.CluedoLabel.Text = "Cluedo";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(19, 58);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(75, 23);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(19, 87);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(75, 23);
            this.LoadGameButton.TabIndex = 2;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // ExitGameButton
            // 
            this.ExitGameButton.Location = new System.Drawing.Point(797, 426);
            this.ExitGameButton.Name = "ExitGameButton";
            this.ExitGameButton.Size = new System.Drawing.Size(75, 23);
            this.ExitGameButton.TabIndex = 3;
            this.ExitGameButton.Text = "Exit";
            this.ExitGameButton.UseVisualStyleBackColor = true;
            this.ExitGameButton.Click += new System.EventHandler(this.ExitGameButton_Click);
            // 
            // StartGamePanel
            // 
            this.StartGamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.StartGamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartGamePanel.Controls.Add(this.MovePlayersBox);
            this.StartGamePanel.Controls.Add(this.FinalGuessesBox);
            this.StartGamePanel.Controls.Add(this.TimeLimitBox);
            this.StartGamePanel.Controls.Add(this.MovePlayersLabel);
            this.StartGamePanel.Controls.Add(this.FinalGuessesLabel);
            this.StartGamePanel.Controls.Add(this.TimeLimitLabel);
            this.StartGamePanel.Controls.Add(this.panel2);
            this.StartGamePanel.Controls.Add(this.comboBoxP6);
            this.StartGamePanel.Controls.Add(this.labelP6);
            this.StartGamePanel.Controls.Add(this.comboBoxP5);
            this.StartGamePanel.Controls.Add(this.labelP5);
            this.StartGamePanel.Controls.Add(this.comboBoxP4);
            this.StartGamePanel.Controls.Add(this.labelP4);
            this.StartGamePanel.Controls.Add(this.comboBoxP3);
            this.StartGamePanel.Controls.Add(this.labelP3);
            this.StartGamePanel.Controls.Add(this.comboBoxP2);
            this.StartGamePanel.Controls.Add(this.labelP2);
            this.StartGamePanel.Controls.Add(this.comboBoxP1);
            this.StartGamePanel.Controls.Add(this.panel1);
            this.StartGamePanel.Controls.Add(this.labelP1);
            this.StartGamePanel.Controls.Add(this.ThemeComboBox);
            this.StartGamePanel.Controls.Add(this.ThemeLabel);
            this.StartGamePanel.Controls.Add(this.ConfirmStartGame);
            this.StartGamePanel.Location = new System.Drawing.Point(167, 41);
            this.StartGamePanel.Name = "StartGamePanel";
            this.StartGamePanel.Size = new System.Drawing.Size(566, 342);
            this.StartGamePanel.TabIndex = 4;
            this.StartGamePanel.Visible = false;
            // 
            // MovePlayersBox
            // 
            this.MovePlayersBox.AutoSize = true;
            this.MovePlayersBox.Location = new System.Drawing.Point(375, 60);
            this.MovePlayersBox.Name = "MovePlayersBox";
            this.MovePlayersBox.Size = new System.Drawing.Size(15, 14);
            this.MovePlayersBox.TabIndex = 22;
            this.MovePlayersBox.UseVisualStyleBackColor = true;
            // 
            // FinalGuessesBox
            // 
            this.FinalGuessesBox.Location = new System.Drawing.Point(375, 33);
            this.FinalGuessesBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FinalGuessesBox.Name = "FinalGuessesBox";
            this.FinalGuessesBox.Size = new System.Drawing.Size(120, 20);
            this.FinalGuessesBox.TabIndex = 21;
            this.FinalGuessesBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TimeLimitBox
            // 
            this.TimeLimitBox.Location = new System.Drawing.Point(375, 8);
            this.TimeLimitBox.Name = "TimeLimitBox";
            this.TimeLimitBox.Size = new System.Drawing.Size(120, 20);
            this.TimeLimitBox.TabIndex = 20;
            // 
            // MovePlayersLabel
            // 
            this.MovePlayersLabel.AutoSize = true;
            this.MovePlayersLabel.Location = new System.Drawing.Point(285, 60);
            this.MovePlayersLabel.Name = "MovePlayersLabel";
            this.MovePlayersLabel.Size = new System.Drawing.Size(71, 13);
            this.MovePlayersLabel.TabIndex = 19;
            this.MovePlayersLabel.Text = "Move Players";
            this.MovePlayersLabel.MouseHover += new System.EventHandler(this.MovePlayersLabel_MouseHover);
            // 
            // FinalGuessesLabel
            // 
            this.FinalGuessesLabel.AutoSize = true;
            this.FinalGuessesLabel.Location = new System.Drawing.Point(285, 35);
            this.FinalGuessesLabel.Name = "FinalGuessesLabel";
            this.FinalGuessesLabel.Size = new System.Drawing.Size(73, 13);
            this.FinalGuessesLabel.TabIndex = 18;
            this.FinalGuessesLabel.Text = "Final Guesses";
            this.FinalGuessesLabel.MouseHover += new System.EventHandler(this.FinalGuessesLabel_MouseHover);
            // 
            // TimeLimitLabel
            // 
            this.TimeLimitLabel.AutoSize = true;
            this.TimeLimitLabel.Location = new System.Drawing.Point(285, 10);
            this.TimeLimitLabel.Name = "TimeLimitLabel";
            this.TimeLimitLabel.Size = new System.Drawing.Size(54, 13);
            this.TimeLimitLabel.TabIndex = 17;
            this.TimeLimitLabel.Text = "Time Limit";
            this.TimeLimitLabel.MouseHover += new System.EventHandler(this.TimeLimitLabel_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(283, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 270);
            this.panel2.TabIndex = 16;
            // 
            // comboBoxP6
            // 
            this.comboBoxP6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP6.FormattingEnabled = true;
            this.comboBoxP6.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP6.Location = new System.Drawing.Point(128, 168);
            this.comboBoxP6.Name = "comboBoxP6";
            this.comboBoxP6.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP6.TabIndex = 15;
            this.comboBoxP6.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP6_Changed);
            // 
            // labelP6
            // 
            this.labelP6.AutoSize = true;
            this.labelP6.Location = new System.Drawing.Point(11, 171);
            this.labelP6.Name = "labelP6";
            this.labelP6.Size = new System.Drawing.Size(45, 13);
            this.labelP6.TabIndex = 14;
            this.labelP6.Text = "Player 6";
            // 
            // comboBoxP5
            // 
            this.comboBoxP5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP5.FormattingEnabled = true;
            this.comboBoxP5.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP5.Location = new System.Drawing.Point(128, 143);
            this.comboBoxP5.Name = "comboBoxP5";
            this.comboBoxP5.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP5.TabIndex = 13;
            this.comboBoxP5.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP5_Changed);
            // 
            // labelP5
            // 
            this.labelP5.AutoSize = true;
            this.labelP5.Location = new System.Drawing.Point(11, 146);
            this.labelP5.Name = "labelP5";
            this.labelP5.Size = new System.Drawing.Size(45, 13);
            this.labelP5.TabIndex = 12;
            this.labelP5.Text = "Player 5";
            // 
            // comboBoxP4
            // 
            this.comboBoxP4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP4.FormattingEnabled = true;
            this.comboBoxP4.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP4.Location = new System.Drawing.Point(128, 118);
            this.comboBoxP4.Name = "comboBoxP4";
            this.comboBoxP4.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP4.TabIndex = 11;
            this.comboBoxP4.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP4_Changed);
            // 
            // labelP4
            // 
            this.labelP4.AutoSize = true;
            this.labelP4.Location = new System.Drawing.Point(10, 121);
            this.labelP4.Name = "labelP4";
            this.labelP4.Size = new System.Drawing.Size(45, 13);
            this.labelP4.TabIndex = 10;
            this.labelP4.Text = "Player 4";
            // 
            // comboBoxP3
            // 
            this.comboBoxP3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP3.FormattingEnabled = true;
            this.comboBoxP3.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP3.Location = new System.Drawing.Point(128, 93);
            this.comboBoxP3.Name = "comboBoxP3";
            this.comboBoxP3.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP3.TabIndex = 9;
            this.comboBoxP3.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP3_Changed);
            // 
            // labelP3
            // 
            this.labelP3.AutoSize = true;
            this.labelP3.Location = new System.Drawing.Point(10, 96);
            this.labelP3.Name = "labelP3";
            this.labelP3.Size = new System.Drawing.Size(45, 13);
            this.labelP3.TabIndex = 8;
            this.labelP3.Text = "Player 3";
            // 
            // comboBoxP2
            // 
            this.comboBoxP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP2.FormattingEnabled = true;
            this.comboBoxP2.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP2.Location = new System.Drawing.Point(128, 68);
            this.comboBoxP2.Name = "comboBoxP2";
            this.comboBoxP2.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP2.TabIndex = 7;
            this.comboBoxP2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP2_Changed);
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.Location = new System.Drawing.Point(10, 71);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(45, 13);
            this.labelP2.TabIndex = 6;
            this.labelP2.Text = "Player 2";
            // 
            // comboBoxP1
            // 
            this.comboBoxP1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP1.FormattingEnabled = true;
            this.comboBoxP1.Items.AddRange(new object[] {
            "Player",
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxP1.Location = new System.Drawing.Point(128, 43);
            this.comboBoxP1.Name = "comboBoxP1";
            this.comboBoxP1.Size = new System.Drawing.Size(151, 21);
            this.comboBoxP1.TabIndex = 5;
            this.comboBoxP1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxP1_Changed);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 1);
            this.panel1.TabIndex = 4;
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.Location = new System.Drawing.Point(10, 46);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(45, 13);
            this.labelP1.TabIndex = 3;
            this.labelP1.Text = "Player 1";
            // 
            // ThemeComboBox
            // 
            this.ThemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ThemeComboBox.FormattingEnabled = true;
            this.ThemeComboBox.Location = new System.Drawing.Point(56, 7);
            this.ThemeComboBox.Name = "ThemeComboBox";
            this.ThemeComboBox.Size = new System.Drawing.Size(223, 21);
            this.ThemeComboBox.TabIndex = 2;
            this.ThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.ThemeComboBox_Changed);
            // 
            // ThemeLabel
            // 
            this.ThemeLabel.AutoSize = true;
            this.ThemeLabel.Location = new System.Drawing.Point(10, 10);
            this.ThemeLabel.Name = "ThemeLabel";
            this.ThemeLabel.Size = new System.Drawing.Size(40, 13);
            this.ThemeLabel.TabIndex = 1;
            this.ThemeLabel.Text = "Theme";
            this.ThemeLabel.MouseHover += new System.EventHandler(this.ThemeLabel_MouseHover);
            // 
            // ConfirmStartGame
            // 
            this.ConfirmStartGame.Location = new System.Drawing.Point(246, 300);
            this.ConfirmStartGame.Name = "ConfirmStartGame";
            this.ConfirmStartGame.Size = new System.Drawing.Size(76, 23);
            this.ConfirmStartGame.TabIndex = 0;
            this.ConfirmStartGame.Text = "Start Game";
            this.ConfirmStartGame.UseVisualStyleBackColor = true;
            this.ConfirmStartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.StartGamePanel);
            this.Controls.Add(this.ExitGameButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.CluedoLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Menu";
            this.Text = "Menu";
            this.StartGamePanel.ResumeLayout(false);
            this.StartGamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinalGuessesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CluedoLabel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button ExitGameButton;
        private System.Windows.Forms.Panel StartGamePanel;
        private System.Windows.Forms.Button ConfirmStartGame;
        private System.Windows.Forms.Label ThemeLabel;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.ComboBox comboBoxP6;
        private System.Windows.Forms.Label labelP6;
        private System.Windows.Forms.ComboBox comboBoxP5;
        private System.Windows.Forms.Label labelP5;
        private System.Windows.Forms.ComboBox comboBoxP4;
        private System.Windows.Forms.Label labelP4;
        private System.Windows.Forms.ComboBox comboBoxP3;
        private System.Windows.Forms.Label labelP3;
        private System.Windows.Forms.ComboBox comboBoxP2;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.ComboBox comboBoxP1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox MovePlayersBox;
        private System.Windows.Forms.NumericUpDown FinalGuessesBox;
        private System.Windows.Forms.NumericUpDown TimeLimitBox;
        private System.Windows.Forms.Label MovePlayersLabel;
        private System.Windows.Forms.Label FinalGuessesLabel;
        private System.Windows.Forms.Label TimeLimitLabel;
        private System.Windows.Forms.ToolTip toolTipTimeLimit;
        private System.Windows.Forms.ToolTip toolTipFinalGuesses;
        private System.Windows.Forms.ToolTip toolTipMovePlayers;
        private System.Windows.Forms.ToolTip toolTipTheme;
    }
}

