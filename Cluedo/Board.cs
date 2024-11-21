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

namespace Cluedo
{
    public class Board
    {

        public string directory = "E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo";
        private string theme;
        private int round, turn, buttonArrayIndex = 0, timeLimit;
        private string[] playerOrder, playersInGame, middleCards, p1Cards, p2Cards, p3Cards, p4Cards, p5Cards, p6Cards, pointArray;
        private Button[] buttonArray = new Button[188];
        private bool movePlayers;
        private AI[] listOfAI = new AI[6];
        private Label[] roomLabels;
        private PictureBox[] playersInRooms = new PictureBox[6];

        public Board()
        {
            StreamReader streamReader = new StreamReader(directory + "\\Save Game.Txt");
            theme = streamReader.ReadLine();
            round = int.Parse(streamReader.ReadLine());
            turn = int.Parse(streamReader.ReadLine());
            playerOrder = streamReader.ReadLine().Split(',');
            playersInGame = streamReader.ReadLine().Split(',');
            middleCards = streamReader.ReadLine().Split(',');
            p1Cards = streamReader.ReadLine().Split(',');
            p2Cards = streamReader.ReadLine().Split(',');
            p3Cards = streamReader.ReadLine().Split(',');
            p4Cards = streamReader.ReadLine().Split(',');
            p5Cards = streamReader.ReadLine().Split(',');
            p6Cards = streamReader.ReadLine().Split(',');
            pointArray = streamReader.ReadLine().Split(',');
            movePlayers = bool.Parse(streamReader.ReadLine());
            timeLimit = int.Parse(streamReader.ReadLine());
            streamReader.Close();
            for (int loop = 0; loop < 6; loop++)
            {
                if (playerOrder[loop] == "Easy" || playerOrder[loop] == "Medium" || playerOrder[loop] == "Hard")
                {
                    listOfAI[loop] = new AI(playerOrder[loop], pointArray[loop], loop);
                }
            }
        }

        public void SetupPlayerTiles()
        {
            int index = -1;
            do
            {
                index++;
                if (pointArray[0] != "N" && pointArray[0] != "R1" && pointArray[0] != "R2" && pointArray[0] != "R3" && pointArray[0] != "R4" && pointArray[0] != "R5" && pointArray[0] != "R6" && pointArray[0] != "R7" && pointArray[0] != "R8" && pointArray[0] != "R9")
                {
                    if (index == int.Parse(pointArray[0]))
                    {
                        buttonArray[index].BackColor = Color.Green;
                    }
                }
                if (pointArray[1] != "N" && pointArray[1] != "R1" && pointArray[1] != "R2" && pointArray[1] != "R3" && pointArray[1] != "R4" && pointArray[1] != "R5" && pointArray[1] != "R6" && pointArray[1] != "R7" && pointArray[1] != "R8" && pointArray[1] != "R9")
                {
                    if (index == int.Parse(pointArray[1]))
                    {
                        buttonArray[index].BackColor = Color.Yellow;
                    }
                }
                if (pointArray[2] != "N" && pointArray[2] != "R1" && pointArray[2] != "R2" && pointArray[2] != "R3" && pointArray[2] != "R4" && pointArray[2] != "R5" && pointArray[2] != "R6" && pointArray[2] != "R7" && pointArray[2] != "R8" && pointArray[2] != "R9")
                {
                    if (index == int.Parse(pointArray[2]))
                    {
                        buttonArray[index].BackColor = Color.Blue;
                    }
                }
                if (pointArray[3] != "N" && pointArray[3] != "R1" && pointArray[3] != "R2" && pointArray[3] != "R3" && pointArray[3] != "R4" && pointArray[3] != "R5" && pointArray[3] != "R6" && pointArray[3] != "R7" && pointArray[3] != "R8" && pointArray[3] != "R9")
                {
                    if (index == int.Parse(pointArray[3]))
                    {
                        buttonArray[index].BackColor = Color.Purple;
                    }
                }
                if (pointArray[4] != "N" && pointArray[4] != "R1" && pointArray[4] != "R2" && pointArray[4] != "R3" && pointArray[4] != "R4" && pointArray[4] != "R5" && pointArray[4] != "R6" && pointArray[4] != "R7" && pointArray[4] != "R8" && pointArray[4] != "R9")
                {
                    if (index == int.Parse(pointArray[4]))
                    {
                        buttonArray[index].BackColor = Color.Red;
                    }
                }
                if (pointArray[5] != "N" && pointArray[5] != "R1" && pointArray[5] != "R2" && pointArray[5] != "R3" && pointArray[5] != "R4" && pointArray[5] != "R5" && pointArray[5] != "R6" && pointArray[5] != "R7" && pointArray[5] != "R8" && pointArray[5] != "R9")
                {
                    if (index == int.Parse(pointArray[5]))
                    {
                        buttonArray[index].BackColor = Color.Gray;
                    }
                }
            }
            while (index < 188);
        }

