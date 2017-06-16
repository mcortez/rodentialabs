using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner.HitFields
{
    public class HitFieldPoint : HitField
    {

        public bool CollidesWith(Point offset, HitField hitfield)
        {
            if( hitfield is HitFieldPoint )
            {
                return offset.X == 0 && offset.Y == 0;
            }

            return false;
        }
    }
}
