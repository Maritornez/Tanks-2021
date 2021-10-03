using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace Танчики
{
    abstract class Tank : GameObject
    {
        protected Field _field;
        protected int _orientation = 1;
        public int _health;
        protected int _maxHealth;
        protected int _damage;
        protected int _speed;
        public int _counterTick = 0;
        public int _attackSpeed = 15; //Чем меньше, тем быстрее
        public virtual event Action<Bullet> FireNotify;
        public delegate void Handler();
        public event Handler DriveNotify;
        public Rectangle _spawnPlace;
        public Keys VirtualKey { get; set; } = Keys.None;




        public Tank(Field field, int blockSize)
        {
            _field = field;
            _size = new Size(blockSize, blockSize);
            DriveNotify += () =>
            {
                switch (VirtualKey)
                {
                    case Keys.W:
                        switch (_orientation)
                        {
                            case 0:
                                _bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            case 2:
                                _bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case 3:
                                _bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                        }
                        _orientation = 1;
                        _location.Y -= _speed;
                        break;
                    case Keys.A:
                        switch (_orientation)
                        {
                            case 0:
                                _bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case 1:
                                _bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                            case 3:
                                _bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                        }
                        _orientation = 2;
                        _location.X -= _speed;
                        break;
                    case Keys.S:
                        switch (_orientation)
                        {
                            case 0:
                                _bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case 1:
                                _bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case 2:
                                _bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                        }
                        _orientation = 3;
                        _location.Y += _speed;
                        break;
                    case Keys.D:
                        switch (_orientation)
                        {
                            case 1:
                                _bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case 2:
                                _bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case 3:
                                _bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                        }
                        _orientation = 0;
                        _location.X += _speed;
                        break;
                }
            };
        }

        public void DamageToTank(Bullet bullet)
        {
            _health -= bullet._damage;
        }

        public virtual void Drive()
        {
            //Изменение рисунка в зависимости от ориентации танка в пространстве
            //и изменение иго координат
            DriveNotify?.Invoke();
        }

        //Обработка выхода танчика за пределы поля
        public bool LimitPos()
        {
            bool b;
            b = false;
            if (_location.X > _field._size.Width - _size.Width)
            {
                _location.X = _field._size.Width - _size.Width;
                b = true;
            }
            if (_location.X < 0)
            {
                _location.X = 0;
                b = true;
            }
            if (_location.Y > _field._size.Height - _size.Width)
            {
                _location.Y = _field._size.Height - _size.Width;
                b = true;
            }
            if (_location.Y < 0)
            {
                _location.Y = 0;
                b = true;
            }
            return b;
        }

        public void Fire()
        {
            FireNotify?.Invoke(new Bullet(Rectangle, _damage, _orientation));
        }

        public virtual void BonusEffect(Bonus box) { }
    }
}
