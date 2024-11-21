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
    class AI
    {
        private string difficulty, finalGuessRoom, finalGuessWeapon, finalGuessCharacter, location;
        private int[] roomsToCheck = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private string[] weaponsToCheck = new string[6] { "a", "b", "c", "d", "e", "f" };
        private string[] charactersToCheck = new string[6] { "A", "B", "C", "D", "E", "F" };
        private int characterPlace;
        private Random random = new Random();

        public AI(string difficulty, string location, int characterPlace)
        {
            this.difficulty = difficulty;
            this.location = location;
            this.characterPlace = characterPlace;
            RemoveKnownCards();
            ShowCards();
        }

        public void ShowCards()
        {
            //for (int loop = 0; loop < weaponsToCheck.Length; loop++)
            //{
            //    MessageBox.Show(weaponsToCheck[loop]);
            //}
            //for (int loop = 0; loop < charactersToCheck.Length; loop++)
            //{
            //    MessageBox.Show(charactersToCheck[loop]);
            //}
            //for (int loop = 0; loop < roomsToCheck.Length; loop++)
            //{
            //    MessageBox.Show(roomsToCheck[loop].ToString());
            //}
        }

        public void AITurn()
        {
            if (difficulty == "Easy")
            {
                EasyTurn();
            }
            else if (difficulty == "Medium")
            {
                MediumTurn();
            }
            else if (difficulty == "Hard")
            {
                HardTurn();
            }
        }

        private void EasyTurn()
        {
            int weaponCheck = random.Next(0, weaponsToCheck.Length);
            int characterCheck = random.Next(0, charactersToCheck.Length);
            int roomCheck = random.Next();
        }

        private void MediumTurn()
        {
            MessageBox.Show(difficulty);
        }

        private void HardTurn()
        {
            MessageBox.Show(difficulty);
        }

        private void RemoveKnownCards()
        {
            StreamReader streamReader = new StreamReader("E:\\College USB\\Computer Science USB\\NEA - Cluedo\\Cluedo\\Save Game.txt");
            for (int skipLines = 0; skipLines < 5 + characterPlace; skipLines++)
            {
                streamReader.ReadLine();
            }
            string[] AICards = streamReader.ReadLine().Split(',');
            for (int index = 0; index < AICards.Length; index++)
            {
                if (AICards[index] == "1" || AICards[index] == "2" || AICards[index] == "3" || AICards[index] == "4" || AICards[index] == "5" || AICards[index] == "6" || AICards[index] == "7" || AICards[index] == "8" || AICards[index] == "9")
                {
                    ShortenRoomsToCheck(int.Parse(AICards[index]));
                }
                else if (AICards[index] == "a" || AICards[index] == "b" || AICards[index] == "c" || AICards[index] == "d" || AICards[index] == "e" || AICards[index] == "f")
                {
                    ShortenWeaponsToCheck(AICards[index]);
                }
                else if (AICards[index] == "A" || AICards[index] == "B" || AICards[index] == "C" || AICards[index] == "D" || AICards[index] == "E" || AICards[index] == "F")
                {
                    ShortenCharactersToCheck(AICards[index]);
                }
            }
            streamReader.Close();
        }

        private void ShortenRoomsToCheck(int room)
        {
            int[] tempList = new int[roomsToCheck.Length - 1];
            int index = 0;
            for (int checkIndex = 0; checkIndex < tempList.Length; checkIndex++)
            {
                if (roomsToCheck[checkIndex] == room)
                {
                    MessageBox.Show(room.ToString());
                    index++;
                }
                tempList[checkIndex] = roomsToCheck[index];
            }
            roomsToCheck = tempList;
        }

        private void ShortenWeaponsToCheck(string weapon)
        {
            string[] tempList = new string[weaponsToCheck.Length - 1];
            int index = 0;
            for (int checkIndex = 0; checkIndex < tempList.Length; checkIndex++)
            {
                if (weaponsToCheck[checkIndex] == weapon)
                {
                    MessageBox.Show(weapon);
                    index++;
                }
                tempList[checkIndex] = weaponsToCheck[index];
            }
            weaponsToCheck = tempList;
        }

        private void ShortenCharactersToCheck(string character)
        {
            string[] tempList = new string[charactersToCheck.Length - 1];
            int index = 0;
            for (int checkIndex = 0; checkIndex < tempList.Length; checkIndex++)
            {
                if (charactersToCheck[checkIndex] == character)
                {
                    MessageBox.Show(character);
                    index++;
                }
                tempList[checkIndex] = charactersToCheck[index];
            }
            charactersToCheck = tempList;
        }
    }
}
