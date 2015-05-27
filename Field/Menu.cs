using System;
using System.IO;
using System.Threading;
using System.Windows.Media;

namespace TeamWork.Field
{
    class Menu
    {
        public static bool menuActive = true;
        public static bool validInput = true;
        public static MediaPlayer mediaPlayer = new MediaPlayer();
       
        /// <summary>
        /// Main menu load screen
        /// </summary>
        public static void StartMenu()
        {       
            //Menu Music Thread
            mediaPlayer.Open(new Uri("Resources/INTRO_SOUND.wav", UriKind.Relative));
            mediaPlayer.Play();
            Printing.WelcomeScreen();
            Thread.Sleep(2000);
            while (menuActive)
            {
                if (validInput)
                {
                    Console.Clear();
                    Printing.StartMenu();
                    validInput = false;
                }
                
                if (UserChoice(Console.ReadKey(true)))
                {
                    validInput = true;
                }
                else
                {
                    validInput = false;
                }
            }
        }  
        //Menu interface buttons
        //(Pause, Score, Credits,Quit)
        public static bool UserChoice(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.P: Console.Clear();
                    mediaPlayer.Stop();                  
                    menuActive = false;
                    return true;
                case ConsoleKey.S:
                    Console.Clear();
                    Printing.HighScore();
                    return true;
                case ConsoleKey.C: Console.Clear();
                    Printing.Credits();
                    return true;
                case ConsoleKey.Q: Environment.Exit(0);
                    return false;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Entry story line
        /// </summary>
        public static void EntryStoryLine()
        {
            Printing.LoadStory();
            Thread.Sleep(2500);
            Console.Clear();
            Printing.LoadContent();
            Console.Clear();          
        }
        /// <summary>
        /// Print UI top and bottom borders
        /// </summary>
        public static void Table()
        {
            // UI Top border
            for (int i = 0; i < 80; i++)
            {
                int nameBoard = 14 + Engine.Player.Name.Length;
                bool topBgPos = ((i <= 3) || (i >= nameBoard && i < 38) || i > 41);
                if (topBgPos)
                {
                    Printing.DrawAt(new Point2D(i, 0), '\u2591', ConsoleColor.DarkRed);
                }
            }
            // UI Bottom border
            for (int i = 0; i < 80; i++)
            {
                int liveBoard = 13;
                int scoreBoard = 30;
                if ((i <= 3) || (i > liveBoard && i < scoreBoard - 1) || i > scoreBoard + 10)
                {
                    Printing.DrawAt(new Point2D(i, 30), '\u2591', ConsoleColor.DarkRed);           
                }
            }
        }

        /// <summary>
        /// Draw UI 
        /// </summary>
        public static void UIDescription()
        {
            string level = string.Format("{0}", Engine.Player.Level).PadLeft(2, '0');

            string score = string.Format("Score: {0} ", Engine.Player.Score).PadLeft(3, '0');
            string playerName = string.Format("Player: {0}", Engine.Player.Name);

            Printing.DrawAt(new Point2D(5, 0), playerName, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(39, 0), level, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(5, 30), "Lifes: ", ConsoleColor.DarkYellow);
            Printing.DrawHLineAt(11, 30, Engine.Player.Lifes, '\u2665',ConsoleColor.Red); 
            Printing.ClearAtPosition(11 + Engine.Player.Lifes ,30);
            Printing.DrawAt(new Point2D(30, 30), score, ConsoleColor.DarkYellow);
        }

        #region Highscore and Score Methods
        //Checks if the oldHighScore and the CurrentHighScore are different, and sets the higher value as the new HighScore
        //Also adds all scores to the Scores.txt file
        public static void SetHighscore()
        {
            string highscore = String.Format("Player {0}, Highscore {1}, Time Achieved: {2} / {3} / {4}",
                Engine.Player.Name, Engine.Player.Score, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            string[] oldText = File.ReadAllText("Resources/Highscore.txt").Split();

            string oldHighScore = oldText[3].Remove(oldText[3].Length - 1);
            int oldHighScoreToInt = Int32.Parse(oldHighScore);

            if (oldHighScoreToInt < Engine.Player.Score)
                File.WriteAllText("Resources/Highscore.txt", highscore);

            string currentScores = File.ReadAllText("Resources/Scores.txt");
            highscore = String.Format("Player {0}, Score {1}, Time Achieved: {2} / {3} / {4}",
                Engine.Player.Name, Engine.Player.Score, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            currentScores += "#" + highscore + @"
";
            File.WriteAllText("Scores.txt", currentScores);
        }      
        /// <summary>
        /// Printing High Score in Main Menu Score screen
        /// </summary>
        public static void PrintHighscore()
        {
            string currentHighscore = File.ReadAllText("Resources/Highscore.txt");
            Printing.DrawAt(new Point2D(15, 14), "Current Highscore: ", ConsoleColor.Green);
            Printing.DrawAt(new Point2D(15, 15), currentHighscore, ConsoleColor.Green);
            Printing.DrawAt(new Point2D(15, 17), "Last Achieved Scores: ", ConsoleColor.Green);

            string[] currentScores = File.ReadAllLines("Resources/Scores.txt");
            int y = 15;
            int counter = 0;
            for (int i = currentScores.Length - 1; i >= currentScores.Length - 10; i--)
            {
                y++;
                counter++;
                Printing.DrawAt(new Point2D(15, y), counter + " " + currentScores[i], ConsoleColor.Green);
            }
        }
        #endregion
    }
}