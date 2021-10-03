using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Танчики
{
    class PlayerTank2 : Tank
    {
        public event Handler DriveNotify2;
        
        public PlayerTank2(Field field, int blockSize, Rectangle rectangle)
            : base(field, blockSize)
        {
            _bitmap = Resource1.PlayerTank;
            _bitmap.MakeTransparent();
            _health = 5;
            _maxHealth = _health;
            _speed = 5;
            _damage = 1;
            _attackSpeed = 20;
            _spawnPlace = rectangle;
            _location = _spawnPlace.Location;
            //public virtual event Action<Bullet> FireNotify;
            //public delegate void Handler();
            

            DriveNotify2 += () =>
            {
                switch (VirtualKey)
                {
                    case Keys.Up:
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
                    case Keys.Left:
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
                    case Keys.Down:
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
                    case Keys.Right:
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

        public override void BonusEffect(Bonus bonus)
        {
            if (bonus.BonusType == 0)
            {
                _health = _maxHealth;
            }

            if (bonus.BonusType == 1)
            {
                _attackSpeed++;
            }

            if (bonus.BonusType == 2)
            {
                _damage++;
            }

            if (bonus.BonusType == 3)
            {
                _health += _health / 30;
            }

            if (bonus.BonusType == 4)
            {
                _maxHealth++;
            }

            if (bonus.BonusType == 5)
            {
                _speed++;
            }
        }

        public override void Drive()
        {
            DriveNotify2?.Invoke();
        }
    }
}
