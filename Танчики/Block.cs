using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Танчики
{
    class Block : GameObject
    {
        public int BlockType { get; }

        public Block(Point point, int blockSize, int typeOfBlock)
        {
            _location = point;
            _size = new Size(blockSize, blockSize);
            BlockType = typeOfBlock;

            switch (typeOfBlock)
            {
                case 0: //кирпичная стена
                    _bitmap = Resource1.BrickBlock;
                    break;

                case 1: //водная преграда
                    _bitmap = Resource1.WaterBlock;
                    break;

                default:
                    break;
            }
        }
    }
}
