using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Танчики
{
    abstract class GameObject
    {
        public Point _location;
        public Size _size;
        public Rectangle Rectangle { get => new Rectangle(_location, _size); }
        public Bitmap _bitmap;

        public virtual void Draw(Graphics graphics)
        {
            graphics.DrawImage(_bitmap, Rectangle);
        }
    }
}
