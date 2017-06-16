using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner
{
    public class GameObject
    {
        public char Symbol
        { get; set; }

        public Point BoundingBox
        {
            get; set;
        }

        public GameObject()
        {
            BoundingBox = new Point(1, 1);
        }

        public virtual string[] getRendering(int frame)
        {
            return new string[] { new string(Symbol,1) };
        }
    }
}
