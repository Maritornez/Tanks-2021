using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Танчики
{
    public static class RectanglExtension
    {
        public static bool IsCrossed(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left < r2.Right && r1.Right > r2.Left &&
                    r1.Top < r2.Bottom && r1.Bottom > r2.Top);
        }
    }
}


