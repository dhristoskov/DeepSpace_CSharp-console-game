using System;
using System.Threading;

namespace TeamWork.Field
{
    public static class Printing
    {
        #region Printing Methods

        /// <summary>
        /// Draw an object at given X and Y Coordinates
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="obj">Object to print</param>
        public static void DrawAt(int x, int y, object obj)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(obj.ToString());
        }


        /// <summary>
        /// Draw an object at a Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="obj">Object to print</param>
        public static void DrawAt(Point2D point, object obj)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(obj.ToString());
        }
        /// <summary>
        /// Draw an object at given X and Y Coordinates with a color
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawAt(int x, int y, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(x, y, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw an object at given Point2D with color
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawAt(Point2D point, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(point, obj);
            Console.ResetColor();
        }

        public static void DrawAtBG(int x, int y, object obj, ConsoleColor bclr)
        {
            Console.BackgroundColor = bclr;
            DrawAt(x, y, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at X and Y
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawVLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x,y, obj, clr);
                y++;
            }
            
        }

        /// <summary>
        /// Draw vertical line with given lenght with a pause between characters
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="sleep">Pause time between characters(ms)</param>
        /// <param name="reverse">True if you want to draw from right to left</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawVLineAt(int x, int y, int lenght, object obj, int sleep, bool reverse, ConsoleColor clr = ConsoleColor.White)
        {

            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obj, clr);
                if (reverse)
                {
                    y--;
                }
                else
                {
                    y++;
                }
                Thread.Sleep(sleep);
            }

        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="lenght">Length of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawVLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawVLineAt(point.X,point.Y, lenght, obj, clr);
        }


        /// <summary>
        /// Draw a horizontal line with given lenght starting at X and Y
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawHLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x,y, obj, clr);
                x++;
            }
        }

        /// <summary>
        /// Draw a horizontal line with given lenght and pause bethween characters
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="sleep">Pause time between characters(ms)</param>
        /// <param name="reverse">True if you want to draw from right to left</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawHLineAt(int x, int y, int lenght, object obj,int sleep,bool reverse, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obj, clr);
                if (reverse)
                {
                    x--;
                }
                else
                {
                    x++;
                }
                Thread.Sleep(sleep);
            }
        }

        /// <summary>
        /// Draw a horizontal line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawHLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawHLineAt(point.X,point.Y, lenght, obj, clr);
        }

        /// <summary>
        /// Draw a Rectangle starting at given X Y position with set size
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="size">Size of the rectangle</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawRectangleAt(int x, int y, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {

            for (int i = 0, side1 = 0; i < size; i++)
            {
                DrawAt(x + side1++, y, obj, clr);
            }

            for (int i = 0, side2 = 0; i < size; i++)
            {
                DrawAt(x + size - 1, y + side2++, obj, clr);
            }

            for (int i = 0, side3 = 0; i < size; i++)
            {
                DrawAt(x + side3++, y + size, obj, clr);
            }

            for (int i = 0, side4 = 0; i < size; i++)
            {
                DrawAt(x, y + side4++, obj, clr);
            }
        }

        /// <summary>
        /// Draw a Rectangle starting at position Point2D with given size
        /// </summary>
        /// <param name="point">Point2D to start at</param>
        /// <param name="size">Size of the rectangle</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawRectangleAt(Point2D point, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawRectangleAt(point.X,point.Y, size, obj, clr);
        }


        /// <summary>
        /// Drawing given string character by character with a sleep between each one
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="str">String to print</param>
        /// <param name="sleep">Sleep time between chars(ms)</param>
        /// <param name="reverse">If you want to print from right to left</param>
        /// <param name="clr"></param>
        public static void DrawStringCharByChar(int x, int y, string str, int sleep, bool reverse,
            ConsoleColor clr = ConsoleColor.White)
        {
            if (reverse)
            {
                x = x + str.Length - 1;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    DrawAt(x, y, str[i], clr);
                    x--;
                    Thread.Sleep(sleep);
                }
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    DrawAt(x, y, str[i], clr);
                    x++;
                    Thread.Sleep(sleep);
                }
            }
        }

        #endregion

        #region Grаphics
        /// <summary>
        /// Draw High Score screen
        /// linked to main menu
        /// </summary>
        public static void HighScore()
        {
            DrawHLineAt(0, 0, 80, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawHLineAt(79, 30, 80, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawVLineAt(0, 30, 31, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);
                      
            DrawStringCharByChar(18, 5, @" _  _ _      _      ___", 5, false, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 6, @"| || (_)__ _| |_   / __| __ ___ _ _ ___", 3, true, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 7, @"| __ | / _` | ' \  \__ \/ _/ _ \ '_/ -_)", 3, false, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 8, @"|_||_|_\__, |_||_| |___/\__\___/_| \___|", 3, true, ConsoleColor.Magenta);
            DrawStringCharByChar(25, 9, @"|___/", 5, false, ConsoleColor.Magenta);
            Thread.Sleep(550);
            DrawAt(28, 28, @"(B)ack to Mine Menu", ConsoleColor.Yellow);
            Menu.PrintHighscore();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.B)
                {
                    Menu.validInput = true;
                    break;
                }
            }

        }
        /// <summary>
        /// Draw Welcome screen
        /// linked to main menu
        /// </summary>
        public static void WelcomeScreen()
        {
            DrawHLineAt(0, 0, 80, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawHLineAt(79, 30, 80, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawVLineAt(0, 30, 31, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);

            DrawAt(15, 2, " _    _  ____  __    ___  _____  __  __  ____", ConsoleColor.Cyan);
            Thread.Sleep(150);
            DrawAt(15, 3, @"( \/\/ )( ___)(  )  / __)(  _  )(  \/  )( ___)", ConsoleColor.Cyan);
            Thread.Sleep(150);
            DrawAt(15, 4, @" )    (  )__)  )(__( (__  )(_)(  )    (  )__)", ConsoleColor.Cyan);
            Thread.Sleep(150);
            DrawAt(15, 5, @"(__/\__)(____)(____)\___)(_____)(_/\/\_)(____)", ConsoleColor.Cyan);
            Thread.Sleep(800);
            DrawAt(20, 7, "Made with passion by: Team ECHIDNA", ConsoleColor.Yellow);
            Thread.Sleep(1000);

            DrawAt(25, 13, @"    ._`-\ )\,`-.-.", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 14, @"   \'\` \)\ \)\ \|.)", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 15, @"  \`)  |\)  )\ .)\ )\|", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 16, @"  \ \)\ |)\  `  \ .')/|", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 17, @" ``-.\ \    )\ ` . ., '(", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 18, @" \\ -. `)\``- ._  .)`  |(", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 19, @"  `__  '\ `--  _\`. `  (", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 20, @"  `\,\      .\\        /", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 21, @"    '` )  (`-.\\      `", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 22, @"       /||\   `.  * _*|", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 23, @"                `-.( `\", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 24, @"                    `. \", ConsoleColor.Yellow);
            Thread.Sleep(100);
            DrawAt(25, 25, @"                      `()", ConsoleColor.Yellow);
        }
        /// <summary>
        /// Draw Main Menu screen
        /// linked to main menu
        /// </summary>
        public static void StartMenu()
        {
            DrawHLineAt(0, 0, 80, '\u2591', 1, false, ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', 1, false, ConsoleColor.Yellow);
            DrawHLineAt(79, 30, 80, '\u2591', 1, true, ConsoleColor.Yellow);
            DrawVLineAt(0, 30, 31, '\u2591', 1, true, ConsoleColor.Yellow);

            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ",ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ",ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ",ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ",ConsoleColor.Cyan);
            DrawStringCharByChar(1, 7, @"           ____  ____  ____  ____    ____  ____   __    ___  ____       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(1, 8, @"          (    \(  __)(  __)(  _ \  / ___)(  _ \ / _\  / __)(  __)      ", 1, true, ConsoleColor.DarkGray);
            DrawStringCharByChar(1, 9, @"           ) D ( ) _)  ) _)  ) __/  \___ \ ) __//    \( (__  ) _)       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(1, 10,@"          (____/(____)(____)(__)    (____/(__)  \_/\_/ \___)(____)      ", 1, true, ConsoleColor.DarkGray);
            DrawAt(1, 11,@"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12,@"                  *         .                       +                     ",ConsoleColor.Cyan);
            DrawStringCharByChar(1, 13,@"      .                      G A M E   M E N U                          ", 1, true, ConsoleColor.Cyan);
            DrawAt(1, 14,@"              ,                                                           ",ConsoleColor.Cyan);
            DrawStringCharByChar(1, 15,@"                                  (P)lay                +               ", 1, false, ConsoleColor.Cyan);
            DrawStringCharByChar(1, 16,@"                 *                (S)core Board                         ", 1, true, ConsoleColor.Cyan);
            DrawStringCharByChar(1, 17,@"     .                            (C)redits          *                  ", 1, false, ConsoleColor.Cyan);
            DrawStringCharByChar(1, 18,@"                                  (Q)uit        *                      ", 1, true, ConsoleColor.Cyan);
            DrawAt(1, 19,@".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20,@".                            *                                     +      ",ConsoleColor.Cyan);
            DrawStringCharByChar(1, 21,@" ____^/\___^--___/\_____-^^-^--_______/\ /\---/\___________---/\---_______", 1, false, ConsoleColor.Green);
            DrawStringCharByChar(1, 22,@"     -    ---     /\^              ^      ^       ^            ^      /\  ", 1, false, ConsoleColor.Green);
            DrawStringCharByChar(1, 23,@"         --       __ _-                     ^                __       --  ", 1, false, ConsoleColor.Green);
            DrawStringCharByChar(1, 24,@"   --  __                           ___--  ^  ^                /\^        ", 1, false, ConsoleColor.Green);

        }
        /// <summary>
        /// Draw Credits screen
        /// SoftUni and GitHub links
        /// linked to main menu
        /// </summary>
        public static void Credits()
        {
            DrawHLineAt(0, 0, 80, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', 3, false, ConsoleColor.Yellow);
            DrawHLineAt(79, 30, 80, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawVLineAt(0, 30, 31, '\u2591', 3, true, ConsoleColor.Yellow);
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);

            Thread.Sleep(650);
            DrawAt(23, 6, @"   _____           ___ __   ", ConsoleColor.Yellow);
            DrawAt(23, 7, @"  / ___/______ ___/ (_) /____", ConsoleColor.Yellow);
            DrawAt(23, 8, @" / /__/ __/ -_) _  / / __(_-<", ConsoleColor.Yellow);
            DrawAt(23, 9, @" \___/_/  \__/\_,_/_/\__/___/", ConsoleColor.Yellow);
            Thread.Sleep(1500);
            DrawAt(23, 13, @"         TEAM ECHIDNA:", ConsoleColor.Yellow);
            Thread.Sleep(650);
            DrawAt(23, 15, @"         Inspix", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 16, @"         Gogok", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 17, @"         DHristoskov ", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 18, @"         Shano", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 19, @"         n0way0ut", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 21, @"         (S)oftUni site", ConsoleColor.Yellow);
            Thread.Sleep(500);
            DrawAt(5, 26, @"(B)ack to Main Menu", ConsoleColor.Yellow);            
            DrawAt(52, 26, @"Give Us Feedback at:", ConsoleColor.Yellow);
            DrawAt(52, 27, @"(L)ink to GitHub", ConsoleColor.Yellow);            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.B)
                {
                    Menu.validInput = true;
                    break;
                }
                else if (key.Key == ConsoleKey.L)
                {
                    System.Diagnostics.Process.Start("https://github.com/AdvancedCSharpTeam/AdvancedCSharpProject");
                }
                else if (key.Key == ConsoleKey.S)
                {
                    System.Diagnostics.Process.Start("https://softuni.bg/");
                }
            }
        }
        /// <summary>
        /// Draw Game Over screen
        /// </summary>
        public static void GameOver()
        {
            DrawHLineAt(0, 0, 80, '\u2591', 2, false, ConsoleColor.Red);
            DrawVLineAt(79, 0, 31, '\u2591', 2, false, ConsoleColor.Red);
            DrawHLineAt(79, 30, 80, '\u2591', 2, true, ConsoleColor.Red);
            DrawVLineAt(0, 30, 31, '\u2591', 2, true, ConsoleColor.Red);
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                    Thank you for playing  ", ConsoleColor.Blue);
            DrawAt(1, 28, @"                                                        Team:ECHIDNA       ", ConsoleColor.Blue);

            DrawStringCharByChar(10, 7, @"   _________    __  _________   ____ _    ____________ ", 2, false, ConsoleColor.Yellow);
            DrawStringCharByChar(10, 8, @"  / ____/   |  /  |/  / ____/  / __ \ |  / / ____/ __ \", 2, true, ConsoleColor.Yellow);
            DrawStringCharByChar(10, 9, @" / / __/ /| | / /|_/ / __/    / / / / | / / __/ / /_/ /", 2, false, ConsoleColor.Yellow);
            DrawStringCharByChar(10, 10,@"/ /_/ / ___ |/ /  / / /___   / /_/ /| |/ / /___/ _, _/ ", 2, true, ConsoleColor.Yellow);
            DrawStringCharByChar(10, 11,@"\____/_/  |_/_/  /_/_____/   \____/ |___/_____/_/ |_|", 3, false, ConsoleColor.Yellow);
            Thread.Sleep(600);
            DrawAt(29, 17, @"(P)lay Again", ConsoleColor.Green);
            DrawAt(29, 19, @"(Q)uit The Game", ConsoleColor.Red);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.P)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }

        }
        /// <summary>
        /// Draw Enter Name screen
        /// </summary>
        public static void EnterName()
        {
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);

            DrawAt(25, 5, @"         ___---___", ConsoleColor.Gray);  
            DrawAt(25, 6, @"      .--\        --. ", ConsoleColor.Gray);
            DrawAt(25, 7, @"    ./.;_.\     __/~ \.", ConsoleColor.Gray);
            DrawAt(25, 8, @"   /;  / `-'  __\    . \", ConsoleColor.Gray);
            DrawAt(25, 9, @"  / ,--'     / .   .;   \", ConsoleColor.Gray);
            DrawAt(25, 10, @" | .|       /       __   |", ConsoleColor.Gray);
            DrawAt(25, 11, @"|__/    __ |  . ;   \ | . |", ConsoleColor.Gray);
            DrawAt(25, 12, @"|      /  \\_    . ;| \___|", ConsoleColor.Gray);
            DrawAt(16, 13, @" ___ _  _ _____ ___ ___   _  _   _   __  __ ___ ", ConsoleColor.Green);
            Thread.Sleep(250);
            DrawAt(16, 14,@"| __| \| |_   _| __| _ \ | \| | /_\ |  \/  | __|", ConsoleColor.Green);
            Thread.Sleep(250);
            DrawAt(16, 15, @"| _|| .` | | | | _||   / | .` |/ _ \| |\/| | _|", ConsoleColor.Green);
            Thread.Sleep(250);
            DrawAt(16, 16, @"|___|_|\_| |_| |___|_|_\ |_|\_/_/ \_\_|  |_|___|", ConsoleColor.Green);
            

        }
        /// <summary>
        /// Draw Load Content screen
        /// </summary>
        public static void LoadContent()
        {
            DrawHLineAt(0, 0, 80, '\u2591', ConsoleColor.Yellow);
            DrawHLineAt(0, 30, 80, '\u2591', ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', ConsoleColor.Yellow);
            DrawVLineAt(0, 0, 31, '\u2591', ConsoleColor.Yellow);

            DrawAt(1, 2, @".                                                               +          ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"                    +                       ~      _________             ", ConsoleColor.Gray);
            DrawAt(1, 4, @"                                          ~  ~   00)__)  .___)           ", ConsoleColor.Gray);
            DrawAt(1, 5, @"      .                ~~        ___   *   ~  ~   _0__)\_/ OOO/`':.       ", ConsoleColor.Gray);
            DrawAt(1, 6, @"                   ~~~  ~~      0)_^'-._    __..-'`:  \ | / ::  \ o`:    ", ConsoleColor.Gray);
            DrawAt(1, 7, @"              +        ~~ ~     0)_\ \~_..-': \ \   :  \|/   ::  |   \   ", ConsoleColor.Gray);
            DrawAt(1, 8, @"                        ~~ .        \ /      : | |  :    :  ::  /  _./>-  ", ConsoleColor.Gray);
            DrawAt(1, 9, @"                                    (__ ))): /_/____.))_____//.-       ", ConsoleColor.Gray);
            DrawAt(1, 10, @"                                          0) ^'-.__      0) ^'-.__        ", ConsoleColor.Gray);
            DrawAt(1, 11, @"      *                                   0)__.-'        0)__.-'          ", ConsoleColor.Gray);
            DrawAt(1, 12, @".        ___-----___                                                    +   ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"     .--\            --.            |                                     ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"  ./.;_.\       __/~    \.         -O-       .              *             *", ConsoleColor.Cyan);
            DrawAt(1, 15, @"  /; / `-'    __\        \          |                                     ", ConsoleColor.Cyan);
            DrawAt(1, 16, @" /,--'       /  .     .;  \                                              ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"| .|        /       __     |.                *                            ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"|__/    __ |  . ;   \ | .  |   .                                 *         ,", ConsoleColor.Cyan);
            DrawAt(1, 19, @"|      /  \\_      ;| \____|                                             ", ConsoleColor.Cyan);
            DrawAt(1, 20, @"|      \  .~\\___,--'      |        o                 +                   ", ConsoleColor.Cyan);
            DrawAt(1, 21, @" \    \   .  .  ; \      /_/ .                                             ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"  \   /         . |      ~/   .                                             ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"   ~\ \   .      /      /~                                +                ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"      ~--___     ___ --~                                                  ", ConsoleColor.Cyan);
            DrawAt(1, 25, @"           ~--__--~                                                        ", ConsoleColor.Cyan);
            DrawAt(20, 27, @"Downloading Content", ConsoleColor.Cyan);
            DrawHLineAt(40, 27, 28, '\u2591', 100, false, ConsoleColor.White);
            DrawAt(35, 22, @"Tip: W,S,D,A - to control the ship,", ConsoleColor.Green);
            DrawAt(45, 23, @"Space - to fire", ConsoleColor.Green);
        }
        /// <summary>
        /// Draw Load Story screen
        /// </summary>
        public static void LoadStory()
        {
            DrawHLineAt(0, 0, 80, '\u2591', ConsoleColor.Yellow);
            DrawHLineAt(0, 30, 80, '\u2591', ConsoleColor.Yellow);
            DrawVLineAt(79, 0, 31, '\u2591', ConsoleColor.Yellow);
            DrawVLineAt(0, 0, 31, '\u2591', ConsoleColor.Yellow);

            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ",ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ",ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ",ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ",ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @" ____^/\___^--___/\_____-^^-^--_______/\ /\---/\___________---/\---_________", ConsoleColor.Green);
            DrawAt(1, 22, @"     -    ---     /\^              ^      ^       ^            ^      /\    ", ConsoleColor.Green);
            DrawAt(1, 23, @"         --       __ _-                     ^                __       --   ", ConsoleColor.Green);
            DrawAt(1, 24, @"   --  __                           ___--  ^  ^                /\^         ", ConsoleColor.Green);
            Thread.Sleep(650);

            DrawAt(16, 8, @"    Planet Murth was completely destroyed", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 9, @"          nothing but ashes remains,", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 10, @"           you are our last hope.", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 11, @"Your goal is to find and destroy evil aliens,", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 12, @"but be prepared they are very strong enemies.", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 13, @" Good luck on your new and though adventure.", ConsoleColor.DarkYellow);
            Thread.Sleep(1050);
            DrawAt(16, 14, @"  And don't be late for the public defence", ConsoleColor.DarkYellow);    
            Thread.Sleep(1350);       
            DrawAt(16, 15, @"                in SoftUni.", ConsoleColor.DarkYellow);
        } 
        #endregion

        #region Clearing Methods

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="x" >Column number</param>
        /// <param name="y" >Row number</param>
        public static void ClearAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="point">Point2D to clear at</param>
        public static void ClearAtPosition(Point2D point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clears an area from given coordinates to given coordinates
        /// </summary>
        /// <param name="fromX"> Starting Column number</param>
        /// <param name="fromY"> Starting Row number</param>
        /// <param name="toX">Ending Column number</param>
        /// <param name="toY">Ending Row number</param>
        public static void ClearFromTo(int fromX, int fromY, int toX, int toY)
        {
            Console.SetCursorPosition(fromX, fromY);
            string x = new string(' ', toX - fromX);
            for (int i = fromY; i < toY; i++)
            {
                Console.WriteLine(x);
            }
        }

       /// <summary>
        /// Clears an area from given coordinates to given coordinates
       /// </summary>
       /// <param name="startingPoint">Starting Point2D</param>
       /// <param name="endingPoint">Ending Point2D</param>
        public static void ClearFromTo(Point2D startingPoint, Point2D endingPoint)
        {
            ClearFromTo(startingPoint.X, startingPoint.Y, endingPoint.X, endingPoint.Y);
        }

        /// <summary>
        /// Clears a whole row at given position
        /// </summary>
        /// <param name="y">Row number</param>
        public static void ClearY(int y)
        {
            int gameWidth = 80; // should be assigned from a constant somewhere
            for (int i = 0; i < gameWidth; i++)
            {
                DrawAt(i, y, ' ');
            }
        }

        /// <summary>
        /// Clears a whole column at given position
        /// </summary>
        /// <param name="x">Column number</param>
        public static void ClearX(int x)
        {
            int gameHeight = 30; // should be assigned from a constant somewhere
            for (int i = 0; i < gameHeight; i++)
            {
                DrawAt(x, i, ' ');
            }
        }
        #endregion      
    }
}
                                                              