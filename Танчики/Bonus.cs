using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Танчики
{
    class Bonus : GameObject
    {
        
        public int BonusType { get; }

        public Bonus(Point point, int boxType)
        {
            _location = point;
            _size = new Size(Field._blockSize, Field._blockSize);
            BonusType = boxType;   //0 - MaxRepairBox
                                   //1 - PlusAttackSpeedBox
                                   //2 - PlusDamageBox
                                   //3 - PlusHealthBox
                                   //4 - PlusMaxHealthBox
                                   //5 - PlusSpeedBox
            switch (BonusType)
            {
                case 0:
                    _bitmap = Resource1.MaxRepairBox;
                    break;

                case 1:
                    _bitmap = Resource1.PlusAttackSpeedBox;
                    break;

                case 2:
                    _bitmap = Resource1.PlusDamageBox;
                    break;

                case 3:
                    _bitmap = Resource1.PlusHealthBox;
                    break;

                case 4:
                    _bitmap = Resource1.PlusMaxHealthBox;
                    break;

                case 5:
                    _bitmap = Resource1.PlusSpeedBox;
                    break;

                default:
                    break;
            }
            _bitmap.MakeTransparent();
        }
    }
}
