using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Threading;

namespace SimpleRunner
{
    class Program
    {
        static Player player = new Player();

        static Point up = new Point { X = 0, Y = -1 };
        static Point down = new Point { X = 0, Y = 1 };
        static Point left = new Point { X = -1, Y = 0 };
        static Point right = new Point { X = 1, Y = 0 };

        static Random random = new Random();


        static void Main(string[] args)
        {
            int targetFrameMilli = 1000 / 60; //60 FPS

            Console.CursorVisible = false;

            bool exitGame = false;

            PlayField.Init(140, 40);

            PlayField.TrySetGameObjectLocation(new Wall(140,1), new Point(0, 0));
            PlayField.TrySetGameObjectLocation(new Wall(1, 38), new Point(0, 1));
            PlayField.TrySetGameObjectLocation(new Wall(1, 38), new Point(139, 1));
            PlayField.TrySetGameObjectLocation(new Wall(140, 1), new Point(0, 39));



            Wall w = new Wall(20, 1);
            PlayField.TrySetGameObjectLocation(w, new Point(10, 10));

            PlayField.TrySetGameObjectLocation(player, new Point(random.Next(2, 138), random.Next(2, 38)));

            PlayField.RenderPlayField();



             

            ConsoleKeyInfo currentKey;
            Stopwatch sw = new Stopwatch();
            do
            {
                sw.Restart();
                if(Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey(true);

                    switch(currentKey.Key)
                    {
                        case ConsoleKey.Escape:
                            exitGame = true;
                            break;

                        case ConsoleKey.W:
                            MovePlayer(up);
                            break;

                        case ConsoleKey.A:
                            MovePlayer(left);
                            break;

                        case ConsoleKey.S:
                            MovePlayer(down);
                            break;

                        case ConsoleKey.D:
                            MovePlayer(right);
                            break;

                    }
                }

                // TODO: use the Stop Watch as a tripwire counter, instead of sleeping 
                // every game loop to make the loop exactly 1/60th of a second long
                // instead each time an appropriate amount of time has passed, advance
                // physics one step -- however much that is.
                //
                // then use the console key reading to set the "state" of movement, 
                // so if the "UP" key is currently held, just set the current movement
                // vector to the "up" vector.  Then when the tripwire activates it'll 
                // move the player in that direction.  If no console key is set during any given 
                // loop, then set the movement vector to (0,0) or null or whatever

                PlayField.RenderPlayField();

                /*
                sw.Stop();
                if( sw.ElapsedMilliseconds < targetFrameMilli)
                {
                    Thread.Sleep((int)(targetFrameMilli - sw.ElapsedMilliseconds));
                }
                */
            } while (!exitGame);
        }

        static void MovePlayer(Point direction)
        {
            if(PlayField.TryMoveGameObject(player, direction) == false)
            {
                // Possibly do something useful here.
                //Console.Beep();
            }
        }
    }
}
