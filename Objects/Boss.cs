using System;
using System.Collections.Generic;
using System.Windows.Media;
using TeamWork.Field;

namespace TeamWork.Objects
{
    public class Boss : Entity
    {
        public enum BossType
        {
            WierdGuy,
        }

        public bool Movealbe = true; // Tag for making the boss imovable
        public int BossLife; // Boss lifepoints
        private BossType bossType; // Type(only one atm)
        
        /// <summary>
        /// Create a boss object from a given type
        /// </summary>
        /// <param name="type">Type</param>
        public Boss(int type)
        {
            bossType = (BossType) type;
            this.Point = new Point2D(58,14);
            switch (bossType)
            {
                    case BossType.WierdGuy:
                    BossLife = 40;
                    break;
            }
        }
        /// <summary>
        /// Draw boss player
        /// </summary>
        private void BossPrint()
        {
            Printing.DrawAt(this.Point.X+13, this.Point.Y - 12, @",");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 11, @"/(");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 10, @"\ \___   /");
            Printing.DrawAt(this.Point.X+12, this.Point.Y - 9, @"/- _  `-/");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 8, @"(/\/ \ \");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 7, @"/ /   | `");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 6, @"O O   ) /");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 5, @"`-^--'`<");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 4, @"(_.)  _  )");
            Printing.DrawAt(this.Point.X+11, this.Point.Y - 3, @"`.___/`");
            Printing.DrawAt(this.Point.X+13, this.Point.Y - 2, @"`-----' /");
            Printing.DrawAt(this.Point.X, this.Point.Y - 1, @"<----.     __ / __   \");
            Printing.DrawAt(this.Point,                     @"<----|====O)))==) \) /");
            Printing.DrawAt(this.Point.X, this.Point.Y+1,   @"<----'    `--' `.__,'");
            Printing.DrawAt(this.Point.X+13, this.Point.Y+2,   @"|");
            Printing.DrawAt(this.Point.X+14, this.Point.Y+3,   @"\");
            Printing.DrawAt(this.Point.X+9, this.Point.Y+4,   @"______( (_  /");
            Printing.DrawAt(this.Point.X+7, this.Point.Y+5,   @",'  ,-----'   |");
            Printing.DrawAt(this.Point.X+7, this.Point.Y+6,   @"`--{__________)");
        }
        /// <summary>
        /// Clear boss player 
        /// </summary>
        private void BossClear()
        {
            Printing.DrawAt(this.Point.X + 13, this.Point.Y - 12, @" ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 11, @"  ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 10, @"          ");
            Printing.DrawAt(this.Point.X + 12, this.Point.Y - 9, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 8, @"        ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 7, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 6, @"         ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 5, @"        ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 4, @"          ");
            Printing.DrawAt(this.Point.X + 11, this.Point.Y - 3, @"       ");
            Printing.DrawAt(this.Point.X + 13, this.Point.Y - 2, @"         ");
            Printing.DrawAt(this.Point.X     , this.Point.Y - 1, @"                      ");
            Printing.DrawAt(this.Point.X     , this.Point.Y,     @"                      ");
            Printing.DrawAt(this.Point.X     , this.Point.Y + 1, @"                     ");
            Printing.DrawAt(this.Point.X + 13, this.Point.Y + 2, @" ");
            Printing.DrawAt(this.Point.X + 14, this.Point.Y + 3, @" ");
            Printing.DrawAt(this.Point.X + 9 , this.Point.Y + 4, @"             ");
            Printing.DrawAt(this.Point.X + 7 , this.Point.Y + 5, @"               ");
            Printing.DrawAt(this.Point.X + 7 , this.Point.Y + 6, @"               ");
        }

        private List<BossObject> bossGameObjects = new List<BossObject>(); // Boss spawned objects
        private int _counter = 1; // Counter
        private int chance = 30; // Chance to spawn a object 1 in # times
        private bool _entryAnimationPlayed = false; // Tag to tell if the starting animation is played
        
        /// <summary>
        /// Boss AI, all movement and boss object spawning is calculated here
        /// </summary>
        public void BossAI()
        {
            if (!_entryAnimationPlayed) // If the animation is not played yet
            {

                BossEntryAnimation(); // Play it
                _entryAnimationPlayed = true; // And trigger the entryAnimation tag
            }
            if (this.BossLife <= 0) // If the boss has no life left
            {
                Engine.BossActive = false; // Trigger the boss active boolean in Engine class
                //Clear all Boss spawned objects from the screen
                foreach (var bossGameObject in bossGameObjects)
                {
                    bossGameObject.ClearObjectCheckColision();
                }
                MediaPlayer death = new MediaPlayer();
                death.Open(new Uri("Resources/cat.wav", UriKind.Relative));
                death.Play();
                BossDeathAnimation(); // Play the boss death "animation"
                Engine.Player.IncreasePoints(90); // Increase player points by 90
                Menu.UIDescription(); // Redraw the UI Description
                return;
            }
            
            // If its time to spawn a new object
            if (_counter % chance == 0)
            {
                // Get a random type and pass it to the switch
                int type = Engine.Rnd.Next(0, 4);
                switch (type)
                {
                    // Create 10 rockets
                    case 0: 
                        for (int i = 0; i < 10; i++)
                        {
                            bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y + Engine.Rnd.Next(-5,5)), type));
                        }
                        break;
                    // Create bullets from the trident
                    case 1: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    // Create Laser
                    case 2: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    // Create a Mine
                    case 3: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                    // Create a soundwave (unimplemented)
                    case 4: bossGameObjects.Add(new BossObject(new Point2D(this.Point.X - 5, this.Point.Y), type));
                        break;
                }
            }
            _counter++;
            // Random number to decide should the boss move
            int move = Engine.Rnd.Next(0, 100);
            if (move > 20 && move < 30 && Movealbe && this.Point.Y + 1 <= Engine.WindowHeight - 9)
            {
                BossClear();
                this.Point.Y++;
            }
            if (move > 80 && move < 90 && Movealbe && this.Point.Y - 1 >= 14)
            {
                BossClear();
                this.Point.Y--;
            }
            // Print the boss
            BossPrint();
            BossObjectsMoveAndDraw();
            
        }

        /// <summary>
        /// Move and draw the boss objects
        /// </summary>
        private void BossObjectsMoveAndDraw()
        {
            List<BossObject> newObjects = new List<BossObject>(); // List of the moved objects
            foreach (var bossGameObject in bossGameObjects) // Itterate through all current objects
            {
                bossGameObject.ClearObjectCheckColision(); // Clear from the screen and check for collision with the player
                
                // if the object life is 0 or less, or its out of the screen
                if (bossGameObject.GetLifeOnScreen() <= 0 ||
                    (bossGameObject.Point.X < 5 || bossGameObject.Point.X > Engine.WindowWidth -5 || bossGameObject.Point.Y < 3 || bossGameObject.Point.Y >= Engine.WindowHeight - 3))
                {
                    // Don't add it to the list with the moved objects
                }
                else
                {
                    // Move the object
                    bossGameObject.MoveObject();
                    // Print it at its new position
                    bossGameObject.PrintObject();
                    // Add it to the list with moved objects
                    newObjects.Add(bossGameObject);
                } 
            }
            bossGameObjects = newObjects; // Overwrite old objects with the moved ones
        }

        /// <summary>
        /// Boss collision check
        /// </summary>
        /// <param name="point">Point2D to check with</param>
        /// <returns>If the boss is hit</returns>
        public bool BossHit(Point2D point ) 
        {
            if (((point.X == this.Point.X + 13 || point.X == this.Point.X + 14) && point.Y == this.Point.Y - 12) ||
                ((point.X >= this.Point.X + 12 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 11) ||
                ((point.X >= this.Point.X + 12 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 10) ||
                ((point.X >= this.Point.X + 12 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 9) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 8) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 7) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 6) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 5) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 4) ||
                ((point.X >= this.Point.X + 11 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 3) ||
                ((point.X >= this.Point.X + 13 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y - 2) ||
                ((point.X >= this.Point.X + 0  && point.X <= this.Point.X + 30) && point.Y == this.Point.Y - 1) ||
                ((point.X >= this.Point.X + 0  && point.X <= this.Point.X + 30) && point.Y == this.Point.Y - 0) ||
                ((point.X >= this.Point.X + 0  && point.X <= this.Point.X + 30) && point.Y == this.Point.Y + 1) ||
                ((point.X >= this.Point.X + 13 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y + 2) ||
                ((point.X >= this.Point.X + 14 && point.X <= this.Point.X + 20) && point.Y == this.Point.Y + 3) ||
                ((point.X >= this.Point.X + 9  && point.X <= this.Point.X + 20) && point.Y == this.Point.Y + 4) ||
                ((point.X >= this.Point.X + 7  && point.X <= this.Point.X + 20) && point.Y == this.Point.Y + 5) ||
                ((point.X >= this.Point.X + 7  && point.X <= this.Point.X + 20) && point.Y == this.Point.Y + 6))
            {
                this.BossLife--; // Decrease boss life
                Engine.PlayBossHit = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Boss death "Animation"
        /// </summary>
        private void BossDeathAnimation()
        {
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 12, @" ",5,false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 11, @"  ",5,true);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 10, @"          ",5,false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 9, @"         ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 8, @"        ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 7, @"         ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 6, @"         ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 5, @"        ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 4, @"          ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 3, @"       ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 2, @"         ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y - 1, @"                      ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y, @"                      ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y + 1, @"                     ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y + 2, @" ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 14, this.Point.Y + 3, @" ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 9, this.Point.Y + 4, @"             ", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 5, @"               ", 5, true);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 6, @"               ", 5, false);
        }

        /// <summary>
        /// Boss Entry "Entry animation"
        /// </summary>
        private void BossEntryAnimation()
        {
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 12, @",", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 11, @"/(", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 10, @"\ \___   /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 12, this.Point.Y - 9, @"/- _  `-/", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 8, @"(/\/ \ \", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 7, @"/ /   | `", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 6, @"O O   ) /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 5, @"`-^--'`<", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 4, @"(_.)  _  )", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 11, this.Point.Y - 3, @"`.___/`", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y - 2, @"`-----' /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y - 1, @"<----.     __ / __   \", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y, @"<----|====O)))==) \) /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X, this.Point.Y + 1, @"<----'    `--' `.__,'", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 13, this.Point.Y + 2, @"|", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 14, this.Point.Y + 3, @"\", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 9, this.Point.Y + 4, @"______( (_  /", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 5, @",'  ,-----'   |", 5, false);
            Printing.DrawStringCharByChar(this.Point.X + 7, this.Point.Y + 6, @"`--{__________)", 5, false);
        }
    }
}
  
