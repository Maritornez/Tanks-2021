namespace Танчики
{
    partial class FormLeaders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewLeadersTable = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeadersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLeadersTable
            // 
            this.dataGridViewLeadersTable.AllowUserToAddRows = false;
            this.dataGridViewLeadersTable.AllowUserToDeleteRows = false;
            this.dataGridViewLeadersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeadersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.PlayerName,
            this.Score,
            this.Time});
            this.dataGridViewLeadersTable.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewLeadersTable.Name = "dataGridViewLeadersTable";
            this.dataGridViewLeadersTable.ReadOnly = true;
            this.dataGridViewLeadersTable.RowHeadersWidth = 51;
            this.dataGridViewLeadersTable.RowTemplate.Height = 24;
            this.dataGridViewLeadersTable.Size = new System.Drawing.Size(826, 456);
            this.dataGridViewLeadersTable.TabIndex = 1;
            // 
            // Number
            // 
            this.Number.FillWeight = 50F;
            this.Number.HeaderText = "Номер";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 125;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Имя";
            this.PlayerName.MinimumWidth = 6;
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Width = 125;
            // 
            // Score
            // 
            this.Score.HeaderText = "Счет";
            this.Score.MinimumWidth = 6;
            this.Score.Name = "Score";
            this.Score.Width = 125;
            // 
            // Time
            // 
            this.Time.HeaderText = "Время (в тиках)";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 125;
            // 
            // FormLeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(this.dataGridViewLeadersTable);
            this.Name = "FormLeaders";
            this.Text = "Таблица лидеров";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeadersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridViewLeadersTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}