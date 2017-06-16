using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRunner.HitFields
{
    public interface HitField
    {
        bool CollidesWith(Point offset, HitField hitfield);
    }
}
