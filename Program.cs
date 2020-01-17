using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabbel
{
    class Program
    {
        Random rnd = new Random();
        int score;
        void Introduction()
        {
            //An introduction to the game and its rules
            Console.WriteLine("Welcome to off-brand scrabble!\nRULES:\n1) You will be given a selection of 7 letters\n" +
                "2) Your mission, should you accept, is to create as many words as possible out of the provided letters\n" +
                "3) Each of your words will be given a score based on the value of each letter in it\n" +
                "4) Type '!' to finish making words\n" +
                "5) Your score will be totalled and given to you at the end of the round\n" +
                "6) You can then chose to play again and try and beat your score, or give up like a wimp and end the program\n" +
                "7) You must type in all caps\n" +
                "8) Have fun!!!\n" +
                "NOTE: Your words will not be checked to see if they're actually words so don't cheat pls\n");
        }
        char[] ChoseLetters()
        {
            //Initialising a bunch of stuff
            int num = 0;
            List<int> used = new List<int>();
            char[] letters = new char[7];
            char[] lettersBag = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A' ,
                                    'B', 'B',
                                    'C', 'C',
                                    'D', 'D', 'D', 'D',
                                    'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E',
                                    'F', 'F',
                                    'G', 'G', 'G',
                                    'H', 'H',
                                    'I' , 'I', 'I', 'I', 'I', 'I', 'I', 'I', 'I',
                                    'J',
                                    'K',
                                    'L', 'L', 'L', 'L',
                                    'M', 'M',
                                    'N', 'N', 'N', 'N', 'N', 'N',
                                    'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O',
                                    'P', 'P',
                                    'Q',
                                    'R', 'R', 'R', 'R', 'R', 'R',
                                    'S', 'S', 'S', 'S',
                                    'T', 'T', 'T', 'T', 'T', 'T',
                                    'U', 'U', 'U', 'U',
                                    'V', 'V',
                                    'W', 'W',
                                    'X',
                                    'Y', 'Y',
                                    'Z' };

            for(int i = 0; i < 7; i++)
            {       
                num = rnd.Next(0, lettersBag.Length - 1);       
                if (!used.Contains(num))
                {
                    letters[i] = lettersBag[num];
                    used.Add(num);                   
                }
                
            }
            return letters;
        }
        void LetterScores(char letter)
        {
            switch(letter)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'L':
                case 'N':
                case 'O':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                    score = score + 1;
                    break;
                case 'D':
                case 'G':
                    score = score + 2;
                    break;
                case 'B':
                case 'C':
                case 'M':
                case 'P':
                    score = score + 3;
                    break;
                case 'F':
                case 'H':
                case 'V':
                case 'W':
                case 'Y':
                    score = score + 4;
                    break;
                case 'K':
                    score = score + 5;
                    break;
                case 'J':
                case 'X':
                    score = score + 8;
                    break;
                case 'Q':
                case 'Z':
                    score = score + 10;
                    break;
            }       
        }

        //FIX THIS YOU STOP GETTING POINTS AFTER GETTING ONE WRONG
        void MakeWord(ref char[] letters, ref bool moreWords)
        {
            char[] lettersTemp = letters;
            int valid = 0;
         
            string input = Console.ReadLine();
            if (input[0] == '!')
            {
                moreWords = false;
            }
            else
            {
                moreWords = true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                    if (input[i] == lettersTemp[j])
                    {
                        lettersTemp[j] = '¬';
                        valid = valid + 1;
                    }
            }
            if (valid == input.Length)
            {
                for (int i = 0; i < input.Length; i ++)
                {
                    LetterScores(input[i]);
                }
            }
        }
            void Main()
        {
            //Defines a boolean play which is to be used to decide if the user wants to keep playing
            bool play = true;

            //Calls the introduction function
            Introduction();

            while (play == true)
            {
                //Sets score to 0
                score = 0;

                char[] letters = ChoseLetters();

                //Writes out each available letter with spaces between
                Console.WriteLine("\nPlease make a word with the letters provided:");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write(letters[i]);
                    Console.Write(' ');
                }
                Console.Write("\n\n");

                bool moreWords = true;               
                while (moreWords == true)
                {
                    MakeWord(ref letters, ref moreWords);
                    Console.WriteLine(score);
                }

                Console.WriteLine("Your total score is:" + score);
                Console.WriteLine("\nWould you like to try again?");
                
            }
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Main();
            Console.ReadKey();
        }
    }
}
