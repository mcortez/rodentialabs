using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Unicode for Consolas TrueType Font
            // http://www.alanwood.net/unicode/fonts_windows.html#consolas
            //
            // http://www.fileformat.info/info/unicode/font/consolas/grid.htm
            //
            // Unicode for Courier New Font
            // http://www.fileformat.info/info/unicode/font/courier_new/grid.htm



            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Box Drawing
            // https://en.wikipedia.org/wiki/Box_Drawing
            Console.WriteLine("Box Drawing");
            for (var i = 0x2500; i <= 0x257F; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Block Elements
            // https://en.wikipedia.org/wiki/Block_Elements
            Console.WriteLine("Block Elements");
            for (var i = 0x2580; i <= 0x259F; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Geometric Shapes
            // https://en.wikipedia.org/wiki/Geometric_Shapes
            Console.WriteLine("Geometric Shapes");
            for (var i = 0x25A0; i <= 0x25FF; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Misc Symbols
            // https://en.wikipedia.org/wiki/Miscellaneous_Symbols
            Console.WriteLine("Misc Symbols");
            for (var i = 0x2600; i <= 0x26FF; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Dingbats Symbols
            // https://en.wikipedia.org/wiki/Dingbat#Unicode
            Console.WriteLine("Misc Symbols");
            for (var i = 0x2700; i <= 0x27BF; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Emoticons
            // https://en.wikipedia.org/wiki/Emoticons_(Unicode_block)
            Console.WriteLine("Emoticons");
            for (var i = 0x1F600; i <= 0x1F64F; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Transport and Map Symbols
            // https://en.wikipedia.org/wiki/Transport_and_Map_Symbols
            Console.WriteLine("Transport and Map Symbols");
            for (var i = 0x1F680; i <= 0x1F6FF; i++)
            {
                Console.Write((char)(i));
                if (i % 50 == 0)
                { // break every 50 chars
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();




            Console.ReadKey();
        }
    }
}
