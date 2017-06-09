using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawArena
{
    class Program
    {
        private const char CTL = '┌'; // 0x250C
        private const char CTR = '┐'; // 0x250C
        private const char CBR = '┘'; // 0x250C
        private const char CBL = '└'; // 0x250C

        private const char LH = '─';  // 0x2500
        private const char LV = '│';   // 0x2502

        private const char BL = '░'; // 0x2591 Block - Light
        private const char BM = '▒'; // 0x2592 Block - Medium
        private const char BD = '▓'; // 0x2593 Block - Dark
        private const char BF = '█'; // 0x2588 Block - Full


        private const int VIEWPORT_WIDTH = 140;
        private const int VIEWPORT_HEIGHT = 40;

        static void Main(string[] args)
        {
            Console.SetWindowSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
            for(int x=0;x< VIEWPORT_WIDTH-1; x++)
            {
                int pos = x % 10;
                if( pos == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(pos);
                if (pos == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
            for (int y=1;y< VIEWPORT_HEIGHT-1; y++)
            {
                int pos = y % 10;
                if (pos == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(pos);
                if (pos == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // Fancy Unicode Box
            int origX = 5;
            int origY = 5;
            int width = 10;
            int height = 10;

            string horzLine = new string(LH, width - 2);

            Console.SetCursorPosition(origX, origY);
            Console.Write(CTL + horzLine + CTR);
            for(int y = 1; y<height-1;y++)
            {
                Console.SetCursorPosition(origX, origY + y);
                Console.Write(LV);
                Console.SetCursorPosition(origX + (width - 1), origY + y);
                Console.Write(LV);
            }
            Console.SetCursorPosition(origX, origY + height - 1);
            Console.Write(CBL + horzLine + CBR);


            origX = 20;
            origY = 5;

            // Simple Box
            horzLine = new string(BF, width);
            Console.SetCursorPosition(origX, origY);
            Console.Write(horzLine);
            for (int y = 1; y < height - 1; y++)
            {
                Console.SetCursorPosition(origX, origY + y);
                Console.Write(BF);
                Console.SetCursorPosition(origX + (width - 1), origY + y);
                Console.Write(BF);
            }
            Console.SetCursorPosition(origX, origY + height - 1);
            Console.Write(horzLine);


            origX = 40;
            origY = 5;

            drawBox(origX, origY, width, height);

            origX = 60;
            origY = 5;
            drawLine(origX, origY, origX + width - 1, origY + height - 1);


            origX = 80;
            origY = 5;
            width = 5;
            height = 10;
            drawLine(origX, origY, origX + width - 1, origY + height - 1);

            origX = 100;
            origY = 5;
            width = 10;
            height = 5;
            drawLine(origX, origY, origX + width - 1, origY + height - 1);



            Console.SetCursorPosition(VIEWPORT_WIDTH-1, VIEWPORT_HEIGHT-1);

            Console.ReadKey();
        }

        static void drawBox(int origX, int origY, int height, int width)
        {
            drawLine(origX, origY, origX + width - 1, origY);
            drawLine(origX + width - 1, origY, origX + width - 1, origY + height - 1);
            drawLine(origX + width - 1, origY + height - 1, origX, origY + height - 1);
            drawLine(origX, origY + height - 1, origX, origY);
        }

        static void drawLine(int x1, int y1, int x2, int y2)
        {
            double slope = (double)(y2 - y1) / (double)(x2 - x1);

            if(slope == 0)
            {
                // Special Case - Horz Line
                Console.SetCursorPosition(Math.Min(x1,x2), y1);

                Console.Write(new string(BF, Math.Max(x2 - x1, x1-x2)));
            } else if(Double.IsInfinity(slope))
            {
                // Special Case - Vert Line
                int minY = Math.Min(y1, y2);
                int maxY = Math.Max(y1, y2);
                for (int y = minY; y <= maxY; y++)
                {
                    Console.SetCursorPosition(x1, y);
                    Console.Write(BF);
                }
            } else
            {
                // if it's not a special case, then we need to calculate based on the outside edges of the boxes at the coorinates, so Width+1, Height+1
                slope = ((double)(y2 - y1) + (y1 < y2 ? 1 : -1)) / ((double)(x2 - x1) + (x1 < x2 ? 1 : -1));


                if ( Math.Abs(x2 - x1) > Math.Abs(y2 - y1) )
                {
                    int dir = x1 < x2 ? 1 : -1;
                    for (int x = x1; x != x2 + dir; x += dir)
                    {
                        // y1 - y2 = m ( x1 - x2 )
                        // -y2 = m ( x1 - x2 ) - y1
                        // y2 = -m ( x1 - x2 ) + y1

                        int y = (int)((-slope * (x1 - x) + y1));
                        Console.SetCursorPosition(x, y);
                        Console.Write(BF);
                    }
                } else
                {
                    int dir = y1 < y2 ? 1 : -1;
                    for (int y = y1; y != y2 + dir; y += dir)
                    {
                        //          y1 - y2              = m ( x1 - x2 )
                        //        ( y1 - y2 ) / m        = x1 - x2
                        //      ( ( y1 - y2 ) / m ) - x1 =    - x2
                        // -1 * ( ( y1 - y2 ) / m ) - x1 =      x2
                        //      x1 - ( ( y1 - y2 ) / m ) =      x2

                        int x = (int)(x1 - ((y1 - y) / slope));
                        Console.SetCursorPosition(x, y);
                        Console.Write(BF);
                    }

                }

            }
        }
    }
}
