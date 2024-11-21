using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnswerSheet
{
    public partial class AnswerSheet : Form
    {
        Image white = Image.FromFile("E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\Images\\AnswerSheet\\White.png");
        Image cross = Image.FromFile("E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\Images\\AnswerSheet\\Cross.png");
        Image check = Image.FromFile("E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\Images\\AnswerSheet\\Check.png");

        public AnswerSheet()
        {            
            InitializeComponent();
        }

        private void AnswerSheet_Load(object sender, EventArgs e)
        {
            SetupNames();
            SetupBoxes();
        }

        private void SetupNames()
        {
            string directory = "D:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo";

            StreamReader streamReaderBase = new StreamReader(directory + "\\Save Game.txt");
            string cardPreset = streamReaderBase.ReadLine();
            streamReaderBase.Close();

            StreamReader streamReader = new StreamReader(directory + "\\Cards.txt");
            string presetCheck;
            do
            {
                presetCheck = streamReader.ReadLine();
            }
            while (presetCheck != cardPreset);

            streamReader.ReadLine();
            streamReader.ReadLine();
            streamReader.ReadLine();

            string[] characterNames = streamReader.ReadLine().Split(',');
            string[] weaponNames = streamReader.ReadLine().Split(',');
            string[] roomNames = streamReader.ReadLine().Split(',');
            streamReader.Close();

            string[] labelData = characterNames.Concat(weaponNames).Concat(roomNames).ToArray();

            Label[] labelArray = new Label[21];
            int location = 44;
            Color[] colours = new Color[] {Color.Green, Color.Yellow, Color.Blue, Color.Purple, Color.Red, Color.White };
            for (int loop = 0; loop < 21; loop++)
            {
                Label label = new Label();
                label.Location = (new Point(12, location));
                label.Text = labelData[loop];
                label.Font = new Font("Microsoft Sans Serif", 15);
                label.Size = new Size(180, 25);

                if (loop >= 0 && loop <= 5)
                {
                    label.BackColor = colours[loop];
                }

                labelArray[loop] = label;
                Controls.Add(label);
                location += 25;
                if (location == 194 || location == 371)
                {
                    location += 27;
                }
            }            
        }

        private void SetupBoxes()
        {
            int locationX = 200;
            for (int loop = 0; loop < 6; loop++)
            {
                int locationY = 44;
                for (int loop2 = 0; loop2 < 21; loop2++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(locationX, locationY);
                    pictureBox.Size = new Size(57, 25);
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.Image = white;
                    pictureBox.MouseClick += new MouseEventHandler(ImageClicked);
                    Controls.Add(pictureBox);
                    locationY += 25;
                    if (locationY == 194 || locationY == 371)
                    {
                        locationY += 27;
                    }
                }
                locationX += 63;
            }

            int location = 200;
            for (int loop = 0; loop < 6; loop++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(location, 9);
                pictureBox.Size = new Size(57, 25);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;

                switch (loop)
                {
                    case 0:
                        pictureBox.BackColor = Color.Green;
                        break;
                    case 1:
                        pictureBox.BackColor = Color.Yellow;
                        break;
                    case 2:
                        pictureBox.BackColor = Color.Blue;
                        break;
                    case 3:
                        pictureBox.BackColor = Color.Purple;
                        break;
                    case 4:
                        pictureBox.BackColor = Color.Red;
                        break;
                    case 5:
                        pictureBox.BackColor = Color.White;
                        break;
                }

                Controls.Add(pictureBox);
                location += 63;
            }
        }

        private void ImageClicked(object sender, EventArgs e)
        {
            PictureBox pictureBoxSender = (PictureBox)sender;
            if (pictureBoxSender.Image == white)
            {
                pictureBoxSender.Image = cross;
            }
            else if (pictureBoxSender.Image == cross)
            {
                pictureBoxSender.Image = check;
            }
            else if (pictureBoxSender.Image == check)
            {
                pictureBoxSender.Image = white;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string directory = "E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo";
            Control[] pictureBoxArray = new Control[156];
            Controls.CopyTo(pictureBoxArray, 0);

            int index = 24;
            char sign = 'O';
            StreamWriter streamWriter = new StreamWriter(directory + "\\AnswerSheet.txt");
            for (int loop = 0; loop < 126; loop++)
            {
                PictureBox pictureBox = Controls[index] as PictureBox;
                if (pictureBox.Image == white)
                {
                    sign = 'O';
                }
                else if (pictureBox.Image == check)
                {
                    sign = 'V';
                }
                else if (pictureBox.Image == cross)
                {
                    sign = 'X';
                }
                streamWriter.Write(sign);
                index++;

                if (index == 45 || index == 66 || index == 87 || index == 108 || index == 129)
                {
                    streamWriter.Write("\n");
                }
                else
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string directory = "E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo";
            StreamReader streamReader = new StreamReader(directory + "\\AnswerSheet.txt");
            string[] fileData = new string[126];
            fileData = streamReader.ReadLine().Split(',').Concat(streamReader.ReadLine().Split(',')).Concat(streamReader.ReadLine().Split(',')).Concat(streamReader.ReadLine().Split(',')).Concat(streamReader.ReadLine().Split(',')).Concat(streamReader.ReadLine().Split(',')).ToArray();
            streamReader.Close();

            Image[] fileImages = new Image[126];
            for (int index = 0; index < 126; index++)
            {
                if(fileData[index] == "O")
                {
                    fileImages[index] = white;
                }
                else if (fileData[index] == "X")
                {
                    fileImages[index] = cross;
                }
                else if (fileData[index] == "V")
                {
                    fileImages[index] = check;
                }
            }

            ResetSheet();

            int location = 200;
            for (int loop = 0; loop < 6; loop++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(location, 9);
                pictureBox.Size = new Size(57, 25);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;

                switch (loop)
                {
                    case 0:
                        pictureBox.BackColor = Color.Green;
                        break;
                    case 1:
                        pictureBox.BackColor = Color.Yellow;
                        break;
                    case 2:
                        pictureBox.BackColor = Color.Blue;
                        break;
                    case 3:
                        pictureBox.BackColor = Color.Purple;
                        break;
                    case 4:
                        pictureBox.BackColor = Color.Red;
                        break;
                    case 5:
                        pictureBox.BackColor = Color.LightGray;
                        break;
                }

                Controls.Add(pictureBox);
                location += 63;
            }

            int locationX = 200;
            for (int loop = 0; loop < 6; loop++)
            {
                int locationY = 44;
                for (int loop2 = 0; loop2 < 21; loop2++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(locationX, locationY);
                    pictureBox.Size = new Size(57, 25);
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.Image = fileImages[(loop * 21) + (loop2)];
                    pictureBox.MouseClick += new MouseEventHandler(ImageClicked);
                    Controls.Add(pictureBox);
                    locationY += 25;
                    if (locationY == 194 || locationY == 371)
                    {
                        locationY += 27;
                    }
                }
                locationX += 63;
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetSheet();
            SetupBoxes();
        }

        private void ResetSheet()
        {
            for (int index = 0; index < 132; index++)
            {
                Controls.RemoveAt(24);
            }
        }
    }
}
