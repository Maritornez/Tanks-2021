using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;




namespace Танчики
{
    class Field : GameObject
    {
        //private Form1 _form1;
        public static int _indentDown = 80; //Отступ снизу

        private List<Bullet> playerBullets;
        private List<Bullet> enemyBullets;
        public List<Tank> tanks; //tank[0] и tanks[1] - танки игрока
        private int[,] map; //Карта поля для размещения блоков
        private Block[,] blocks;
        private List<Bonus> bonuses;
        private bool _twoPlayersMode;
        private int _playerCount = 1;

        private Rectangle _spawnPlace1; //Левый верхний угол
        private Rectangle _spawnPlace2; //Правый верхний угол
        private Rectangle _spawnPlace3; //Левый нижний угол
        private Rectangle _spawnPlace4; //Правый нижний угол

        public int _score = 0;
        public event Action GameOver;
        public static int _blockSize = 50;
        private const int _widthBlocks = 16; //Количество блоков по ширине
        private const int _heightBlocks = 12; //Количество блоков по высоте

        private int _tanksInterval = 0; //Интервал между спавнами союзников по оси x
        private int _boxAmount = 6; //Количество видов бонусов
        private int _bonusSpawnFrequency = 4; //Частота появления бонусов
        private int _timeSpawnEnemyEasy = 120;  // Спавн легкого врага, когда счетчик _countSpawn достигает этого числа
        private int _countSpawnEasy = 0;
        private int _timeSpawnEnemyHard = 400; // Спавн тяжелога врага, когда счетчик _countSpawn достигает этого числа
        private int _countSpawnHard = 0;

        public bool is1Fire = false;
        public bool is2Fire = false;




