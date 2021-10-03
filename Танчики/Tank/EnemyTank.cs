using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Танчики
{
    class EnemyTank : Tank
    {
        private int _randomTime = 0; //Время, которое танк едет в одном направлении
        private int _countDrive = 0;
        protected int _minTimeToGo;
        protected int _maxTimeToGo;
        private Random random;


        public EnemyTank(Field field, int blockSize, Rectangle spawnPlace, int level) 
            : base(field, blockSize)
        {
            _location = spawnPlace.Location;
            random = new Random();
            switch (level)
            {
                case 0:
                    _bitmap = Resource1.EasyEnemyTank;
                    _bitmap.MakeTransparent();
                    _health = 2;
                    _speed = 3;
                    _damage = 1;
                    _attackSpeed = 10;
                    _minTimeToGo = 40;
                    _maxTimeToGo = 80;
                    break;

                case 1:
                    _bitmap = Resource1.HardEnemyTank;
                    _bitmap.MakeTransparent();
                    _health = 5;
                    _speed = 1;
                    _damage = 2;
                    _attackSpeed = 10;
                    _minTimeToGo = 50;
                    _maxTimeToGo = 90;
                    break;

                default:
                    break;
            }
        }

        public override void Drive()
        {
            if (_countDrive == _randomTime)
            {
                _countDrive = 0;
                _randomTime = random.Next(_minTimeToGo, _maxTimeToGo + 1);
                int k = random.Next(0, 11);
                switch (k)
                {
                    case 0:
                        VirtualKey = Keys.D;
                        break;
                    case 1:
                        VirtualKey = Keys.W;
                        break;
                    case 2:
                        VirtualKey = Keys.A;
                        break;
                    case 3:
                        VirtualKey = Keys.S;
                        break;
                    case 4:
                        VirtualKey = Keys.None;
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        VirtualKey = Keys.Space;
                        _countDrive = _randomTime - 1;
                        break;
                }
            }
            _countDrive++;



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
        }        
    }
}
