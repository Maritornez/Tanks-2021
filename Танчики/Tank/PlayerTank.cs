using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Танчики
{
    class PlayerTank : Tank
    {
        public PlayerTank(Field field, int blockSize, Rectangle rectangle)
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
    }
}
