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
using System.Reflection;
using System.Threading;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;

namespace Cluedo
{
    public partial class Cluedo : Form
    {
        public string directory = "E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\";
        public Button[] buttonArray;
        public Board board = new Board();

        public Cluedo()
        {
            InitializeComponent();
            SetupBoard();
            SetupDice();
            board.SetupPlayerTiles();
            board.SaveGame();
            board.SetupGreyLabels();
            StartTurn();
        }

        private void SetupDice()
        {
            dice1Box.Image = Image.FromFile(directory + "Images\\Dice\\Dice0.jpg");
            dice2Box.Image = Image.FromFile(directory + "Images\\Dice\\Dice0.jpg");
        }

        private void ChecklistButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = directory + "AnswerSheet\\bin\\Debug\\AnswerSheet.exe";
            p.Start();
        }

        private void SetupBoard()
        {            
            SetupMap();
            SetupCards();
        }

        private void SetupMap()
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Location = new Point(12, 12);
            panel.Size = new Size(720, 750);
            Controls.Add(panel);

            MakeSquares(panel);
            MakeRooms(panel);
        }

        private void MakeRooms(Panel panel)
        {
            Image[] roomImages = GetRoomImages();
            string[] roomNames = GetRoomNames();

            Point[] blockLocations =          { new Point(-1, 179), new Point(-1, 178), new Point(239, 29), new Point(239, 29), new Point(419, 29), new Point(418, 29), new Point(539, 150), new Point(539, 148), new Point(689, 149), new Point(688, 148), new Point(509, 419), new Point(509, 419), new Point(509, 539), new Point(509, 538), new Point(689, 419), new Point(688, 419), new Point(689, 539), new Point(688, 538), new Point(509, 719), new Point(509, 718), new Point(179, 719), new Point(178, 718), new Point(149, 269), new Point(148, 269) };
            Size[] blockSizes =               { new Size(30, 30)  , new Size(31, 31)  , new Size(60, 30)  , new Size(61, 31)  , new Size(60, 30)  , new Size(61, 31)  , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(30, 30)   , new Size(31, 31)   , new Size(90, 30)   , new Size(91, 31) };
            for (int loop = 0; loop < 24; loop++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = blockLocations[loop];
                pictureBox.Size = blockSizes[loop];
                if (loop % 2 == 1)
                {
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                }
                panel.Controls.Add(pictureBox);
            }

            Point[] roomLocations = { new Point(-1, 29), new Point(239, 29), new Point(539, 29), new Point(539, 239), new Point(509, 419), new Point(509, 629), new Point(269, 539), new Point(-1, 569), new Point(-1, 269), new Point(299, 299) };
            Size[] roomSizes = { new Size(180, 180), new Size(240, 210), new Size(180, 150), new Size(180, 150), new Size(210, 150), new Size(210, 120), new Size(180, 210), new Size(210, 180), new Size(240, 210), new Size(150, 210) };
            Label[] roomLabels = new Label[9];
            for (int loop = 0; loop < 10; loop++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = roomImages[loop];
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Location = roomLocations[loop];
                pictureBox.Size = roomSizes[loop];
                panel.Controls.Add(pictureBox);                
                if (loop != 9)
                {
                    Label label = new Label();
                    label.Text = roomNames[loop];
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Location = new Point((pictureBox.Size.Width - 100) / 2 - 1, (pictureBox.Size.Height - 23) / 2 - 1);
                    label.MouseClick += new MouseEventHandler(LabelClicked);
                    pictureBox.Controls.Add(label);
                    roomLabels[loop] = label;
                }
                board.SetRoomLabels(roomLabels);                
            }
        }

        private Image[] GetRoomImages()
        {
            string preset = GetPreset();
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");

            string line;
            do
            {
                line = streamReader.ReadLine();
            }
            while (line != preset);
            streamReader.ReadLine();
            streamReader.ReadLine();

            string roomPack = streamReader.ReadLine();
            streamReader.Close();

            string directoryTemp = directory + "Images\\Rooms\\" + roomPack + "\\";
            Image[] imageList = new Image[10];
            for (int index = 0; index < 9; index++)
            {
                imageList[index] = Image.FromFile(directoryTemp + "Room" + (index + 1) + ".jpg");
            }
            imageList[9] = Image.FromFile(directory + "Images\\Rooms\\CluedoMiddleImage.jpg");

            return imageList;
        }

        private string[] GetRoomNames()
        {
            string preset = GetPreset();
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");

            string line;
            do
            {
                line = streamReader.ReadLine();
            }
            while (line != preset);
            for (int loop = 0; loop <5; loop++)
            {
                streamReader.ReadLine();
            }

            string[] nameList = streamReader.ReadLine().Split(',');
            streamReader.ReadLine();
            streamReader.Close();

            return nameList;
        }

        private void MakeSquares(Panel panel)
        {
            string[,] tileLayout = new string[25, 24]     {{null, null, null, null, null, null, null, null, null, "T" , null, null, null, null, "T" , null, null, null, null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, "T" , "T" , "T" , null, null, null, null, "T" , "T" , "T" , null, null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, "T" , "T" , "2" , null, null, null, null, null, null, "2" , "T" , "T" , "T" , null, "3" , null, null, null},
                                                           {null, null, null, null, "1" , null, "T" , "T" , null, null, null, null, null, null, null, null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" },
                                                           {"T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null, "2" , null, null, null, null, "2" , null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , null},
                                                           {null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "4" , null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, "T" , "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, "T" , "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, "9" , "T" , "T" , null, null, null, null, null, "T" , "T" , "T" , null, null, null, null, "4" , null},
                                                           {null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null},
                                                           {null, null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, "T" , "T" , "T" , null, null, "5" , null, null, null},
                                                           {null, null, null, null, null, null, "9" , null, "T" , "T" , null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null},
                                                           {null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null, null, null, null, null, "T" , "T" , "5" , null, null, null, null, null, null},
                                                           {"T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null, null, null, null, null, null, null},
                                                           {null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null, null, "7" , "7" , null, null, "T" , "T" , "T" , null, null, null, null, null, null},
                                                           {null, null, null, null, null, "8" , null, "T" , "T" , null, null, null, null, null, null, "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" },
                                                           {null, null, null, null, null, null, null, "T" , "T" , "7" , null, null, null, null, "7" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , "T" , null},
                                                           {null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, "T" , "T" , null, "6" , null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, "T" , "T" , null, null, null, null, null, null, null},
                                                           {null, null, null, null, null, null, null, "T" , null, null, null, null, null, null, null, null, "T" , null, null, null, null, null, null, null}};
            int buttonIndex = 0;
            for (int columnLoop = 0; columnLoop < 25; columnLoop++)
            {
                for (int rowLoop = 0; rowLoop < 24; rowLoop++)
                {
                    if (tileLayout[columnLoop, rowLoop] == "T")
                    {
                        Button button = new Button();
                        button.Size = new Size(30, 30);
                        button.Location = new Point((rowLoop * 30) - 1,(columnLoop * 30) - 1);
                        button.MouseClick += new MouseEventHandler(BoxClicked);
                        button.BackColor = Color.White;
                        panel.Controls.Add(button);
                        board.AddButtonToArray(button);
                        buttonIndex++;
                    }
                }
            }
            board.SetupWhiteTiles();
        }

        private void SetupCards()
        {
            MakePlayerCards();
            MakeLeftCards();
            MakeRightCards();

            int locationX = 745;
            for (int loop = 0; loop < 2; loop++)
            {
                Panel partition = new Panel();
                partition.Size = new Size(1, 1000);
                partition.Location = new Point(locationX, -10);
                partition.BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(partition);
                locationX = 877;
            }
        }

        private void MakePlayerCards()
        {
            Image[] cardImages = GetCardImages();
            string[] cardNames = GetCardNames();
            int[] playerCards = GetPlayerCards();

            int locationY = 12;
            for (int cardLoop = 0; cardLoop < playerCards.Length; cardLoop++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(108, 121);
                panel.Location = new Point(757, locationY);
                Controls.Add(panel);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = cardImages[playerCards[cardLoop]];
                pictureBox.Size = new Size(108, 108);
                pictureBox.Location = new Point(-1, -1);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);

                Label label = new Label();
                label.Text = cardNames[playerCards[cardLoop]];
                label.Location = new Point(0, 107);
                panel.Controls.Add(label);
                locationY = locationY + 133;
            }

            SetupGuesses(cardNames);
        }

        private void MakeLeftCards()
        {
            Image[] cardImages = GetCardImages();
            string[] cardNames = GetCardNames();
            string[] Order = GetOrder();

            int locationY = 12;
            for (int loop = 0; loop < 3; loop++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(240, 108);
                panel.Location = new Point(889, locationY);
                Controls.Add(panel);

                Label label = new Label();
                label.Text = cardNames[loop];
                label.Location = new Point(-1, -1);
                label.Size = new Size(132, 15);
                panel.Controls.Add(label);

                Label label2 = new Label();
                switch (Order[loop])
                {
                    case "Player":
                        label2.Text = "You";
                        break;
                    case "Easy":
                        label2.Text = "Easy AI";
                        break;
                    case "Medium":
                        label2.Text = "Medium AI";
                        break;
                    case "Hard":
                        label2.Text = "Hard AI";
                        break;
                    default:
                        label2.Text = "";
                        break;
                }
                label2.Location = new Point(-1, 13);
                panel.Controls.Add(label2);

                PictureBox pictureBox = new PictureBox();
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Image = cardImages[loop];
                pictureBox.Size = new Size(108, 108);
                pictureBox.Location = new Point(131, -1);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);

                locationY = locationY + 110;
            }
        }

        private void MakeRightCards()
        {
            Image[] cardImages = GetCardImages();
            string[] cardNames = GetCardNames();
            string[] Order = GetOrder();

            int locationY = 12;
            for (int loop = 0; loop < 3; loop++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(240, 108);
                panel.Location = new Point(1131, locationY);
                Controls.Add(panel);

                Label label = new Label();
                label.Text = cardNames[loop + 3];
                label.Location = new Point(107, -1);
                label.Size = new Size(132, 15);
                panel.Controls.Add(label);

                Label label2 = new Label();
                switch (Order[loop + 3])
                {
                    case "Player":
                        label2.Text = "You";
                        break;
                    case "Easy":
                        label2.Text = "Easy AI";
                        break;
                    case "Medium":
                        label2.Text = "Medium AI";
                        break;
                    case "Hard":
                        label2.Text = "Hard AI";
                        break;
                    default:
                        label2.Text = "";
                        break;
                }
                label2.Location = new Point(107, 13);
                panel.Controls.Add(label2);

                PictureBox pictureBox = new PictureBox();
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Image = cardImages[loop + 3];
                pictureBox.Size = new Size(108, 108);
                pictureBox.Location = new Point(-1, -1);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);

                locationY = locationY + 110;
            }
        }

        private int[] GetPlayerCards()
        {
            StreamReader streamReader = new StreamReader(directory + "Save Game.txt");
            for (int loop = 0; loop < 4; loop++)
            {
                streamReader.ReadLine();
            }
            string[] players = streamReader.ReadLine().Split(',');
            streamReader.ReadLine();
            int index = 0;
            for (int loop = 0; loop < 6; loop++)
            {
                if (players[loop] == "Player")
                {
                    index = loop;
                }
            }
            for (int loop = 0; loop < index; loop++)
            {
                streamReader.ReadLine();
            }

            string[] playerCards = streamReader.ReadLine().Split(',');
            streamReader.Close();

            int[] playerCardsConverted = ConvertCardToNumber(playerCards);

            return playerCardsConverted;
        }

        private Image[] GetCardImages()
        {
            string preset = GetPreset();
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");

            string line;
            do
            {
                line = streamReader.ReadLine();                
            }
            while (line != preset);
            string charactersPack = streamReader.ReadLine();
            string weaponsPack = streamReader.ReadLine();
            string roomsPack = streamReader.ReadLine();
            streamReader.Close();

            Image[] characterImages = new Image[6];
            Image[] weaponImages = new Image[6];
            Image[] roomImages = new Image[9];
            Image[] images = new Image[21];

            string imagesDirectory = directory + "Images\\";
            string characterDirectory = imagesDirectory + "Characters\\" + charactersPack + "\\Character";
            string weaponDirectory = imagesDirectory + "Weapons\\" + weaponsPack + "\\Weapon";
            string roomDirectory = imagesDirectory + "Rooms\\" + roomsPack + "\\Room";

            for (int charactersLoop = 0; charactersLoop < 6; charactersLoop++)
            {
                characterImages[charactersLoop] = Image.FromFile(characterDirectory + (charactersLoop + 1) + ".jpg");
            }

            for (int weaponLoop = 0; weaponLoop < 6; weaponLoop++)
            {
                weaponImages[weaponLoop] = Image.FromFile(weaponDirectory + (weaponLoop + 1) + ".jpg");
            }

            for (int roomLoop = 0; roomLoop < 9; roomLoop++)
            {
                roomImages[roomLoop] = Image.FromFile(roomDirectory + (roomLoop + 1) + ".jpg");
            }

            images = characterImages.Concat(weaponImages).Concat(roomImages).ToArray();

            return images;
        }

        private string[] GetCardNames()
        {
            string preset = GetPreset();
            StreamReader streamReader = new StreamReader(directory + "Cards.txt");

            string line;
            do
            {
                line = streamReader.ReadLine();
            }
            while (line != preset);
            streamReader.ReadLine();
            streamReader.ReadLine();
            streamReader.ReadLine();

            string[] characterNames = streamReader.ReadLine().Split(',');
            string[] weaponNames = streamReader.ReadLine().Split(',');
            string[] roomNames = streamReader.ReadLine().Split(',');
            string[] names = characterNames.Concat(weaponNames).Concat(roomNames).ToArray();
            streamReader.Close();

            return names;
        }

        private void SetupGuesses(string[] cardNames)
        {
            CharacterGuessBox.Items.Add("");
            for (int index = 0; index < 6; index++)
            {                
                CharacterGuessBox.Items.Add(cardNames[index]);
            }
            WeaponGuessBox.Items.Add("");
            for (int index = 0; index < 6; index++)
            {                
                WeaponGuessBox.Items.Add(cardNames[index + 6]);
            }
            RoomGuessBox.Items.Add("");
            for (int index = 0; index < 9; index++)
            {                
                RoomGuessBox.Items.Add(cardNames[index + 12]);
            }
            CharacterSelectionBox.Items.Add("");
            for (int index = 0; index < 6; index++)
            {
                CharacterSelectionBox.Items.Add(cardNames[index]);
            }
            WeaponSelectionBox.Items.Add("");
            for (int index = 0; index < 6; index++)
            {
                WeaponSelectionBox.Items.Add(cardNames[index + 6]);
            }
        }

        private string GetPreset()
        {
            StreamReader streamReader = new StreamReader(directory + "Save Game.txt");
            string preset = streamReader.ReadLine();
            streamReader.Close();
            return preset;
        }

        private string[] GetOrder()
        {
            StreamReader streamReader = new StreamReader(directory + "Save Game.txt");
            for (int loop = 0; loop < 3; loop++)
            {
                streamReader.ReadLine();
            }
            string[] order = streamReader.ReadLine().Split(',');
            streamReader.Close();
            return order;
        }

        private int[] ConvertCardToNumber(string[] toConvert)
        {
            int[] converted = new int[toConvert.Length];
            for (int loop = 0; loop < toConvert.Length; loop++)
            {
                switch (toConvert[loop])
                {
                    case "A":
                        converted[loop] = 0;
                        break;
                    case "B":
                        converted[loop] = 1;
                        break;
                    case "C":
                        converted[loop] = 2;
                        break;
                    case "D":
                        converted[loop] = 3;
                        break;
                    case "E":
                        converted[loop] = 4;
                        break;
                    case "F":
                        converted[loop] = 5;
                        break;
                    case "a":
                        converted[loop] = 6;
                        break;
                    case "b":
                        converted[loop] = 7;
                        break;
                    case "c":
                        converted[loop] = 8;
                        break;
                    case "d":
                        converted[loop] = 9;
                        break;
                    case "e":
                        converted[loop] = 10;
                        break;
                    case "f":
                        converted[loop] = 11;
                        break;
                    case "1":
                        converted[loop] = 12;
                        break;
                    case "2":
                        converted[loop] = 13;
                        break;
                    case "3":
                        converted[loop] = 14;
                        break;
                    case "4":
                        converted[loop] = 15;
                        break;
                    case "5":
                        converted[loop] = 16;
                        break;
                    case "6":
                        converted[loop] = 17;
                        break;
                    case "7":
                        converted[loop] = 18;
                        break;
                    case "8":
                        converted[loop] = 19;
                        break;
                    case "9":
                        converted[loop] = 20;
                        break;
                }                
            }
            return converted;
        }

        private void SubmitBox_Click(object sender, EventArgs e)
        {
            if(CharacterGuessBox.Text == "" || WeaponGuessBox.Text == "" || RoomGuessBox.Text == "")
            {
                MessageBox.Show("Invalid Guess");
            }
            else
            {
                MessageBox.Show("Valid Guess");
            }
        }

        private void BoxClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.BackColor == Color.Black)
            {
                RoomSelectionLabel.Text = "None";
                board.MoveTiles(button);
                board.IncrementTurn();
                board.SaveGame();
                StartTurn();
            }
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            int roomNumber = board.GetRoomFromLabel(label);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(20, 20);

            if (roomNumber == 1)
            {
                pictureBox.Location = new Point(59,59);
                RoomSelectionLabel.Text = "1";
            }
            else if (roomNumber == 2)
            {
                pictureBox.Location = new Point(329,59);
                RoomSelectionLabel.Text = "2";
            }
            else if (roomNumber == 3)
            {
                pictureBox.Location = new Point(599,54);
                RoomSelectionLabel.Text = "3";
            }
            else if (roomNumber == 4)
            {
                pictureBox.Location = new Point(599,264);
                RoomSelectionLabel.Text = "4";
            }
            else if (roomNumber == 5)
            {
                pictureBox.Location = new Point(584, 444);
                RoomSelectionLabel.Text = "5";
            }
            else if (roomNumber == 6)
            {
                pictureBox.Location = new Point(584, 654);
                RoomSelectionLabel.Text = "6";
            }
            else if (roomNumber == 7)
            {
                pictureBox.Location = new Point(329, 569);
                RoomSelectionLabel.Text = "7";
            }
            else if (roomNumber == 8)
            {
                pictureBox.Location = new Point(74, 599);
                RoomSelectionLabel.Text = "8";
            }
            else if (roomNumber == 9)
            {
                pictureBox.Location = new Point(89, 314);
                RoomSelectionLabel.Text = "9";
            }

            int player = board.GetTurn();
            if (player == 0)
            {
                pictureBox.BackColor = Color.Green;
            }
            else if (player == 1)
            {
                pictureBox.BackColor = Color.Yellow;
                pictureBox.Location = new Point(pictureBox.Location.X + 20, pictureBox.Location.Y);
            }
            else if (player == 2)
            {
                pictureBox.BackColor = Color.Blue;
                pictureBox.Location = new Point(pictureBox.Location.X + 40, pictureBox.Location.Y);
            }
            else if (player == 3)
            {
                pictureBox.BackColor = Color.Purple;
                pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 20);
            }
            else if (player == 4)
            {
                pictureBox.BackColor = Color.Red;
                pictureBox.Location = new Point(pictureBox.Location.X + 20, pictureBox.Location.Y + 20);
            }
            else if (player == 5)
            {
                pictureBox.BackColor = Color.Gray;
                pictureBox.Location = new Point(pictureBox.Location.X + 40, pictureBox.Location.Y + 20);
            }

            Controls.Add(pictureBox);
            board.SetRoomLabel(pictureBox);
            pictureBox.BringToFront();

            board.MoveTilesRoom(label, roomNumber);
            board.IncrementTurn();
            board.SaveGame();
            StartTurn();
        }

        private int RollDice()
        {
            Random randomDice = new Random();
            int diceRoll1 = randomDice.Next(0, 6);
            int diceRoll2 = randomDice.Next(0, 6);
            dice1Box.Image = Image.FromFile(directory + "Images\\Dice\\Dice" + (diceRoll1 + 1).ToString() + ".jpg");
            dice2Box.Image = Image.FromFile(directory + "Images\\Dice\\Dice" + (diceRoll2 + 1).ToString() + ".jpg");
            return diceRoll1 + diceRoll2 + 2;
        }

        private void StartTurn()
        {
            roundLabel.Text = "Round: " + board.GetRound().ToString() + "\nTurn: " + board.GetColour();
            string turn = board.GetPlayerTurn();
            if(turn == "Player")
            {
                int diceTotal = RollDice();
                board.ShowMoves(diceTotal);
            }
            else if (turn == "Easy" || turn == "Medium" || turn == "Hard")
            {
                int diceTotal = RollDice();
                board.ShowMoves(diceTotal);
                AITurn(diceTotal);
            }
            else if (turn == "N")
            {
                board.IncrementTurn();
                board.SaveGame();
                StartTurn();                
            }
        }

        private void AITurn(int diceTotal)
        {
            Thread.Sleep(100);
            board.AITurn();
            board.IncrementTurn();
            board.SaveGame();
            StartTurn();
        }

        private void MakeGuessButton_Click(object sender, EventArgs e)
        {
            string playerTurn = board.GetPlayerTurn();
            if (playerTurn == "Player")
            {
                string problem = "";
                if (CharacterSelectionBox.Text == "")
                {
                    problem = "Invalid character guess\n";
                }
                if (WeaponSelectionBox.Text == "")
                {
                    problem = string.Concat(problem, "Invalid weapon guess\n");
                }
                if (RoomSelectionLabel.Text == "None")
                {
                    problem = string.Concat(problem, "Invalid room guess\n");
                }
                if (problem != "")
                {
                    MessageBox.Show(problem);
                }
                else
                {
                    string[] weapons = new string[6] { "a", "b", "c", "d", "e", "f"};
                    string[] characters = new string[6] { "A", "B", "C", "D", "E", "F" };
                    string weaponGuess = weapons[WeaponSelectionBox.SelectedIndex - 1];
                    string characterGuess = characters[CharacterSelectionBox.SelectedIndex - 1];
                    string roomGuess = RoomSelectionLabel.Text;
                    int turn = board.GetTurn();
                    for (int loop1 = 0; loop1 < 5; loop1++)
                    {
                        turn++;
                        if (turn == 6)
                        {
                            turn = 0;
                        }
                        string[] cards = board.GetCards(turn);
                        if (cards[0] != "N")
                        {
                            for (int loop2 = 0; loop2 < cards.Length; loop2++)
                            {
                                if (cards[loop2] == weaponGuess || cards[loop2] == characterGuess || cards[loop2] == roomGuess)
                                {
                                    MessageBox.Show(cards[loop2]);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You can only make a guess on your turn");
            }
        }
    }
}
