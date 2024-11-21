
namespace Cluedo
{
    partial class Cluedo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cluedo));
            this.ChecklistButton = new System.Windows.Forms.Button();
            this.RoomGuessBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WeaponGuessBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CharacterGuessBox = new System.Windows.Forms.ComboBox();
            this.SubmitBox = new System.Windows.Forms.Button();
            this.dice1Box = new System.Windows.Forms.PictureBox();
            this.dice2Box = new System.Windows.Forms.PictureBox();
            this.roundLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CharacterSelectionBox = new System.Windows.Forms.ComboBox();
            this.WeaponSelectionBox = new System.Windows.Forms.ComboBox();
            this.RoomPanel = new System.Windows.Forms.Panel();
            this.RoomSelectionLabel = new System.Windows.Forms.Label();
            this.MakeGuessButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dice1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2Box)).BeginInit();
            this.RoomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChecklistButton
            // 
            this.ChecklistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChecklistButton.Location = new System.Drawing.Point(1277, 769);
            this.ChecklistButton.Name = "ChecklistButton";
            this.ChecklistButton.Size = new System.Drawing.Size(95, 30);
            this.ChecklistButton.TabIndex = 0;
            this.ChecklistButton.Text = "Checklist";
            this.ChecklistButton.UseVisualStyleBackColor = true;
            this.ChecklistButton.Click += new System.EventHandler(this.ChecklistButton_Click);
            // 
            // RoomGuessBox
            // 
            this.RoomGuessBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoomGuessBox.FormattingEnabled = true;
            this.RoomGuessBox.Location = new System.Drawing.Point(462, 775);
            this.RoomGuessBox.Name = "RoomGuessBox";
            this.RoomGuessBox.Size = new System.Drawing.Size(137, 21);
            this.RoomGuessBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 778);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Room";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 778);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Weapon";
            // 
            // WeaponGuessBox
            // 
            this.WeaponGuessBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeaponGuessBox.FormattingEnabled = true;
            this.WeaponGuessBox.Location = new System.Drawing.Point(272, 775);
            this.WeaponGuessBox.Name = "WeaponGuessBox";
            this.WeaponGuessBox.Size = new System.Drawing.Size(137, 21);
            this.WeaponGuessBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 778);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Character";
            // 
            // CharacterGuessBox
            // 
            this.CharacterGuessBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharacterGuessBox.FormattingEnabled = true;
            this.CharacterGuessBox.Location = new System.Drawing.Point(69, 775);
            this.CharacterGuessBox.Name = "CharacterGuessBox";
            this.CharacterGuessBox.Size = new System.Drawing.Size(137, 21);
            this.CharacterGuessBox.TabIndex = 10;
            // 
            // SubmitBox
            // 
            this.SubmitBox.Location = new System.Drawing.Point(618, 769);
            this.SubmitBox.Name = "SubmitBox";
            this.SubmitBox.Size = new System.Drawing.Size(95, 30);
            this.SubmitBox.TabIndex = 3;
            this.SubmitBox.Text = "Submit guess";
            this.SubmitBox.UseVisualStyleBackColor = true;
            this.SubmitBox.Click += new System.EventHandler(this.SubmitBox_Click);
            // 
            // dice1Box
            // 
            this.dice1Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dice1Box.Location = new System.Drawing.Point(889, 351);
            this.dice1Box.Name = "dice1Box";
            this.dice1Box.Size = new System.Drawing.Size(90, 90);
            this.dice1Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice1Box.TabIndex = 12;
            this.dice1Box.TabStop = false;
            // 
            // dice2Box
            // 
            this.dice2Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dice2Box.Location = new System.Drawing.Point(991, 351);
            this.dice2Box.Name = "dice2Box";
            this.dice2Box.Size = new System.Drawing.Size(90, 90);
            this.dice2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dice2Box.TabIndex = 13;
            this.dice2Box.TabStop = false;
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.Location = new System.Drawing.Point(1088, 351);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(42, 13);
            this.roundLabel.TabIndex = 14;
            this.roundLabel.Text = "Round:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(886, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Character";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(886, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Weapon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(886, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Room";
            // 
            // CharacterSelectionBox
            // 
            this.CharacterSelectionBox.BackColor = System.Drawing.SystemColors.Window;
            this.CharacterSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharacterSelectionBox.FormattingEnabled = true;
            this.CharacterSelectionBox.Location = new System.Drawing.Point(945, 445);
            this.CharacterSelectionBox.Name = "CharacterSelectionBox";
            this.CharacterSelectionBox.Size = new System.Drawing.Size(136, 21);
            this.CharacterSelectionBox.TabIndex = 18;
            // 
            // WeaponSelectionBox
            // 
            this.WeaponSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeaponSelectionBox.FormattingEnabled = true;
            this.WeaponSelectionBox.Location = new System.Drawing.Point(945, 472);
            this.WeaponSelectionBox.Name = "WeaponSelectionBox";
            this.WeaponSelectionBox.Size = new System.Drawing.Size(136, 21);
            this.WeaponSelectionBox.TabIndex = 19;
            // 
            // RoomPanel
            // 
            this.RoomPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RoomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoomPanel.Controls.Add(this.RoomSelectionLabel);
            this.RoomPanel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RoomPanel.Location = new System.Drawing.Point(945, 499);
            this.RoomPanel.Name = "RoomPanel";
            this.RoomPanel.Size = new System.Drawing.Size(136, 21);
            this.RoomPanel.TabIndex = 20;
            // 
            // RoomSelectionLabel
            // 
            this.RoomSelectionLabel.AutoSize = true;
            this.RoomSelectionLabel.Location = new System.Drawing.Point(0, 2);
            this.RoomSelectionLabel.Name = "RoomSelectionLabel";
            this.RoomSelectionLabel.Size = new System.Drawing.Size(33, 13);
            this.RoomSelectionLabel.TabIndex = 21;
            this.RoomSelectionLabel.Text = "None";
            // 
            // MakeGuessButton
            // 
            this.MakeGuessButton.Location = new System.Drawing.Point(889, 526);
            this.MakeGuessButton.Name = "MakeGuessButton";
            this.MakeGuessButton.Size = new System.Drawing.Size(192, 21);
            this.MakeGuessButton.TabIndex = 21;
            this.MakeGuessButton.Text = "Make Guess";
            this.MakeGuessButton.UseVisualStyleBackColor = true;
            this.MakeGuessButton.Click += new System.EventHandler(this.MakeGuessButton_Click);
            // 
            // Cluedo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 811);
            this.Controls.Add(this.MakeGuessButton);
            this.Controls.Add(this.RoomPanel);
            this.Controls.Add(this.WeaponSelectionBox);
            this.Controls.Add(this.CharacterSelectionBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.dice2Box);
            this.Controls.Add(this.dice1Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CharacterGuessBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WeaponGuessBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoomGuessBox);
            this.Controls.Add(this.SubmitBox);
            this.Controls.Add(this.ChecklistButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1400, 850);
            this.MinimumSize = new System.Drawing.Size(1400, 850);
            this.Name = "Cluedo";
            this.Text = "Cluedo";
            ((System.ComponentModel.ISupportInitialize)(this.dice1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2Box)).EndInit();
            this.RoomPanel.ResumeLayout(false);
            this.RoomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChecklistButton;
        private System.Windows.Forms.ComboBox RoomGuessBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WeaponGuessBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CharacterGuessBox;
        private System.Windows.Forms.Button SubmitBox;
        private System.Windows.Forms.PictureBox dice1Box;
        private System.Windows.Forms.PictureBox dice2Box;
        private System.Windows.Forms.Label roundLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CharacterSelectionBox;
        private System.Windows.Forms.ComboBox WeaponSelectionBox;
        private System.Windows.Forms.Panel RoomPanel;
        private System.Windows.Forms.Label RoomSelectionLabel;
        private System.Windows.Forms.Button MakeGuessButton;
    }
}

