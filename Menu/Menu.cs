using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Menu
{
    public partial class Menu : Form
    {
        public string directory = "E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\";

        public Menu()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StartGamePanel.Visible = true;
            SetupNewGameMenu();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(directory + "Save Game.txt"))
            {
                Process p = new Process();
                Process.Start(directory + "Cluedo\\bin\\debug\\Cluedo.exe");
                Close();
            }
            else
            {
                MessageBox.Show("Game not found\n\nSelect 'New Game' to start one");
            }
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBoxes = new ComboBox[] { comboBoxP1, comboBoxP2, comboBoxP3, comboBoxP4, comboBoxP5, comboBoxP6 };

            bool playerInGame = false;
            for (int playerCheck = 0; playerCheck < 6; playerCheck++)
            {
                if (comboBoxes[playerCheck].SelectedItem == "Player")
                {
                    playerInGame = true;
                }
            }

            int playerCount = 0;
            for (int playerCountCheck = 0; playerCountCheck < 6; playerCountCheck++)
            {
                if (comboBoxes[playerCountCheck].SelectedItem != null)
                {
                    playerCount++;
                }
            }

            if (ThemeComboBox.SelectedItem != null && playerCount >= 3 && playerInGame == true)
            {
                StreamWriter streamWriter = new StreamWriter(directory + "Save Game.txt");
                streamWriter.WriteLine(ThemeComboBox.SelectedItem);
                streamWriter.WriteLine("1\n0");

                for (int order = 0; order < 6; order++)
                {
                    if (comboBoxes[order].SelectedItem != null)
                    {
                        streamWriter.Write(comboBoxes[order].SelectedItem);
                    }
                    else
                    {
                        streamWriter.Write("N");
                    }
                    if (order != 5)
                    {
                        streamWriter.Write(",");
                    }
                }
                streamWriter.WriteLine();

                for (int order = 0; order < 6; order++)
                {
                    if (comboBoxes[order].SelectedItem != null)
                    {
                        streamWriter.Write(FinalGuessesBox.Value);
                    }
                    else
                    {
                        streamWriter.Write("N");
                    }
                    if (order != 5)
                    {
                        streamWriter.Write(",");
                    }
                }
                streamWriter.WriteLine();

                List<char> cards = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                Random random = new Random();
                int randomNumber;

                int[] rand1 = new int[] { 0, 5, 10 };
                int[] rand2 = new int[] { 6, 11, 19 };
                for (int middleCards = 0; middleCards < 3; middleCards++)
                {
                    randomNumber = random.Next(rand1[middleCards], rand2[middleCards]);
                    streamWriter.Write(cards[randomNumber]);
                    if (middleCards != 2)
                    {
                        streamWriter.Write(",");
                    }
                    cards.RemoveAt(randomNumber);
                }
                streamWriter.WriteLine();

                int extraCardCheck;
                for (int playerCards = 0; playerCards < 6; playerCards++)
                {
                    if(comboBoxes[playerCards].SelectedItem != null)
                    {
                        extraCardCheck = (18 % playerCount) - playerCards;
                        for (int cardAmount = 0; cardAmount < 18 / playerCount; cardAmount++)
                        {
                            randomNumber = random.Next(0, cards.Count);
                            streamWriter.Write(cards[randomNumber]);
                            cards.RemoveAt(randomNumber);
                            if (extraCardCheck > 0 || cardAmount < (18 / playerCount) - 1)
                            {
                                streamWriter.Write(",");
                            }
                        }
                        if (extraCardCheck > 0)
                        {
                            randomNumber = random.Next(cards.Count);
                            streamWriter.Write(cards[randomNumber]);
                            cards.RemoveAt(randomNumber);
                        }
                        streamWriter.WriteLine();
                    }
                    else
                    {
                        streamWriter.WriteLine("N");
                    }
                }

                streamWriter.WriteLine("35,34,125,163,186,187");

                if (MovePlayersBox.Checked == true)
                {
                    streamWriter.WriteLine("True");
                }
                else
                {
                    streamWriter.WriteLine("False");
                }

                streamWriter.WriteLine(TimeLimitBox.Value);
                streamWriter.Close();

                Process.Start(directory + "Cluedo\\bin\\debug\\Cluedo.exe");
                Close();
            }
        }

        private void SetupNewGameMenu()
        {
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");
            string name = streamReader.ReadLine();
            while (name != null)
            {
                ThemeComboBox.Items.Add(name);
                for (int skipData = 0; skipData < 7; skipData++)
                {
                    streamReader.ReadLine();
                }
                name = streamReader.ReadLine();
            }
            streamReader.Close();

            Color[] colours = new Color[] { Color.Green, Color.Yellow, Color.Blue, Color.Purple, Color.Red, Color.LightGray };
            Label[] label = new Label[] { labelP1, labelP2, labelP3, labelP4, labelP5, labelP6 };
            for (int loop = 0; loop < 6; loop++)
            {
                label[loop].BackColor = colours[loop];
                label[loop].ForeColor = Color.White;
            }
            label[1].ForeColor = Color.Black;
            label[5].ForeColor = Color.Black;

            comboBoxP1.SelectedItem = null;
            comboBoxP2.SelectedItem = null;
            comboBoxP3.SelectedItem = null;
            comboBoxP4.SelectedItem = null;
            comboBoxP5.SelectedItem = null;
            comboBoxP6.SelectedItem = null;
        }

        private void ComboBoxP1_Changed(object sender, EventArgs e)
        {
            if (comboBoxP1.Text == "Player")
            {
                if (comboBoxP2.Text == "Player")
                {
                    comboBoxP2.Text = null;
                }
                else if (comboBoxP3.Text == "Player")
                {
                    comboBoxP3.Text = null;
                }
                else if (comboBoxP4.Text == "Player")
                {
                    comboBoxP4.Text = null;
                }
                else if (comboBoxP5.Text == "Player")
                {
                    comboBoxP5.Text = null;
                }
                else if (comboBoxP6.Text == "Player")
                {
                    comboBoxP6.Text = null;
                }
            }
        }

        private void ComboBoxP2_Changed(object sender, EventArgs e)
        {
            if (comboBoxP2.Text == "Player")
            {
                if (comboBoxP1.Text == "Player")
                {
                    comboBoxP1.Text = null;
                }
                else if (comboBoxP3.Text == "Player")
                {
                    comboBoxP3.Text = null;
                }
                else if (comboBoxP4.Text == "Player")
                {
                    comboBoxP4.Text = null;
                }
                else if (comboBoxP5.Text == "Player")
                {
                    comboBoxP5.Text = null;
                }
                else if (comboBoxP6.Text == "Player")
                {
                    comboBoxP6.Text = null;
                }
            }
        }

        private void ComboBoxP3_Changed(object sender, EventArgs e)
        {
            if (comboBoxP3.Text == "Player")
            {
                if (comboBoxP1.Text == "Player")
                {
                    comboBoxP1.Text = null;
                }
                else if (comboBoxP2.Text == "Player")
                {
                    comboBoxP2.Text = null;
                }
                else if (comboBoxP4.Text == "Player")
                {
                    comboBoxP4.Text = null;
                }
                else if (comboBoxP5.Text == "Player")
                {
                    comboBoxP5.Text = null;
                }
                else if (comboBoxP6.Text == "Player")
                {
                    comboBoxP6.Text = null;
                }
            }
        }

        private void ComboBoxP4_Changed(object sender, EventArgs e)
        {
            if (comboBoxP4.Text == "Player")
            {
                if (comboBoxP1.Text == "Player")
                {
                    comboBoxP1.Text = null;
                }
                else if (comboBoxP2.Text == "Player")
                {
                    comboBoxP2.Text = null;
                }
                else if (comboBoxP3.Text == "Player")
                {
                    comboBoxP3.Text = null;
                }
                else if (comboBoxP5.Text == "Player")
                {
                    comboBoxP5.Text = null;
                }
                else if (comboBoxP6.Text == "Player")
                {
                    comboBoxP6.Text = null;
                }
            }
        }

        private void ComboBoxP5_Changed(object sender, EventArgs e)
        {
            if (comboBoxP5.Text == "Player")
            {
                if (comboBoxP1.Text == "Player")
                {
                    comboBoxP1.Text = null;
                }
                else if (comboBoxP2.Text == "Player")
                {
                    comboBoxP2.Text = null;
                }
                else if (comboBoxP3.Text == "Player")
                {
                    comboBoxP3.Text = null;
                }
                else if (comboBoxP4.Text == "Player")
                {
                    comboBoxP4.Text = null;
                }
                else if (comboBoxP6.Text == "Player")
                {
                    comboBoxP6.Text = null;
                }
            }
        }

        private void ComboBoxP6_Changed(object sender, EventArgs e)
        {
            if (comboBoxP6.Text == "Player")
            {
                if (comboBoxP1.Text == "Player")
                {
                    comboBoxP1.Text = null;
                }
                else if (comboBoxP2.Text == "Player")
                {
                    comboBoxP2.Text = null;
                }
                else if (comboBoxP3.Text == "Player")
                {
                    comboBoxP3.Text = null;
                }
                else if (comboBoxP4.Text == "Player")
                {
                    comboBoxP4.Text = null;
                }
                else if (comboBoxP5.Text == "Player")
                {
                    comboBoxP5.Text = null;
                }
            }
        }

        private void ThemeComboBox_Changed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");
            string line;
            do
            {
                line = streamReader.ReadLine();
            }
            while (line != comboBox.Text);
            for (int loop = 0; loop < 3; loop++)
            {
                streamReader.ReadLine();
            }
            string[] names = streamReader.ReadLine().Split(',');

            Label[] label = new Label[] { labelP1, labelP2, labelP3, labelP4, labelP5, labelP6 };
            for (int index = 0; index < 6; index++)
            {
                label[index].Text = names[index];
            }
        }

        private void TimeLimitLabel_MouseHover(object sender, EventArgs e)
        {
            toolTipTimeLimit.Show("Determines how long a player has to play their turn before a random play is made.\n'0' for no timer.", TimeLimitLabel);
        }

        private void FinalGuessesLabel_MouseHover(object sender, EventArgs e)
        {
            toolTipFinalGuesses.Show("Determines how many final guesses a player has before they are removed from a game.", FinalGuessesLabel);
        }

        private void MovePlayersLabel_MouseHover(object sender, EventArgs e)
        {
            toolTipMovePlayers.Show("Determines whether a guess will move the questioned player to the questioned room.",MovePlayersLabel);
        }

        private void ThemeLabel_MouseHover(object sender, EventArgs e)
        {
            toolTipTheme.Show("Determines the theme for the characters, weapons and rooms.",ThemeLabel);
        }
    }
}
