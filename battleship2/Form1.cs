using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace battleship2
{
    public partial class Form1 : Form
    {
        int[] boardSize = new int[11];

        List<Image> shipImages = new List<Image>()
        {
            Image.FromFile("Images/Submarine.png"),
            Image.FromFile("Images/BATTLESHIP.png"),
            Image.FromFile("Images/DESTROYER.png"),
            Image.FromFile("Images/aircraft_carrier.png"),

            Image.FromFile("Images/Submarine_v.png"),
            Image.FromFile("Images/BATTLESHIP_v.png"),
            Image.FromFile("Images/DESTROYER_v.png"),
            Image.FromFile("Images/aircraft_carrier_v.png")
        };

        List<PictureBox> ships = new List<PictureBox>();
        List<Ship> shipList = new List<Ship>();
        bool[,] MyShips = new bool[10, 10];

        Label label = new Label();
        Button play_button = new Button();

        public Form1()
        {
            InitializeComponent();

            for (int i = 2; i <= 5; i++)
            {
                Ship p = new Ship(i);
                p.Image = shipImages[i - 2];
                p.MouseDown += Picture_MouseDown;
                p.MouseMove += Picture_MouseMove;
                p.MouseUp += Picture_MouseUp;
                p.MouseClick += Picture_MouseClick;
                ships.Add(p);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 255, 255, 255);
            panel3.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;

            // start screen
            panel2.Visible = false;            
            label.Text = "Battleship!";
            label.ForeColor = Color.DarkBlue;
            label.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            label.Location = new Point(350, 100);
            label.AutoSize = true;
            label.BackColor = Color.LightCyan;
            this.Controls.Add(label);
            Button play_button = new Button();
            play_button.Text = "PLAY";
            play_button.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            play_button.AutoSize = true;
            play_button.Enabled = true;
            play_button.Location = new Point(385, 300);
            this.Controls.Add(play_button);
            play_button.Click += new EventHandler(play_button_Click);

            panel1.Width = 400;
            panel1.Height = 400;
            boardSize[0] = 0;
            for (int i = 1; i <= 10; i++)
            {
                boardSize[i] = boardSize[i - 1] + panel1.Width / 10;
            }
        }

        // play button 1
        private void play_button_Click(object sender, EventArgs e)
        {
            play_button.Visible = false;
            label.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
        }

        // selection of the ship
        private void Picture_Click(dynamic sender, EventArgs e)
        {
            int size = int.Parse(sender.Tag.ToString());
            for (int i = 2; i <= 5; i++)
            {
                if (size == i)
                {
                    panel1.Controls.Add(ships[i - 2]);               
                    shipList.Add(ships[i - 2] as Ship);
                    break;
                }
            }
        }

        // change the direction of the ship
        private void Picture_MouseClick(dynamic sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sender.Image = shipImages[sender.shipSize + (2 * (sender.direction == 0 ? 1 : -1))];
                sender.direction = sender.Height == 40 ? 1 : 0;
                sender.Size = new Size(sender.Height, sender.Width);
            }
        }

        // moving of each ship       
        bool dragging = false;
        int x, y;
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                x = e.X;
                y = e.Y;
            }
        }
        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;

            if (dragging && c != null)
            {
                c.Top += e.Y - y;
                c.Left += e.X - x;
            }
        }
        private void Picture_MouseUp(dynamic sender, MouseEventArgs e)
        {
            Ship p = sender as Ship;
            dragging = false;
            int size = sender.shipSize;

            // when we don't drag the ship
            if (!dragging)
            {   // mas leiepei to intersect
                int d = p.direction;
                for (int i = 0; i <= 10; i++)
                {
                    for (int j = 0; j <= 10; j++)
                    {   
                        if (p.Location.X >= boardSize[i] && p.Location.X < boardSize[i + 1] && p.Location.Y >= boardSize[j] && p.Location.Y < boardSize[j + 1])
                        {
                            if (i < 11 - size && j < 11 - size)
                                lockL(p, i, j, size);
                            else
                            {
                                int k = (i * (1 ^ d) + j * d) + size - 10; // poso exei bgei exo to ploio
                                lockL(p, i - (k * (1 ^ d)), j - (k * d), size);
                            }
                            break;
                        }
                        else if ((p.Location.X < 0 && p.Location.Y >= boardSize[j] && p.Location.Y < boardSize[j + 1]) || (p.Location.Y < 0 && p.Location.X >= boardSize[i] && p.Location.X < boardSize[i + 1]))
                        {
                            lockL(p, i * d, j * (1 ^ d), size);
                            break;
                        }
                        else if ((p.Location.X >= boardSize[10] && p.Location.Y >= boardSize[j]) && p.Location.Y <= boardSize[j + 1]||(p.Location.Y >= boardSize[10] && p.Location.X >= boardSize[i] && p.Location.X <= boardSize[i + 1]))
                        {
                            int k = (i * (1 ^ d) + j * d) + size - 10; // poso exei bgei exo to ploio
                            lockL(p, i - (k * (1 ^ d)), j - (k * d), size);
                            break;
                        }
                    }
                }
            }
        }

        // chech that the ships don't intersect and lock the ship into position
        private void lockL(Ship p, int x, int y, int size)
        {
            bool b = p.SetPosition(ref MyShips, y, x);
            if (b)
            {
                p.Location = new Point(boardSize[x], boardSize[y]);
            }
            else
            {
                p.Location = new Point(boardSize[0], boardSize[0]);
            }
            print();
        }

        private void print()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string x = " ";
                    if (MyShips[i, j])
                        x = "1";
                    else
                        x = " ";
                    Console.Write(x + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n\n");
        }
        // ---------------------------------------- !!!!!!!!!!! ----------------------------------------
        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            foreach (Ship s in shipList)
            {
                s.ClearPosition(ref MyShips);
            }
            print();
        }

        // play button 2
        private void Play_Btn_Click(object sender, EventArgs e)
        {   
            int count = 14;
            foreach (bool b in MyShips)
            {
                if (b)
                {
                    count++;
                }
            }
            if (count == 14)
            {
                panel3.Visible = false;
                panel4.Location = new Point(0, 0);
                Clear_Btn.Visible = false;
                Play_Btn.Visible = false;
                Panel panel5 = new Panel();
                panel5.Location = new Point(panel4.Location.X + panel4.Width + 10, panel4.Location.Y + panel4.Height + 10);
                panel5.Size = panel4.Size;
                panel5.BackColor = panel4.BackColor;
                panel2.Controls.Add(panel5);
                Panel panel6 = new Panel();
                panel6.Location = new Point();
                panel6.Size = panel1.Size;
                panel6.BackgroundImage = panel1.BackgroundImage;
                panel5.Controls.Add(panel6);
                Label label2 = new Label();
                label2.Text = "1     2    3     4    5     6    7     8     9   10";
                label2.Location = new Point(42, 12);
                panel5.Controls.Add(label2);
            }
            else
            {
                MessageBox.Show("You must place all ships on the board!");
            }
        }
    }
}