        public Field(Form1 form1, bool isTwoPlayers)
        {
            _location = new Point(0, 0);
            _size = new Size(form1.ClientRectangle.Width, form1.ClientRectangle.Height - _indentDown); //800x600
            _bitmap = Resource1.Ground;
            //_form1 = form1;
            _spawnPlace1 = new Rectangle(0, 0, _blockSize, _blockSize);
            _spawnPlace2 = new Rectangle(_size.Width - _blockSize, 0, _blockSize, _blockSize);
            _spawnPlace3 = new Rectangle(0, _size.Height - _blockSize, _blockSize, _blockSize);
            _spawnPlace4 = new Rectangle(_size.Width - _blockSize, _size.Height - _blockSize, _blockSize, _blockSize);
            _twoPlayersMode = isTwoPlayers;
            map = new int[_heightBlocks, _widthBlocks] {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                /*0 - отсутствие блока*/                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                /*1 - кирпичная стена*/                 {0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                /*2 - ров с водой*/                     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

            //Инициализируем матрицу блоков
            blocks = new Block[_heightBlocks, _widthBlocks];
            for (int i = 0; i < _heightBlocks; i++) //y
            {
                for (int j = 0; j < _widthBlocks; j++) //x
                {
                    //Кирпичная стена
                    if (map[i, j] == 1)
                    {
                        blocks[i, j] = new Block(new Point(j * _blockSize, i * _blockSize), _blockSize, 0);
                    }

                    //Ров с водой
                    if (map[i, j] == 2)
                    {
                        blocks[i, j] = new Block(new Point(j * _blockSize, i * _blockSize), _blockSize, 1);
                    }
                }
            }

            playerBullets = new List<Bullet>();
            enemyBullets = new List<Bullet>();
            tanks = new List<Tank>();
            //blocks = new List<Block>();
            bonuses = new List<Bonus>();

            if (_twoPlayersMode)
            {
                _tanksInterval = 100;
            }
            //Создание танка игрока 0
            tanks.Add(new PlayerTank(this, _blockSize, new Rectangle
                                    (_size.Width / 2 - _blockSize / 2 - _tanksInterval / 2, 
                                    _size.Height / 2 - _blockSize / 2,
                                    _blockSize, _blockSize)));
            tanks[0].FireNotify += (bullet) => { playerBullets.Add(bullet); };

            if (_twoPlayersMode)
            {
                _playerCount = 2;
                //Создание танка игрока 1
                tanks.Add(new PlayerTank2(this, _blockSize,new Rectangle
                                    (_size.Width / 2 - _blockSize / 2 + _tanksInterval / 2,
                                    _size.Height / 2 - _blockSize / 2,
                                    _blockSize, _blockSize)));
                tanks[1].FireNotify += (bullet) => { playerBullets.Add(bullet); };
            }
        }

        public void Tick()
        {
            //Обработка движения танчика игрока 0
            //if (_form1.is1Up) tanks[0].Drive(Keys.W);
            //else if (_form1.is1Left && !_form1.is1Down) tanks[0].Drive(Keys.A);
            //if (_form1.is1Down) tanks[0].Drive(Keys.S);
            //else if (_form1.is1Right && !_form1.is1Up) tanks[0].Drive(Keys.D);

            /*
            tanks[0].VirtualKey = Keys.None;
            if (_form1.is1Up) tanks[0].VirtualKey = Keys.W;
            if (_form1.is1Left) tanks[0].VirtualKey = Keys.A;
            if (_form1.is1Down) tanks[0].VirtualKey = Keys.S;
            if (_form1.is1Right) tanks[0].VirtualKey = Keys.D;
            */
            tanks[0].Drive();


            //Обработка огня танчика игрока 0
            if (tanks[0]._counterTick >= tanks[0]._attackSpeed && is1Fire)
            {
                tanks[0]._counterTick = 0;
                tanks[0].Fire();
            }
            tanks[0]._counterTick++;

            //Обработка движений и огня танчика игрока 1
            if (_twoPlayersMode)
            {
                //Обработка движения танчика игрока 1

                //if (_form1.is2Up) tanks[1].Drive(Keys.W);
                //else if (_form1.is2Left && !_form1.is2Down) tanks[1].Drive(Keys.A);
                //if (_form1.is2Down) tanks[1].Drive(Keys.S);
                //else if (_form1.is2Right && !_form1.is2Up) tanks[1].Drive(Keys.D);

                /*
                tanks[0].VirtualKey = Keys.None;
                if (_form1.is2Up) tanks[1].VirtualKey = Keys.W;
                if (_form1.is2Left) tanks[1].VirtualKey = Keys.A;
                if (_form1.is2Down) tanks[1].VirtualKey = Keys.S;
                if (_form1.is2Right) tanks[1].VirtualKey = Keys.D;
                */
                tanks[1].Drive();

                //Обработка огня танчика игрока 1
                if (tanks[1]._counterTick >= tanks[1]._attackSpeed && is2Fire)
                {
                    tanks[1]._counterTick = 0;
                    tanks[1].Fire();
                }
                tanks[1]._counterTick++;
            }

            //Движение пуль
            foreach (var bullet in playerBullets)
            {
                bullet.Fly();
            }
            foreach (var bullet in enemyBullets)
            {
                bullet.Fly();
            }

            
            //Обработка движения и огня врагов
            for (int i = _playerCount; i < tanks.Count; i++)
            {
                tanks[i].Drive();

                if (tanks[i]._counterTick >= tanks[i]._attackSpeed && tanks[i].VirtualKey == Keys.Space)
                {
                    tanks[i]._counterTick = 0;
                    tanks[i].Fire();
                }
                tanks[i]._counterTick++;
            }

            //Обработка столкновений танчиков
            for (int i = 0; i < tanks.Count - 1; i++)
            {
                for (int j = i + 1; j < tanks.Count; j++)
                {
                    if (tanks[i].Rectangle.IsCrossed(tanks[j].Rectangle))
                    {
                        //Находим наименьшее проникновение для дальнейшего выталкивания в этом направлении
                        int dX = Math.Min(tanks[i].Rectangle.Right - tanks[j].Rectangle.Left,
                                          tanks[j].Rectangle.Right - tanks[i].Rectangle.Left);
                        int dY = Math.Min(tanks[i].Rectangle.Bottom - tanks[j].Rectangle.Top,
                                          tanks[j].Rectangle.Bottom - tanks[i].Rectangle.Top);

                        if (dX < dY)
                        {
                            //смещаем по оси X
                            if (tanks[i].Rectangle.Left < tanks[j].Rectangle.Left)
                            {
                                while (tanks[i].Rectangle.IsCrossed(tanks[j].Rectangle))
                                {
                                    //Танк i левее танка j
                                    tanks[i]._location.X--;
                                    tanks[j]._location.X++;
                                }
                                continue;
                            }
                            else
                            {
                                while (tanks[i].Rectangle.IsCrossed(tanks[j].Rectangle))
                                {
                                    //Танк i правее танка j
                                    tanks[i]._location.X++;
                                    tanks[j]._location.X--;
                                }
                                continue;
                            }
                        }
                        else
                        {
                            //смещаем по оси Y
                            if (tanks[i].Rectangle.Top < tanks[j].Rectangle.Top)
                            {
                                while (tanks[i].Rectangle.IsCrossed(tanks[j].Rectangle))
                                {
                                    //Танк i выше танка j
                                    tanks[i]._location.Y--;
                                    tanks[j]._location.Y++;
                                }
                                continue;
                            }
                            else
                            {
                                while (tanks[i].Rectangle.IsCrossed(tanks[j].Rectangle))
                                {
                                    //Танк i ниже танка j
                                    tanks[i]._location.Y++;
                                    tanks[j]._location.Y--;
                                }
                                continue;
                            }
                        }
                    }
                }
            }

            //Обработка-столкновений-с-блоками---------------------
            int blocksRows = blocks.GetUpperBound(0) + 1;
            int blocksColumns = blocks.GetUpperBound(1) + 1;

            //Обработка столкновений танчиков с блоками
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    for (int i = 0; i < tanks.Count; i++)
                    {
                        if (tanks[i].Rectangle.IsCrossed(block.Rectangle))
                        {
                            //Находим наименьшее проникновение для дальнейшего выталкивания в этом направлении
                            int dX = Math.Min(tanks[i].Rectangle.Right - block.Rectangle.Left,
                                                block.Rectangle.Right - tanks[i].Rectangle.Left);
                            int dY = Math.Min(tanks[i].Rectangle.Bottom - block.Rectangle.Top,
                                                block.Rectangle.Bottom - tanks[i].Rectangle.Top);

                            if (dX < dY)
                            {
                                //смещаем по оси X
                                if (tanks[i].Rectangle.Left < block.Rectangle.Left)
                                {
                                    while (tanks[i].Rectangle.IsCrossed(block.Rectangle))
                                    {
                                        //Танк i левее блока
                                        tanks[i]._location.X--;
                                    }
                                    continue;
                                }
                                else
                                {
                                    while (tanks[i].Rectangle.IsCrossed(block.Rectangle))
                                    {
                                        //Танк i правее блока
                                        tanks[i]._location.X++;
                                    }
                                    continue;
                                }
                            }
                            else
                            {
                                //смещаем по оси Y
                                if (tanks[i].Rectangle.Top < block.Rectangle.Top)
                                {
                                    while (tanks[i].Rectangle.IsCrossed(block.Rectangle))
                                    {
                                        //Танк i выше блока
                                        tanks[i]._location.Y--;
                                    }
                                    continue;
                                }
                                else
                                {
                                    while (tanks[i].Rectangle.IsCrossed(block.Rectangle))
                                    {
                                        //Танк i ниже блока
                                        tanks[i]._location.Y++;
                                    }
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            //Обработка столкновений пуль игроков с блоками
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    for (int j = 0; j < playerBullets.Count; j++)
                    {
                        if (block.Rectangle.IsCrossed(playerBullets[j].Rectangle) &&
                            block.BlockType == 0)
                        {
                            playerBullets.RemoveAt(j);
                        }
                    }
                }
            }

            //Обработка столкновений пуль врагов с блоками
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    for (int j = 0; j < enemyBullets.Count; j++)
                    {
                        if (block.Rectangle.IsCrossed(enemyBullets[j].Rectangle) &&
                            block.BlockType == 0)
                        {
                            enemyBullets.RemoveAt(j);
                        }
                    }
                }
            }

            //-----------------------------------------------------

            //Обработка столкновений танчиков игрока с бонусами (Box)
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < bonuses.Count; j++)
                {
                    if (tanks[i].Rectangle.IsCrossed(bonuses[j].Rectangle))
                    {
                        if (tanks[i] is PlayerTank)
                        {
                            tanks[i].BonusEffect(bonuses[j]);
                        }
                        bonuses.RemoveAt(j);
                    }
                }
            }

            //Обработка попадания пуль игрока в другого игрока
            if (_twoPlayersMode)
            {
                for (int i = 0; i < _playerCount; i++)
                {
                    for (int j = 0; j < playerBullets.Count; j++)
                    {
                        if (tanks[i].Rectangle.IsCrossed(playerBullets[j].Rectangle))
                        {
                            playerBullets.RemoveAt(j);
                        }
                    }
                }
            }

            //Обработка попадания пуль игрока во врагов
            for (int i = _playerCount; i < tanks.Count; i++) //Не учитываем танки игрока(ов)
            {
                for (int j = 0; j < playerBullets.Count; j++)
                {
                    if (playerBullets[j].Rectangle.IsCrossed(tanks[i].Rectangle))
                    {
                        tanks[i].DamageToTank(playerBullets[j]);
                        playerBullets.RemoveAt(j);
                    }
                }
            }

            //Обработка попадания пуль врагов в игрока(ов)
            for (int i = 0; i < _playerCount; i++)
            {
                for (int j = 0; j < enemyBullets.Count; j++)
                {
                    if (enemyBullets[j].Rectangle.IsCrossed(tanks[i].Rectangle))
                    {
                        tanks[i].DamageToTank(enemyBullets[j]);
                        enemyBullets.RemoveAt(j);
                    }
                }
            }

            //Обработка попадания пуль врага в другого врага
            for (int i = _playerCount; i < tanks.Count; i++)
            {
                for (int j = 0; j < enemyBullets.Count; j++)
                {
                    if (enemyBullets[j].Rectangle.IsCrossed(tanks[i].Rectangle))
                    {
                        enemyBullets.RemoveAt(j);
                    }
                }
            }
            
            //Уничтожение танка врага при потере им здоровья (также обработка выпадений бонусов)
            for (int i = _playerCount; i < tanks.Count; i++) //Не учитываем танк игрока
            {
                if (tanks[i]._health <= 0)
                {
                    //Выпадение бонуса
                    Random random = new Random();
                    int r = random.Next(_bonusSpawnFrequency);
                    switch (r)
                    {
                        case 0:
                            int r1 = random.Next(_boxAmount);
                            switch (r1)
                            {
                                case 0: //MaxRepairBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 0));
                                    break;

                                case 1: //PlusAttackSpeedBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 1));
                                    break;

                                case 2: //PlusDamageBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 2));
                                    break;

                                case 3: //PlusHealthBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 3));
                                    break;

                                case 4: //PlusMaxHealthBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 4));
                                    break;

                                case 5: //PlusSpeedBox
                                    bonuses.Add(new Bonus(tanks[i]._location, 5));
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    tanks.RemoveAt(i);
                    _score++;
                }
            }

            //Удаление пуль игрока при выходе за пределы клиентской области
            for (int i = 0; i < playerBullets.Count; i++)
            {
                if (playerBullets[i]._location.X < 0 || playerBullets[i]._location.X > this._size.Width ||
                    playerBullets[i]._location.Y < 0 || playerBullets[i]._location.Y > this._size.Height)
                {
                    playerBullets.RemoveAt(i);
                }
            }

            //Удаление пуль врагов при выходе за пределы клиентской области
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (enemyBullets[i]._location.X < 0 || enemyBullets[i]._location.X > this._size.Width ||
                    enemyBullets[i]._location.Y < 0 || enemyBullets[i]._location.Y > this._size.Height)
                {
                    enemyBullets.RemoveAt(i);
                }
            }

            //Добавление легкого врага на поле на одном из четырех мест спавна
            if (_countSpawnEasy >= _timeSpawnEnemyEasy)
            {
                _countSpawnEasy = 0;
                Random random = new Random();
                //Случайное место появления врага: в левом верхнем или в правом верхнем углу
                int r = random.Next(0, 4);
                Rectangle randomSpawn = _spawnPlace1;
                switch (r)
                {
                    case 0:
                        randomSpawn = _spawnPlace1;
                        break;
                    case 1:
                        randomSpawn = _spawnPlace2;
                        break;
                    case 2:
                        randomSpawn = _spawnPlace3;
                        break;
                    case 3:
                        randomSpawn = _spawnPlace4;
                        break;
                }
                tanks.Add(new EnemyTank(this, _blockSize, randomSpawn, 0));
                tanks[tanks.Count-1].FireNotify += (bullet) => { enemyBullets.Add(bullet); };
            }
            _countSpawnEasy++;

            //Добавление легкого врага на поле на одном из четырех мест спавна
            if (_countSpawnHard >= _timeSpawnEnemyHard)
            {
                _countSpawnHard = 0;
                Random random = new Random();
                //Случайное место появления врага: в левом верхнем или в правом верхнем углу
                int r = random.Next(0, 4);
                Rectangle randomSpawn = _spawnPlace1;
                switch (r)
                {
                    case 0:
                        randomSpawn = _spawnPlace1;
                        break;
                    case 1:
                        randomSpawn = _spawnPlace2;
                        break;
                    case 2:
                        randomSpawn = _spawnPlace3;
                        break;
                    case 3:
                        randomSpawn = _spawnPlace4;
                        break;
                }
                tanks.Add(new EnemyTank(this, _blockSize, randomSpawn, 1));
                tanks[tanks.Count - 1].FireNotify += (bullet) => { enemyBullets.Add(bullet); };
            }
            _countSpawnHard++;

            //Обработка выхода танчиков за пределы поля
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].LimitPos();
            }

            //Конец игры при прочности танка игрока == 0
            if (tanks[0]._health <= 0 || (_twoPlayersMode == true && tanks[1]._health <= 0))
            {
                GameOver?.Invoke();
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(_bitmap, Rectangle);

            foreach (var block in blocks)
                block?.Draw(graphics);

            foreach (var tank in tanks)
                tank.Draw(graphics);

            foreach (var bonus in bonuses)
                bonus.Draw(graphics);

            foreach (var playerBullet in playerBullets)
                playerBullet.Draw(graphics);

            foreach (var enemyBullet in enemyBullets)
                enemyBullet.Draw(graphics);
        }
    }
}