        public void AddButtonToArray(Button button)
        {
            buttonArray[buttonArrayIndex] = button;
            buttonArrayIndex++;
        }

        private void IncrementRound()
        {
            round++;
        }

        public void IncrementTurn()
        {
            turn++;
            if (turn == 6)
            {
                turn = 0;
                IncrementRound();
            }
        }

        public void SetRoomLabel(PictureBox pictureBox)
        {
            playersInRooms[turn] = pictureBox;
        }

        public void SetRoomLabels(Label[] roomLabelArg)
        {
            roomLabels = roomLabelArg;
        }

        public string GetPlayerTurn()
        {
            return playerOrder[turn];            
        }

        public int GetTurn()
        {
            return turn;
        }

        public int GetRound()
        {
            return round;
        }

        public string[] GetCards(int turn)
        {
            if (turn == 0)
            {
                return p1Cards;
            }
            else if (turn == 1)
            {
                return p2Cards;
            }
            else if (turn == 2)
            {
                return p3Cards;
            }
            else if (turn == 3)
            {
                return p4Cards;
            }
            else if (turn == 4)
            {
                return p5Cards;
            }
            else if (turn == 5)
            {
                return p6Cards;
            }
            return null;
        }

        public string GetColour()
        {
            string colour = "";
            switch (turn)
            {
                case 0:
                    colour = "Green";
                    break;
                case 1:
                    colour = "Yellow";
                    break;
                case 2:
                    colour = "Blue";
                    break;
                case 3:
                    colour = "Purple";
                    break;
                case 4:
                    colour = "Red";
                    break;
                case 5:
                    colour = "White";
                    break;
            }
            return colour;
        }

        public int GetRoomFromLabel(Label label)
        {
            for (int loop = 0; loop < 9; loop++)
            {
                if (label.Text == roomLabels[loop].Text)
                {
                    return (loop + 1);
                }
            }
            return 0;
        }

