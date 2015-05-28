using System;
using System.Collections.Generic;
using System.Threading;
using System.Media;
using System.Windows.Media;
using TeamWork.Objects;
using System.Linq;

namespace TeamWork.Field
{
    public class Engine
    {
        public static Random Rnd = new Random();
        public static Player Player = new Player();
        public bool DrawMenu = false;
        public const int StartingDifficulty = 40;
        public Thread MusicThread; // Background music thread
        public Thread EffectsThread; // Effects music thread

        public const int WindowWidth = 80; //Window Width constant to be accesed from everywhere
        public const int WindowHeight = 32; //Window height constant to be accesed from everywhere

        /// <summary>
        /// Constructor that instantly starts the engine
        /// </summary>
        public Engine()
        {
            this.Start();
        }

        /// <summary>
        /// Gameplay method , containing main game loop and all update calls
        /// </summary>
        public void Start()
        {
            // Starting manu and intro screens
            Menu.StartMenu();
            // Starting main's music thread
            MusicThread = new Thread(LoadMusic);
            MusicThread.Start();
            // Starting effects music thread
            EffectsThread = new Thread(SoundEffects);
            EffectsThread.Start();
            Menu.EntryStoryLine(); // Draw the short story
            Printing.EnterName(); // Draw enter name asset
            TakeName(); // Get the players name
            Thread.Sleep(1000); // Dramatic pause
            while (true) //Main game loop
            {
                Console.Clear(); 
                Player.Print(); // Print the player at his starting position
                Menu.Table(); // Print the UI Table
                Menu.UIDescription(); // Print the UI Description

                while (Player.Lifes > 0) // Gameplay loop that ends when the player has no lifes
                {
                    //ConsoleKey Listener
                    if (Console.KeyAvailable) // Checks if the console buffer has a key press
                    {
                        this.TakeInput(Console.ReadKey(true)); // Passes that key to the TakeInput method
                        while (Console.KeyAvailable) // Get rid of the rest of buffered keys
                        {
                            Console.ReadKey(true);
                        }
                    }

                    UpdateAndRender(); // Update all objects and draw everything again
                    Thread.Sleep(80); // Constant game speed
                }
                Console.Clear();
                //add new high score
                Menu.SetHighscore();
                Printing.GameOver();
                ResetGame();
            }
        }

        public static bool BossActive = false;
        public static Boss boss = new Boss(0); // Static boss object, that can be renewed if needed
        
        /// <summary>
        /// Main method that calls all other calculations and drawing calls
        /// </summary>
        private void UpdateAndRender()
        {
            if (Player.Level % 3 == 2 && BossActive == false) // When to spawn a boss
            {
                BossActive = true;
                
                if (boss.BossLife <= 0)
                {
                    boss = new Boss(0);
                }
            }
            ProjectileMoveAndPrint(); // Move and print projectiles(meteorits, enemy bullets)
            ProjectileCollisionCheck(); // Check for any collisions
            if (BossActive) // If the boss is active, call its AI method
            {
                DrawAndMoveMeteor();
                boss.BossAI();
                foreach (var bullets in _bullets) // Check if the boss is hit
                {
                    if (boss.BossHit(bullets.Point))
                    {
                        bullets.ClearObject(); // Clear the bullet
                        bullets.Point.X += 100; // Move it out of the screen to be deleted.
                    }
                }
            }
            else
            {
                DrawAndMoveMeteor(); 
                GenerateMeteorit(); // Spawn meteorits
            }
        }
        /// <summary>
        /// Sets all the starting values back to default and clears all object collections
        /// </summary>
        private void ResetGame()
        {
            Player.Level = 1;
            Player.Score = 0;
            Player.Lifes = 3;
            Player.Point = Player.PlayerPoint;
            BossActive = false;
            boss = new Boss(0);
            _bullets.Clear();
            _objectProjectiles.Clear();
            _meteorits.Clear();
        }

        /// <summary>
        /// Player move handler
        /// </summary>
        /// <param name="keyPressed"></param>
        private void TakeInput(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.W: Player.MoveUp();
                    break;
                case ConsoleKey.S: Player.MoveDown();
                    break;
                case ConsoleKey.A: Player.MoveLeft();
                    break;
                case ConsoleKey.D: Player.MoveRight();
                    break;
                // Create a new bullet object
                case ConsoleKey.Spacebar:
                    // Add a GameObject to the bullet list with starting position of the players plane nose with type of bullet
                    _bullets.Add(new GameObject(new Point2D(Player.Point.X + 20, Player.Point.Y + 1),0));
                    _playEffect = true; // Play player shooting sound
                    break;
            }
        }

