using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Танчики
{
    public partial class Form2 : Form
    {
        public string _text = "";
        public event Action ActionOkButton;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _text = textBox1.Text;
            _text += "           ";
            _text = _text.Substring(0, 10);
            ActionOkButton?.Invoke();
        }
    }
}
