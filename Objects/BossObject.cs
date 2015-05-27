using System;
using System.ComponentModel;
using System.Data.SqlClient;
using TeamWork.Field;

namespace TeamWork.Objects
{
    public class BossObject : Entity
    {
        public enum ObjectType // Object type
        {
            Rocket,
            Bullet,
            Laser,
            Mine,
            SoundWave // Unused 
        }

        private ObjectType objectType;
        private int lifeOnScreen; // "Frames" on screen

        /// <summary>
        /// BossObject constructor created with starting coordinate(Point2D) and type number 0-3
        /// </summary>
        /// <param name="point"></param>
        /// <param name="type"></param>
        public BossObject(Point2D point, int type)
            : base(point)
        {
            base.Speed = 1;
            base.Point = point;
            objectType = (ObjectType) type;
            // Based on the created type , set different lifeOnScreen values
            switch (objectType)
            {
                case ObjectType.Rocket:
                    lifeOnScreen = 45;
                    break;
                case ObjectType.Bullet:
                    lifeOnScreen = 60;
                    break;
                case ObjectType.Laser:
                    lifeOnScreen = 20;
                    break;
                case ObjectType.Mine:
                    lifeOnScreen = 30;
                    break;
                case ObjectType.SoundWave:
                    lifeOnScreen = 15;
                    break;
            }
        }

        #region Get Methods

        /// <summary>
        /// Get BossObjects LifeOnScreen value
        /// </summary>
        /// <returns>int</returns>
        public int GetLifeOnScreen()
        {
            return lifeOnScreen;
        }

        /// <summary>
        /// Get BossObject type
        /// </summary>
        /// <returns>ObjectType</returns>
        public ObjectType GetObjectType()
        {
            return objectType;
        }

        /// <summary>
        /// Gets all relevant info about this object
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Format("X:{0} Y:{1}\nLife on screen Left:{2}\nType:{3}", this.Point.X, this.Point.Y,
                this.lifeOnScreen, this.objectType);
        }

        #endregion

        /// <summary>
        /// Moves the object based on its type
        /// </summary>
        public void MoveObject()
        {
            int direction = Engine.rnd.Next(1, 4); // Random number, that defines the movement of some object types
            switch (objectType)
            {

                case ObjectType.Rocket:

                    #region Rocket Movement
                    // Rocket movement based on the random number
                    if (direction == 1)
                    {
                        this.Point.X--;
                        this.Point.Y--;
                        lifeOnScreen--;
                    }
                    if (direction == 2)
                    {
                        this.Point.X--;
                        lifeOnScreen--;
                    }
                    if (direction == 3)
                    {
                        this.Point.X--;
                        this.Point.Y++;
                        lifeOnScreen--;
                    }
                    break;

                    #endregion

                case ObjectType.Bullet:

                    #region Bullet Movement
                    // Standard bullet movement
                    this.Point.X -= 2;
                    lifeOnScreen -= 2;
                    break;

                    #endregion

                case ObjectType.Laser:

                    #region Laser Movement
                    
                    if (lifeOnScreen > 8) // Laser chargeup "effect"
                    {
                        if (lifeOnScreen%2 == 0)
                        {
                            this.Point.Y--;
                        }
                        else
                        {
                            this.Point.Y++;
                        }
                    }
                    this.lifeOnScreen--;
                    break;

                    #endregion

                case ObjectType.Mine:

                    #region Mine Movement

                    // Mine object movement, different "speeds" and movements based on the objects left lifeOnScreen value
                    if (lifeOnScreen > 25)
                    {
                        if (direction == 1)
                        {
                            this.Point.X -= 6;
                            this.Point.Y -= 2;
                            lifeOnScreen--;
                        }
                        if (direction == 2)
                        {
                            this.Point.X -= 6;
                            lifeOnScreen--;
                        }
                        if (direction == 3)
                        {
                            this.Point.X -= 6;
                            this.Point.Y += 2;
                            lifeOnScreen--;
                        }
                    }
                    else if (lifeOnScreen > 15)
                    {
                        if (direction == 1)
                        {
                            this.Point.X -= 3;
                            this.Point.Y -= 1;
                            lifeOnScreen--;
                        }
                        if (direction == 2)
                        {
                            this.Point.X -= 3;
                            lifeOnScreen--;
                        }
                        if (direction == 3)
                        {
                            this.Point.X -= 3;
                            this.Point.Y += 1;
                            lifeOnScreen--;
                        }
                    }
                    else if (lifeOnScreen >= 10)
                    {

                        if (lifeOnScreen%2 == 0)
                        {
                            if (direction == 1)
                            {
                                this.Point.X--;
                                this.Point.Y--;
                                lifeOnScreen--;
                            }
                            if (direction == 2)
                            {
                                this.Point.X--;
                                lifeOnScreen--;
                            }
                            if (direction == 3)
                            {
                                this.Point.X--;
                                this.Point.Y++;
                                lifeOnScreen--;
                            }
                        }
                    }
                    lifeOnScreen--;
                    break;

                    #endregion

                case ObjectType.SoundWave: // Unimplemented type

                    #region Soundwave Movement

                    this.Point.X--;
                    lifeOnScreen--;
                    break;

                    #endregion
            }
        }
        
