using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayField
{
    class Program
    {
        static void Main(string[] args)
        {
            int viewPortWidth = 140;
            int viewPortHeight = 40;

            Cell[,] playField = new Cell[viewPortWidth, viewPortHeight];
            Array.Clear(playField, 0, playField.Length);
            Console.SetWindowSize(viewPortWidth + 1, viewPortHeight + 1);

            do
            {

                Random r = new Random();

                Array consoleColors = Enum.GetValues(typeof(ConsoleColor));

                for (int x = 0; x < viewPortWidth; x++)
                {
                    for (int y = 0; y < viewPortHeight; y++)
                    {
                        char c = (char)('0' + (char)(r.Next(26)));
                        playField[x, y] = new Cell();
                        playField[x, y].Char = c;

                        //playField[x, y].CharForegroundColor = r.Next(2) == 0 ? ConsoleColor.Black : ConsoleColor.White;
                    }
                }

                Console.SetCursorPosition(0, 0);

                StringBuilder sb = new StringBuilder(viewPortWidth);
                for (int y = 0; y < viewPortHeight; y++)
                {
                    for (int x = 0; x < viewPortWidth; x++)
                    {
                        if( Console.ForegroundColor != playField[x, y].CharForegroundColor 
                            || Console.BackgroundColor != playField[x, y].CharBackgroundColor )
                        {
                            Console.Write(sb.ToString());
                            Console.ForegroundColor = playField[x, y].CharForegroundColor;
                            Console.BackgroundColor = playField[x, y].CharBackgroundColor;
                            sb.Clear();
                        }
                        sb.Append(playField[x, y].Char);
                    }
                    sb.AppendLine();
                }
                Console.Write(sb.ToString());



            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
