
namespace Танчики
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TicsLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Health1Label = new System.Windows.Forms.Label();
            this.Health2Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИгра1pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИгра2pToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЛидеровToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обИгреToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЛидеровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TicsLabel
            // 
            this.TicsLabel.AutoSize = true;
            this.TicsLabel.Location = new System.Drawing.Point(431, 634);
            this.TicsLabel.Name = "TicsLabel";
            this.TicsLabel.Size = new System.Drawing.Size(38, 17);
            this.TicsLabel.TabIndex = 0;
            this.TicsLabel.Text = "Tics:";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(15, 634);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(44, 17);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Счет:";
            // 
            // Health1Label
            // 
            this.Health1Label.AutoSize = true;
            this.Health1Label.Location = new System.Drawing.Point(100, 634);
            this.Health1Label.Name = "Health1Label";
            this.Health1Label.Size = new System.Drawing.Size(91, 17);
            this.Health1Label.TabIndex = 2;
            this.Health1Label.Text = "Прочность1:";
            // 
            // Health2Label
            // 
            this.Health2Label.AutoSize = true;
            this.Health2Label.Location = new System.Drawing.Point(248, 634);
            this.Health2Label.Name = "Health2Label";
            this.Health2Label.Size = new System.Drawing.Size(91, 17);
            this.Health2Label.TabIndex = 3;
            this.Health2Label.Text = "Прочность2:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem1,
            this.паузаToolStripMenuItem,
            this.таблицаЛидеровToolStripMenuItem1,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 662);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem1
            // 
            this.играToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИгра1pToolStripMenuItem,
            this.новаяИгра2pToolStripMenuItem1});
            this.играToolStripMenuItem1.Name = "играToolStripMenuItem1";
            this.играToolStripMenuItem1.Size = new System.Drawing.Size(57, 24);
            this.играToolStripMenuItem1.Text = "Игра";
            // 
            // новаяИгра1pToolStripMenuItem
            // 
            this.новаяИгра1pToolStripMenuItem.Image = global::Танчики.Resource1.PlayIcon;
            this.новаяИгра1pToolStripMenuItem.Name = "новаяИгра1pToolStripMenuItem";
            this.новаяИгра1pToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.новаяИгра1pToolStripMenuItem.Text = "Новая игра 1p";
            this.новаяИгра1pToolStripMenuItem.Click += new System.EventHandler(this.NewGameButtomClick);
            // 
            // новаяИгра2pToolStripMenuItem1
            // 
            this.новаяИгра2pToolStripMenuItem1.Image = global::Танчики.Resource1.PlayIcon;
            this.новаяИгра2pToolStripMenuItem1.Name = "новаяИгра2pToolStripMenuItem1";
            this.новаяИгра2pToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.новаяИгра2pToolStripMenuItem1.Text = "Новая игра 2p";
            this.новаяИгра2pToolStripMenuItem1.Click += new System.EventHandler(this.NewGame2p_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.паузаToolStripMenuItem.Text = "Пауза";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // таблицаЛидеровToolStripMenuItem1
            // 
            this.таблицаЛидеровToolStripMenuItem1.Name = "таблицаЛидеровToolStripMenuItem1";
            this.таблицаЛидеровToolStripMenuItem1.Size = new System.Drawing.Size(145, 24);
            this.таблицаЛидеровToolStripMenuItem1.Text = "Таблица лидеров";
            this.таблицаЛидеровToolStripMenuItem1.Click += new System.EventHandler(this.LeaderTableButtonClick);
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обИгреToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem1.Text = "Справка";
            // 
            // обИгреToolStripMenuItem
            // 
            this.обИгреToolStripMenuItem.Name = "обИгреToolStripMenuItem";
            this.обИгреToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.обИгреToolStripMenuItem.Text = "Об игре";
            this.обИгреToolStripMenuItem.Click += new System.EventHandler(this.Information_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.управлениеToolStripMenuItem.Text = "Управление";
            this.управлениеToolStripMenuItem.Click += new System.EventHandler(this.управлениеToolStripMenuItem_Click);
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // таблицаЛидеровToolStripMenuItem
            // 
            this.таблицаЛидеровToolStripMenuItem.Name = "таблицаЛидеровToolStripMenuItem";
            this.таблицаЛидеровToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.таблицаЛидеровToolStripMenuItem.Text = "Таблица лидеров";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.Information_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Танчики.Resource1.RedTankDrives;
            this.pictureBox1.Location = new System.Drawing.Point(615, 443);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Health2Label);
            this.Controls.Add(this.Health1Label);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.TicsLabel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танчики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TicsLabel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label Health1Label;
        private System.Windows.Forms.Label Health2Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаЛидеровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem новаяИгра1pToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИгра2pToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem таблицаЛидеровToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обИгреToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