        private int Frames = 1; // "Frames passed used for the explosion effect calculation"

        private bool mineHit, mineHit2, mineHit3, mineHit4; // Triggers for mine explosion particles
        private readonly Point2D diagonalInc = new Point2D(1, 1); // Diagonal helper
        private readonly Point2D diagonalDec = new Point2D(-1, 1); // Diagonal helper

        /// <summary>
        /// Print object based on its type, lifeonscreen
        /// </summary>
        public void PrintObject()
        {
            switch (objectType)
            {
                case ObjectType.Rocket:

                    #region Rocket Print

                    Printing.DrawAt(this.Point, "<>");
                    break;

                    #endregion

                case ObjectType.Bullet:

                    #region Bullet Print

                    Printing.DrawAt(this.Point, '-', ConsoleColor.DarkCyan);
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, '-', ConsoleColor.DarkCyan);
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, '-', ConsoleColor.DarkCyan);
                    break;

                    #endregion

                case ObjectType.Laser:

                    #region Laser Print

                    if (this.lifeOnScreen > 8) // Print chargeup effect
                    {
                        Engine.boss.movealbe = false; // Make the boss imovable while printing the chargeup effect
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y - 1, @"<----.     __ / __   \",
                            ConsoleColor.DarkGray);
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y, @"<----|====O)))==) \) /", ConsoleColor.Gray);
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y + 1, "<----'    `--' `.__,'",
                            ConsoleColor.DarkGray);
                        Console.ResetColor();
                    }
                    else // Print whole laser
                    {
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y - 1,
                            "-------------------------------------------------------<----.", ConsoleColor.DarkGray);
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y,
                            "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~<----|", ConsoleColor.Gray);
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y + 1,
                            "-------------------------------------------------------<----'", ConsoleColor.DarkGray);
                        Console.ResetColor();
                        for (int i = 0; i < 53; i++) 
                        {
                            if (Engine.Player.ShipCollided(Point.X - 50 + i, Point.Y)) // Check if theres a colision with the player in the middle of the laser
                            {
                                break;
                            }
                        }
                        if (lifeOnScreen < 1) // When the laser animation stops, make the boss moveable again
                        {
                            Engine.boss.movealbe = true;
                        }
                    }
                    break;

                    #endregion

                case ObjectType.Mine:

                    #region Mine Print

                    if (this.lifeOnScreen > 6) // Standard print
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, " \u25B2", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point, "\u25C4\u25A0\u25BA", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, " \u25BC", ConsoleColor.Yellow);
                    }
                    else // Print explosion effect
                    {
                        Point2D upRight = this.Point - diagonalDec*Frames;
                        // If the particle hits the player, move it 1000 times to the right so its not printed
                        if (mineHit) upRight.X += 1000;

                        Point2D upLeft = this.Point + diagonalDec*Frames;
                        if (mineHit2) upLeft.X += 1000;

                        Point2D downLeft = this.Point - diagonalInc*Frames;
                        if (mineHit3) downLeft.X += 1000;

                        Point2D downRight = this.Point + diagonalInc*Frames;
                        if (mineHit4) downRight.X += 1000;

                        // If the particle is in the screen boundries , print it
                        if ((upLeft.X > 1 && upLeft.X < 79) && (upLeft.Y > 1 && upLeft.Y < 30))
                        {
                            Printing.DrawAt(upLeft, '*');
                        }
                        if ((upRight.X > 1 && upRight.X < 79) && (upRight.Y > 1 && upRight.Y < 30))
                        {
                            Printing.DrawAt(upRight, '*');
                        }
                        if ((downLeft.X > 1 && downLeft.X < 79) && (downLeft.Y > 1 && downLeft.Y < 30))
                        {
                            Printing.DrawAt(downLeft, '*');
                        }
                        if ((downRight.X > 1 && downRight.X < 79) && (downRight.Y > 1 && downRight.Y < 30))
                        {
                            Printing.DrawAt(downRight, '*');
                        }
                    }
                    break;

                    #endregion

                case ObjectType.SoundWave: // Unimplemented

                    #region SoundWave Print

                    for (int i = 0 - Frames; i < Frames; i++)
                    {
                        if ((this.Point.Y - i > 4 && this.Point.Y + i < Engine.WindowHeight - 4))
                        {
                            Printing.DrawAt(this.Point.X, this.Point.Y - i, "/", ConsoleColor.Gray);
                            Printing.DrawAt(this.Point.X, this.Point.Y + i, "\\", ConsoleColor.Gray);
                        }
                    }
                    Frames++;
                    break;

                    #endregion
            }
        }

        /// <summary>
        /// Clear GameObject based on its type and check for player colision
        /// </summary>
        public void ClearObjectCheckColision()
        {
            switch (objectType)
            {
                case ObjectType.Bullet:

                    #region Bullet Clear
                    // Clear the object 
                    Printing.DrawAt(this.Point.X, this.Point.Y, ' ');
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, ' ');
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, ' ');
                    // Check for collision
                    if (Engine.Player.ShipCollided(this.Point) ||
                        Engine.Player.ShipCollided(Point.X, Point.Y + 1) ||
                        Engine.Player.ShipCollided(Point.X, Point.Y - 1))
                    {
                        // If theres a collision, set this object lifeonscreen to zero
                        this.lifeOnScreen = 0;
                    }
                    break;

                    #endregion

                case ObjectType.Rocket:

                    #region Rocket Clear

                    Printing.DrawAt(this.Point, "  ");
                    if (Engine.Player.ShipCollided(this.Point))
                    {
                        this.lifeOnScreen = 0;
                    }
                    break;

                    #endregion

                case ObjectType.Laser:

                    #region Laser Clear

                    if (this.lifeOnScreen > 5)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 2, "                      ");
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "                      ");
                        Printing.DrawAt(this.Point.X, this.Point.Y, "             ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "              ");
                    }
                    else
                    {
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y - 1,
                            "                                                         ");
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y,
                            "                                                         ");
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y + 1,
                            "                                                         ");
                    }
                    break;

                    #endregion

                case ObjectType.Mine:

                    #region Mine Clear

                    if (this.lifeOnScreen > 6)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "  ");
                        Printing.DrawAt(this.Point, "   ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "  ");
                    }
                    else
                    {
                        Point2D upRight = this.Point - diagonalDec*Frames;
                        if (mineHit) upRight.X += 1000;
                        if (Engine.Player.ShipCollided(upRight)) mineHit = true;

                        Point2D upLeft = this.Point + diagonalDec*Frames;
                        if (mineHit2) upLeft.X += 1000;
                        if (Engine.Player.ShipCollided(upLeft)) mineHit2 = true;

                        Point2D downLeft = this.Point - diagonalInc*Frames;
                        if (mineHit3) downLeft.X += 1000;
                        if (Engine.Player.ShipCollided(downLeft)) mineHit3 = true;

                        Point2D downRight = this.Point + diagonalInc*Frames;
                        if (mineHit4) downRight.X += 1000;
                        if (Engine.Player.ShipCollided(downRight)) mineHit4 = true;

                        if ((upLeft.X > 1 && upLeft.X < 79) && (upLeft.Y > 1 && upLeft.Y < 30))
                        {
                            Printing.DrawAt(upLeft, ' ');
                        }
                        if ((upRight.X > 1 && upRight.X < 79) && (upRight.Y > 1 && upRight.Y < 30))
                        {
                            Printing.DrawAt(upRight, ' ');
                        }
                        if ((downLeft.X > 1 && downLeft.X < 79) && (downLeft.Y > 1 && downLeft.Y < 30))
                        {
                            Printing.DrawAt(downLeft, ' ');
                        }
                        if ((downRight.X > 1 && downRight.X < 79) && (downRight.Y > 1 && downRight.Y < 30))
                        {
                            Printing.DrawAt(downRight, ' ');
                        }
                        Frames++;
                    }
                    break;

                    #endregion

                case ObjectType.SoundWave: // Unimplemented

                    #region SoundWave Clear

                    for (int i = 0; i < Frames; i++)
                    {
                        if ((this.Point.Y - i > 4 && this.Point.Y + i < Engine.WindowHeight - 4))
                        {
                            Printing.DrawAt(this.Point.X, this.Point.Y - i, "  ", ConsoleColor.Gray);
                            Printing.DrawAt(this.Point.X, this.Point.Y + i, "  ", ConsoleColor.Gray);
                        }

                    }
                    break;

                    #endregion
            }
        }
    }
}