        #region Projectiles

        public static List<GameObject> _objectProjectiles = new List<GameObject>(); // Stores all projectiles
        private List<GameObject> _bullets = new List<GameObject>(); // Stores all bullets fired
        private void ProjectileMoveAndPrint()
        {
            List<GameObject> newProjectiles = new List<GameObject>(); //Stores the new coordinates of the projectiles
            List<GameObject> newBullets = new List<GameObject>(); //Stores the new coordinates of the bullets
            for (int i = 0; i < _objectProjectiles.Count; i++) // Cycle through all projectiles
            {
                // Check if the projectile is out of the screen before it clears it
                if (_objectProjectiles[i].Point.X >= 0) 
                {
                    _objectProjectiles[i].ClearObject();
                }

                if (_objectProjectiles[i].Point.X - _objectProjectiles[i].Speed - 2 <= 0)
                {
                    // If the Projectile exceeds sceen size, dont add it to new Projectiles list
                }
                else
                {
                    _objectProjectiles[i].Point.X -= _objectProjectiles[i].Speed + 2; // Move the projectile # tiles to the left
                    _objectProjectiles[i].PrintObject(); // Print the projectile
                    newProjectiles.Add((_objectProjectiles[i])); // Add it to the new list
                }
            }
            _objectProjectiles = newProjectiles; // Overwrite old projectiles positions with the new ones


            Printing.DrawAt(Player.Point.X + 20, Player.Point.Y + 1, '=', ConsoleColor.DarkCyan); // Fire effect lol
            
            for (int i = 0; i < _bullets.Count; i++) // Cycle through all bullets
            {
                if (_bullets[i].Point.X <= WindowWidth) // Check if the bullet is outside the screen before it clears it
                {
                    _bullets[i].ClearObject();
                }
                // Clear bullet at its current position
                if (_bullets[i].Point.X + _bullets[i].Speed + 1 >= WindowWidth)
                {
                    // If the bullet exceeds sceen size, dont add it to new Bullets list
                }
                else
                {
                    _bullets[i].Point.X += _bullets[i].Speed + 1; // Move the bullet to the right # tiles
                    _bullets[i].PrintObject(); // Print the bullets at their new position;
                    newBullets.Add((_bullets[i])); // Add the moved bullet to the new bullet list
                }
            }
            _bullets = newBullets; // Overwrite global bullets list, with newBullets list
        }
       
        #endregion
        
        #region Object Generator

        /// <summary>
        /// Generate meteorObjects
        /// </summary>
        private List<GameObject> _meteorits = new List<GameObject>();
        private int _counter = 0; // Just a counter
        public static int Chance = StartingDifficulty; // Chance variable 1 per # loops spawn a meteor
        private void GenerateMeteorit()
        {
            if (_counter % Chance == 0)
            {
                // When its time to spawn a meteorit , random its type
                _meteorits.Add(new GameObject(Rnd.Next(1, 7)));
                _counter++;
            }
            else
            {
                _counter++;
            }
        }

        /// <summary>
        /// Print and move meteorites
        /// </summary>
        private void DrawAndMoveMeteor()
        {
            List<GameObject> newMeteorits = new List<GameObject>();
            if (_counter % 1 == 0) // Can be used to make the meteors move slower
            {
                for (int i = 0; i < _meteorits.Count; i++) // Cycle through all meteorits
                {
                    _meteorits[i].ClearObject(); // Clear the meteorit
                    if (_meteorits[i].Point.X - _meteorits[i].Speed <= 1)
                    {
                        // If the meteorit exceeds sceen size, dont add it to new meteorit list
                    }
                    else
                    {
                        // Collision handling
                        if (BulletCollision(_meteorits[i]) || ShipCollision(_meteorits[i])) // Bullet and ship collision check
                        {
                            // If theres a collision with a players bullet, or players ship
                            if (--_meteorits[i].life == 0) // Check if the decreased meteorits life is 0
                            {
                                _meteorits[i].ClearObject(); // Clear the meteorit
                                _playMeteorEffect = true; // Play meteorit explosion effect
                                _meteorits[i].GotHit = true; // Tag the meteorit as hitted
                            }

                            newMeteorits.Add((_meteorits[i])); // Add the meteorit to the new meteorits list

                        }
                        else // If theres no collisions
                        {
                            _meteorits[i].MoveObject(); // Move the meteorit
                            if (!_meteorits[i].toBeDeleted) // Check if the meteorit shouldn't be deleted
                            {
                                _meteorits[i].PrintObject(); // Print it at its new position
                                newMeteorits.Add((_meteorits[i])); // Add it to the new list
                            }
                        }
                    }
                }
                _meteorits = newMeteorits; // Overwrite global meteorit list with new meteorit list

            }
        }
        #endregion