        public void ShowMoves(int diceTotal)
        {
            int index = -1;
            Button button = new Button();
            Color colourFill = Color.DarkGreen;
            if (GetPlayerTurn() == "Player")
            {
                colourFill = Color.Black;
            }
            if (pointArray[turn] != "R1" && pointArray[turn] != "R2" && pointArray[turn] != "R3" && pointArray[turn] != "R4" && pointArray[turn] != "R5" && pointArray[turn] != "R6" && pointArray[turn] != "R7" && pointArray[turn] != "R8" && pointArray[turn] != "R9")
            {                
                Color colour = GetColourForMoves();
                do
                {
                    index++;
                    button = (Button)buttonArray[index];
                }
                while (button.BackColor != colour);
                ShowMoves2(diceTotal, button, colourFill);
                button.BackColor = colour;
            }
            else
            {
                if (pointArray[turn] == "R1")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(119, 209));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R2")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(209, 149));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(269, 239));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(419, 239));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(479, 149));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R3")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(599, 179));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R4")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(509, 269));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(659, 389));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R5")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(599, 389));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(479, 479));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R6")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(539, 599));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R7")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(449, 599));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(389, 509));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(359, 509));
                    ShowMoves2(diceTotal, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(239, 599));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R8")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(149, 539));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
                if (pointArray[turn] == "R9")
                {
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(179, 479));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                    index = -1;
                    do
                    {
                        index++;
                        button = (Button)buttonArray[index];
                    }
                    while (button.Location != new Point(239, 359));
                    ShowMoves2(diceTotal - 1, button, colourFill);
                }
            }
        }

        private void ShowMoves2(int diceTotal, Button button, Color colourFill)
        {
            Button buttonTemp = new Button();
            if (diceTotal == 0)
            {
                if (button.BackColor == Color.White)
                {
                    button.BackColor = colourFill;
                }                
            }
            else
            {
                if (button.Location == new Point(119, 209))
                {
                    roomLabels[0].BackColor = colourFill;
                    roomLabels[0].ForeColor = Color.White;
                }
                if (button.Location == new Point(209, 149) || button.Location == new Point(269, 239) || button.Location == new Point(419, 239) || button.Location == new Point(479, 149))
                {
                    roomLabels[1].BackColor = colourFill;
                    roomLabels[1].ForeColor = Color.White;
                }
                if (button.Location == new Point(599, 179))
                {
                    roomLabels[2].BackColor = colourFill;
                    roomLabels[2].ForeColor = Color.White;
                }
                if (button.Location == new Point(509, 269) || button.Location == new Point(659, 389))
                {
                    roomLabels[3].BackColor = colourFill;
                    roomLabels[3].ForeColor = Color.White;
                }
                if (button.Location == new Point(599, 389) || button.Location == new Point(479, 479))
                {
                    roomLabels[4].BackColor = colourFill;
                    roomLabels[4].ForeColor = Color.White;
                }
                if (button.Location == new Point(539, 599))
                {
                    roomLabels[5].BackColor = colourFill;
                    roomLabels[5].ForeColor = Color.White;
                }
                if (button.Location == new Point(449, 599) || button.Location == new Point(389, 509) || button.Location == new Point(359, 509) || button.Location == new Point(239, 599))
                {
                    roomLabels[6].BackColor = colourFill;
                    roomLabels[6].ForeColor = Color.White;
                }
                if (button.Location == new Point(149, 539))
                {
                    roomLabels[7].BackColor = colourFill;
                    roomLabels[7].ForeColor = Color.White;
                }
                if (button.Location == new Point(179, 479) || button.Location == new Point(239, 359))
                {
                    roomLabels[8].BackColor = colourFill;
                    roomLabels[8].ForeColor = Color.White;
                }
                int index = -1;
                do
                {
                    index++;
                    buttonTemp = (Button)buttonArray[index];
                }
                while (buttonTemp.Location != new Point(button.Location.X, button.Location.Y + 30) && index < 187);
                if (index < 187)
                {
                    ShowMoves2(diceTotal - 1, buttonTemp, colourFill);
                    if (buttonTemp.BackColor == Color.White)
                    {
                        buttonTemp.BackColor = colourFill;
                    }
                }
                index = -1;
                do
                {
                    index++;
                    buttonTemp = (Button)buttonArray[index];
                }
                while (buttonTemp.Location != new Point(button.Location.X, button.Location.Y - 30) && index < 187);
                if (index < 187)
                {
                    ShowMoves2(diceTotal - 1, buttonTemp, colourFill);
                    if (buttonTemp.BackColor == Color.White)
                    {
                        buttonTemp.BackColor = colourFill;
                    }
                }
                index = -1;
                do
                {
                    index++;
                    buttonTemp = (Button)buttonArray[index];
                }
                while (buttonTemp.Location != new Point(button.Location.X + 30, button.Location.Y) && index < 187);
                if (index < 187)
                {
                    ShowMoves2(diceTotal - 1, buttonTemp, colourFill);
                    if (buttonTemp.BackColor == Color.White)
                    {
                        buttonTemp.BackColor = colourFill;
                    }
                }
                index = -1;
                do
                {
                    index++;
                    buttonTemp = (Button)buttonArray[index];
                }
                while (buttonTemp.Location != new Point(button.Location.X - 30, button.Location.Y) && index < 187);
                if (index < 187)
                {
                    ShowMoves2(diceTotal - 1, buttonTemp, colourFill);
                    if (buttonTemp.BackColor == Color.White)
                    {
                        buttonTemp.BackColor = colourFill;
                    }
                }
            }            
        }

        private Color GetColourForMoves()
        {
            string colour = GetColour();
            Color movesColour = new Color();
            if (colour == "Green")
            {
                movesColour = Color.Green;
            }
            else if (colour == "Yellow")
            {
                movesColour = Color.Yellow;
            }
            else if (colour == "Blue")
            {
                movesColour = Color.Blue;
            }
            else if (colour == "Purple")
            {
                movesColour = Color.Purple;
            }
            else if (colour == "Red")
            {
                movesColour = Color.Red;
            }
            else if (colour == "White")
            {
                movesColour = Color.Gray;
            }
            return movesColour;
        }

        public void ResetBlackTiles()
        {
            for (int resetLoop = 0; resetLoop < 188; resetLoop++)
            {
                Button button = (Button)buttonArray[resetLoop];
                if (button.BackColor == Color.Black)
                {
                    button.BackColor = Color.White;
                }
            }
            for (int resetLoop = 0; resetLoop < 9; resetLoop++)
            {
                roomLabels[resetLoop].BackColor = Color.LightGray;
                roomLabels[resetLoop].ForeColor = Color.Black;
            }
        }

        public void SetupWhiteTiles()
        {
            for (int resetLoop = 0; resetLoop < 188; resetLoop++)
            {
                Button button = (Button)buttonArray[resetLoop];
                button.BackColor = Color.White;
            }
        }

        public void SetupGreyLabels()
        {
            for (int resetLoop = 0; resetLoop < 9; resetLoop++)
            {
                roomLabels[resetLoop].BackColor = Color.LightGray;
            }
        }

        public void MoveTiles(Button button)
        {
            if (button.BackColor == Color.Black)
            {
                ResetBlackTiles();
                ResetTileForTurn();
                
                button.BackColor = GetColourForMoves();
                UpdatePositionTile();
            }
        }

        public void MoveTilesRoom(Label label, int roomNumber)
        {
            if (label.BackColor == Color.Black)
            {
                ResetBlackTiles();
                ResetTileForTurn();

                UpdatePositionLabel(roomNumber);
            }
        }

        public void ResetTileForTurn()
        {
            Color colour = GetColourForMoves();
            Button buttonCheck = new Button();
            int index = -1;
            if (pointArray[turn] != "R1" && pointArray[turn] != "R2" && pointArray[turn] != "R3" && pointArray[turn] != "R4" && pointArray[turn] != "R5" && pointArray[turn] != "R6" && pointArray[turn] != "R7" && pointArray[turn] != "R8" && pointArray[turn] != "R9")
            {
                do
                {
                    index++;
                    buttonCheck = (Button)buttonArray[index];
                }
                while (buttonCheck.BackColor != colour);
                buttonCheck.BackColor = Color.White;
            }
            else
            {
                playersInRooms[turn].Location = new Point(-100, -100);
                playersInRooms[turn] = null;
            }
        }

        private void UpdatePositionTile()
        {
            Color colour = GetColourForMoves();
            int index = -1;
            do
            {
                index++;
            }
            while (buttonArray[index].BackColor != colour);
            pointArray[turn] = index.ToString();
        }

        private void UpdatePositionLabel(int roomNumber)
        {
            pointArray[turn] = "R" + roomNumber;
        }

        public void SaveGame()
        {
            StreamWriter streamWriter = new StreamWriter(directory + "\\Save Game.txt");
            streamWriter.WriteLine(theme + "\n" + round.ToString() + "\n" + turn.ToString());
            for (int index = 0; index < 6; index++)
            {
                streamWriter.Write(playerOrder[index]);
                if (index != 5)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < 6; index++)
            {
                streamWriter.Write(playersInGame[index]);
                if (index != 5)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < 3; index++)
            {
                streamWriter.Write(middleCards[index]);
                if (index != 2)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p1Cards.Length; index++)
            {
                streamWriter.Write(p1Cards[index]);
                if (index != p1Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p2Cards.Length; index++)
            {
                streamWriter.Write(p2Cards[index]);
                if (index != p2Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p3Cards.Length; index++)
            {
                streamWriter.Write(p3Cards[index]);
                if (index != p3Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p4Cards.Length; index++)
            {
                streamWriter.Write(p4Cards[index]);
                if (index != p4Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p5Cards.Length; index++)
            {
                streamWriter.Write(p5Cards[index]);
                if (index != p5Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < p6Cards.Length; index++)
            {
                streamWriter.Write(p6Cards[index]);
                if (index != p6Cards.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            for (int index = 0; index < pointArray.Length; index++)
            {
                streamWriter.Write(pointArray[index]);
                if (index != pointArray.Length - 1)
                {
                    streamWriter.Write(",");
                }
            }
            streamWriter.Write("\n");
            streamWriter.WriteLine(movePlayers.ToString());
            streamWriter.Write(timeLimit);

            streamWriter.Close();
        }

        public void AITurn()
        {
            listOfAI[turn].AITurn();
        }
    }
}