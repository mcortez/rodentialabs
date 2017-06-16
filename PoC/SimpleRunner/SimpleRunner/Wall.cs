using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner
{
    public class Wall : GameObject
    {
        private int _width;
        public int Width
        {
            get { return _width; }
        }

        private int _height;
        public int Height
        {
            get { return _width; }
        }

        public Wall(int width, int height) 
        {
            base.Symbol = '#';

            _width = width;
            _height = height;

            BoundingBox = new Point(_width, _height) ;
        }

        public override string[] getRendering(int frame)
        {
            string[] rendering = new string[_height];
            for(int i = 0; i < _height; i++)
            {
                rendering[i] = new string(Symbol, _width);
            }

            return rendering;
        }
    }
}
