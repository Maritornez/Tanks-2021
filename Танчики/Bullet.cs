using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Танчики
{
    class Bullet : GameObject
    {
        public int _damage;
        private int _speed = 10;
        private int _orientation = 0;

        public Bullet(Rectangle rectangle, int damage, int orientation)
        {
            _damage = damage;
            _orientation = orientation;
            _size = new Size(6, 6);

            switch(_orientation)
            {
                case 0: //D
                    _location = new Point(rectangle.Right, rectangle.Top + rectangle.Height / 2 - _size.Height / 2);
                    break;
                case 1: //W
                    _location = new Point(rectangle.Left + rectangle.Width / 2 - _size.Width / 2, rectangle.Top - _size.Height);
                    break;
                case 2: //A
                    _location = new Point(rectangle.Left - _size.Width, rectangle.Top + rectangle.Height / 2 - _size.Height / 2);
                    break;
                case 3: //S
                    _location = new Point(rectangle.Left + rectangle.Width / 2 - _size.Width / 2, rectangle.Bottom);
                    break;
            }
        }

        public void Fly()
        {
            switch(_orientation)
            {
                case 0: //D
                    _location.X += _speed;
                    break;
                case 1: //W
                    _location.Y -= _speed;
                    break;
                case 2: //A
                    _location.X -= _speed;
                    break;
                case 3: //S
                    _location.Y += _speed;
                    break;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), Rectangle);
        }
    }
}
