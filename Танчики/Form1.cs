using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; //для работы с файлами
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Танчики
{
	public struct GameResultsEntry
	{
		public string _name;
		public int _score;
		public int _tics;

		public GameResultsEntry(string name, int score, int tics)
		{
			_name = name;
			_score = score;
			_tics = tics;
		}
	}

	public partial class Form1 : Form
	{
		private Field _field;
		private bool _twoPlayersMode = false;
		public int _tics = 0;
		private bool _pause = false;
		private bool _isGameNow = false;
		private int _entryAmount = 8;
		public string _pathLeaderTable = @"LeaderTable.dat";

		public bool is1Up;
		public bool is1Left;
		public bool is1Down;
		public bool is1Right;
		public bool is1Fire;

		public bool is2Up;
		public bool is2Left;
		public bool is2Down;
		public bool is2Right;
		public bool is2Fire;



		public Form1()
		{
			InitializeComponent();
			Size = new Size(816, 719); //размер поля получается 800x600
			MaximumSize = new Size(Width, Height);
			MinimumSize = new Size(Width, Height);
			SetStyle(ControlStyles.AllPaintingInWmPaint |
					 ControlStyles.OptimizedDoubleBuffer |
					 ControlStyles.UserPaint, true);
			UpdateStyles();
			//Начальный экран
			pictureBox1.Visible = false;

			_field = new Field(this, _twoPlayersMode);
			_field.GameOver += Close;
			ScoreLabel.Location = new Point(10, Size.Height - 100);
			Health1Label.Location = new Point(80, Size.Height - 100);
			Health2Label.Location = new Point(130, Size.Height - 100);
			TicsLabel.Location = new Point(200, Size.Height - 100);

			ScoreLabel.Visible = false;
			Health1Label.Visible = false;
			Health2Label.Visible = false;
			TicsLabel.Visible = false;

			
			//Создаем файл с лидерами, если его нет GameResultsEntry
			FileInfo leaderTable = new FileInfo(_pathLeaderTable);
			try
			{
				if (!leaderTable.Exists)
				{
					//leaderTable.Create();
					using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(_pathLeaderTable, FileMode.OpenOrCreate)))
					{
						for (int i = _entryAmount; i > 0; i--)
						{
							GameResultsEntry gameResultsEntry = new GameResultsEntry("System    ", i, 999);
							binaryWriter.Write(gameResultsEntry._name);
							binaryWriter.Write(gameResultsEntry._score);
							binaryWriter.Write(gameResultsEntry._tics);
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			Refresh();

			if (!_pause && _isGameNow)
			{
				_tics++;
				_field.Tick();
				TicsLabel.Text = $"Tics: {_tics}";
				ScoreLabel.Text = $"Счет: {_field._score}";
				Health1Label.Text = $"❤️1: {_field.tanks[0]._health}";
				if (_twoPlayersMode)
				{
					Health2Label.Visible = true;
					Health2Label.Text = $"❤️2: {_field.tanks[1]._health}";
				}
				else
				{
					Health2Label.Visible = false;
				}
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			if (_isGameNow)
			{
				pictureBox1.Visible = false;
				_field.Draw(e.Graphics);
			}
			else
			{
				pictureBox1.Visible = true;
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			/*
			if (e.KeyCode == Keys.W) is1Up = true;
			if (e.KeyCode == Keys.A) is1Left = true;
			if (e.KeyCode == Keys.S) is1Down = true;
			if (e.KeyCode == Keys.D) is1Right = true;
			if (e.KeyCode == Keys.Space) is1Fire = true;

			if (e.KeyCode == Keys.Up) is2Up = true;
			if (e.KeyCode == Keys.Left) is2Left = true;
			if (e.KeyCode == Keys.Down) is2Down = true;
			if (e.KeyCode == Keys.Right) is2Right = true;
			if (e.KeyCode == Keys.Enter) is2Fire = true;
			*/
			
			if (e.KeyCode == Keys.Space)
			{
				_field.is1Fire = true;
			}

			if (e.KeyCode == Keys.Enter)
			{
				_field.is2Fire = true;
			}
			
			if (_twoPlayersMode)
			{
				if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
				{
					_field.tanks[0].VirtualKey = e.KeyCode;
				}
				if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
				{
					_field.tanks[1].VirtualKey = e.KeyCode;
				}
			}
			else
			{
				_field.tanks[0].VirtualKey = e.KeyCode;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			/*
			if (e.KeyCode == Keys.W) is1Up = false;
			if (e.KeyCode == Keys.A) is1Left = false;
			if (e.KeyCode == Keys.S) is1Down = false;
			if (e.KeyCode == Keys.D) is1Right = false;
			if (e.KeyCode == Keys.Space) is1Fire = false;

			if (e.KeyCode == Keys.Up) is2Up = false;
			if (e.KeyCode == Keys.Left) is2Left = false;
			if (e.KeyCode == Keys.Down) is2Down = false;
			if (e.KeyCode == Keys.Right) is2Right = false;
			if (e.KeyCode == Keys.Enter) is2Fire = false;
			*/
			
			if (e.KeyCode == Keys.Space)
			{
				_field.is1Fire = false;
			}

			if (e.KeyCode == Keys.Enter)
			{
				_field.is2Fire = false;
			}

			if (_twoPlayersMode)
			{
				_field.tanks[0].VirtualKey = Keys.None;
				_field.tanks[1].VirtualKey = Keys.None;
			}
			else
			{
				_field.tanks[0].VirtualKey = Keys.None;
			}
		}

		private void Form1_Load(object sender, EventArgs e) { }

		//Нажание кнопок панели меню---------------------------------------------

		private void AddToLeaderTable()
		{
			FileInfo leaderTable = new FileInfo(_pathLeaderTable);
			try
			{
				if (leaderTable.Exists)
				{
					int entryIndex = 0;
					//int offset = 0; //Отступ в файле до нужной записи в байтах
					int positionEntry = 0;
					List<GameResultsEntry> bufferOfEntryes = new List<GameResultsEntry>();
					bool flag = false;
					using (BinaryReader binaryReader = new BinaryReader(new FileStream(_pathLeaderTable, FileMode.Open)))
					{
						while (binaryReader.PeekChar() > -1)
						{
							if (!flag)
							{
								positionEntry = (int)binaryReader.BaseStream.Position;
							}

							string name = binaryReader.ReadString();
							int score = binaryReader.ReadInt32();
							int tics = binaryReader.ReadInt32();


							GameResultsEntry currentEntry = new GameResultsEntry(name, score, tics);


							if (_field._score > currentEntry._score || flag == true)
							{
								flag = true;
								//Сохраняем  эту и все последующие записи
								bufferOfEntryes.Add(currentEntry);
							}

							if (!flag)
							{
								entryIndex++;
							}
						}
					}

                    if (flag) //Попадает ли игрок в таблицу лидеров?
                    {
						Form2 form2 = new Form2();
						form2.ActionOkButton += delegate ()
						{
							string _playerNameToWrite = form2._text;
							using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(_pathLeaderTable, FileMode.Open)))
							{

								//binaryWriter.Seek(offset, SeekOrigin.Begin);
								//fs.Seek(positionEntry, SeekOrigin.Begin);
								binaryWriter.BaseStream.Position = positionEntry;


								binaryWriter.Write(_playerNameToWrite);
								binaryWriter.Write(_field._score);
								binaryWriter.Write(_tics);

                                for (int i = entryIndex + 1; i < _entryAmount; i++)
                                {
                                    binaryWriter.Write(bufferOfEntryes[i - (entryIndex + 1)]._name);
                                    binaryWriter.Write(bufferOfEntryes[i - (entryIndex + 1)]._score);
                                    binaryWriter.Write(bufferOfEntryes[i - (entryIndex + 1)]._tics);
                                }
                            }
							form2.Close();
						};
						form2.Show();
					}
				}
			}
			catch (Exception ev)
			{
				Console.WriteLine(ev.Message);
			}
		}

		//Новая игра 1p
		private void NewGameButtomClick(object sender, EventArgs e)
		{
			_tics = 0;
			_pause = false;
			_isGameNow = true;
			_twoPlayersMode = false;
			_field = new Field(this, _twoPlayersMode);
			_field.GameOver += delegate ()
			{
				_isGameNow = false;
				ScoreLabel.Visible = false;
				Health1Label.Visible = false;
				Health2Label.Visible = false;
				TicsLabel.Visible = false;
				AddToLeaderTable();
			};
			ScoreLabel.Visible = true;
			Health1Label.Visible = true;
			Health2Label.Visible = true;
			TicsLabel.Visible = true;
		}

		//Новая игра 2p
		private void NewGame2p_Click(object sender, EventArgs e)
		{
			_tics = 0;
			_pause = false;
			_isGameNow = true;
			_twoPlayersMode = true;
			_field = new Field(this, _twoPlayersMode);
			_field.GameOver += delegate ()
				{
					_isGameNow = false;
					ScoreLabel.Visible = false;
					Health1Label.Visible = false;
					Health2Label.Visible = false;
					TicsLabel.Visible = false;
					AddToLeaderTable();
				};
			ScoreLabel.Visible = true;
			Health1Label.Visible = true;
			Health2Label.Visible = true;
			TicsLabel.Visible = true;
		}

		//Игра
		private void GameButton_Click(object sender, EventArgs e) { }

		//Пауза
		private void PauseButton_Click(object sender, EventArgs e)
		{
			if (_pause == false)
			{
				_pause = true;
			}
			else
			{
				_pause = false;
			}
		}
		
		//Таблица лидеров
		private void LeaderTableButtonClick(object sender, EventArgs e)
		{
            //Console.WriteLine("{0, -10} {1, -15} {2, -20}", "Имя", "Фамилия", "Возраст");
            //Console.WriteLine("{0, -10} {1, -15} {2, -20}", "John", "Doe", 30);
            //Console.WriteLine("{0, -10} {1, -15} {2, -20}", "Jane", "Smith", 25);
            //Console.WriteLine("{0, -10} {1, -15} {2, -20}", "Bob", "Johnson", 40);

            FormLeaders formLeaders = new FormLeaders();

            FileInfo leaderTable = new FileInfo(_pathLeaderTable);
			try
			{
				string formatedTextForRichTextBox = "";
                if (leaderTable.Exists)
				{
					List<GameResultsEntry> entries = new List<GameResultsEntry>();
					using (BinaryReader binaryReader = new BinaryReader(new FileStream(_pathLeaderTable, FileMode.Open)))
					{
						while (binaryReader.PeekChar() > -1)
						{
							entries.Add(new GameResultsEntry(binaryReader.ReadString(),
																		binaryReader.ReadInt32(),
																		binaryReader.ReadInt32()));
						}
					}

                    for (int i = 0; i < _entryAmount; i++)
					{
                        formLeaders.dataGridViewLeadersTable.Rows.Add(i + 1, entries[i]._name, entries[i]._score, entries[i]._tics);
                    }
				}


                formLeaders.Show();
            }
			catch (Exception ev)
			{
				Console.WriteLine(ev.Message);
			}
		}

		//Об игре
		private void Information_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Танчики 2021\n" +
							"Разработчик: Потонов Г.Е.\n\n");
		}

		//Управление
		private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("1 игрок: передвижение - wasd, огонь - space\n" +
							"2 игрок: передвижение - стрелки, огонь - enter",
							"Управление");
		}

		//Размер окна
		private void FormSize_Click(object sender, EventArgs e)
		{
			MessageBox.Show($"{Width}, {Height}");
		}

		//Размер поля
		private void FieldSize_Click(object sender, EventArgs e)
		{
			MessageBox.Show($"{ClientRectangle.Width}, {ClientRectangle.Height - Field._indentDown}");
		}

        private void добавитьВТаблицуЛидововToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AddToLeaderTable();
		}
    }
}
