using System;

namespace PlayField
{
    public class Cell
    {
        public char Char
        { get; set; }

        public ConsoleColor CharForegroundColor
        { get; set; }

        public ConsoleColor CharBackgroundColor
        { get; set; }

        public Cell()
        {
            Char = ' ';
            CharForegroundColor = ConsoleColor.White;
            CharBackgroundColor = ConsoleColor.Black;
        }
    }
}
