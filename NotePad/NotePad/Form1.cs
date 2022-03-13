using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String body = textBoxBody.Text;
            List<String> list = new List<String>();
            list.Add(body);

            list.ForEach(item => Console.WriteLine(item));
        }
    }
}
