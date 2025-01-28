using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship2
{
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public Form2(String s)
        {
            InitializeComponent();
            MaximumSize = new Size(Width, Height);
            MinimumSize = new Size(Width, Height);
            label1.Text = s;            
        }

        private void end_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void replay_Btn_Click(object sender, EventArgs e)
        {
            Hide();
            f1.Show();
        }

        public void GetData(int time, int tries, int wins, int loses) 
        {
            textBox1.Text = "Χρόνος: " + time.ToString() + " sec \n Προσπάθειες: " + tries.ToString() + "\n Νίκες:" + wins.ToString() + "\n Ήττες:" + loses.ToString();
        }
    }
}