        #region Collision Handling Methods
        /// <summary>
        /// Bullet collision check
        /// </summary>
        /// <param name="obj">Meteorit GameObject</param>
        /// <returns>If any bullet hits a meteorite</returns>
        private bool BulletCollision(GameObject obj)
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (obj.Collided(_bullets[i].Point))
                {
                    Printing.ClearAtPosition(_bullets[i].Point);
                    _bullets.RemoveAt(i);
                    
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Ship collision handling
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If ship was struck by meteorite</returns>
        private static bool ShipCollision(GameObject obj)
        {
            Point2D point = Player.Point;
            if (obj.Collided(point.X + 21, point.Y) || obj.Collided(point.X + 21, point.Y + 1) || // Front collision
                obj.Collided(point.X + 18, point.Y) || obj.Collided(point.X + 15, point.Y) || // Top collision
                obj.Collided(point.X + 11, point.Y) || obj.Collided(point.X + 6, point.Y) ||  // Top collision
                obj.Collided(point.X + 18, point.Y + 1) || obj.Collided(point.X + 15, point.Y + 1) ||// Bottom collision
                obj.Collided(point.X + 11, point.Y + 1) || obj.Collided(point.X + 6, point.Y + 1) || // Bottom collision
                obj.Collided(point.X + 3, point.Y - 1) || obj.Collided(point.X + 3, point.Y + 1)) // Tail collision
            {
                Player.DecreaseLifes();

                Menu.Table();
                Menu.UIDescription();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Projectile collision check
        /// </summary>
        private static void ProjectileCollisionCheck()
        {
            // Get all the bullets that collided and get its index and type
            var hits =
                _objectProjectiles.Select((x, i) => new { Value = x, Index = i })
                    .Where(x => Player.ShipCollided(x.Value.Point)).ToList(); // Invoke ToList method so the querry is executed immediatly

            foreach (var hit in hits) // Go through each collided projectile
            {
                hit.Value.ClearObject(); // Clear the object
                _objectProjectiles.RemoveAt(hit.Index); // Remove the object from the main list based on the index
                Player.Lifes--; // Decrease players lifes(this method is abit slow and the player gets hit twice by single projectile, but thats cool :D
                Menu.Table(); 
                Menu.UIDescription();

            }
        }
        #endregion

        #region Music
        private static bool _playMeteorEffect; // Trigger for meteor effect
        private static bool _playEffect; // Trigger for player laser effect
        public static bool PlayBossHit; // Trigger for boss hit effect
        /// <summary>
        /// Load background music
        /// </summary>
        private static void LoadMusic()
        {
            var sound = new SoundPlayer {SoundLocation = "Resources/STARS.wav"};
            sound.PlayLooping();
        }

        /// <summary>
        /// Play effects based on triggers
        /// </summary>
        private void SoundEffects()
        {

            MediaPlayer soundFx = new MediaPlayer();
            MediaPlayer soundFx2 = new MediaPlayer();
            MediaPlayer soundFx3 = new MediaPlayer();

            while (true)
            {
                if (_playMeteorEffect) // If the trigger is on play the explosion effect
                {
                    soundFx.Open(new Uri("Resources/meteor.wav", UriKind.Relative));

                    soundFx.Volume = 60;
                    soundFx.Play();
                    _playMeteorEffect = false;
                }
                if (_playEffect) // If the trigger is on play the laser effect
                {
                    soundFx2.Open(new Uri("Resources/laser.wav", UriKind.Relative));

                    soundFx2.Volume = 100;
                    soundFx2.Play();
                    _playEffect = false;
                }
                if (PlayBossHit) // If the trigger is on play the laser effect
                {
                    soundFx3.Open(new Uri("Resources/Meow.wav", UriKind.Relative));

                    soundFx3.Volume = 100;
                    soundFx3.Play();
                    PlayBossHit = false;
                }
                Thread.Sleep(80);
            }

        }

        #endregion
        /// <summary>
        /// Take players name
        /// </summary>
        private static void TakeName()
        {
            Console.WriteLine();
            Console.Write("\n\t\t\t\t Name:");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name)|| name.Length >= 10)
            {
                //Print notice and
                //reset the console if the name is empty space
                Console.WriteLine("\t\t\t    Please enter your name!");
                Thread.Sleep(2000);
                Console.Clear();
                Printing.EnterName();
                TakeName();
            }
            //set the correct name
            else
            {
                Player.setName(name);
                Console.Clear();               
            }
        }
    }
}
