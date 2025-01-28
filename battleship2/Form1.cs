using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading.Tasks;

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

        // Player's ships
        List<PictureBox> ships = new List<PictureBox>();
        List<Ship> shipList = new List<Ship>();  

        // Black table, false
        private static bool[,] MyShips;
        // Green table, null        
        private static bool?[,] myHits;

        // Blue table, false
        private static bool[,] enemyShips;
        // Red table, null
        private static bool?[,] enemyHits;

        Enemy enemy;

        int ship_count = 0;
        int tries;
        int time = 0;
        int wins = 0;
        int loses = 0;

        Label label = new Label();
        Button play_button = new Button();
        TextBox textBox = new TextBox();

        public Form1()
        {
            InitializeComponent();

            MyShips = new bool[10, 10];
            myHits = new bool?[10, 10];
            enemyShips = new bool[10, 10];
            enemyHits = new bool?[10, 10];

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
            enemy = new Enemy(ref enemyShips);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 255, 255, 255);
            panel3.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;

            // start screen
            panel2.Visible = false;

            label.Text = "Battleship!";
            label.ForeColor = Color.MidnightBlue;
            label.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            label.Location = new Point(410, 100);
            label.AutoSize = true;
            label.BackColor = Color.LightCyan;
            this.Controls.Add(label);

            
            textBox.Location = new Point(410, 250);
            textBox.Size = new Size(150, 100);
            textBox.Visible = true;
            textBox.Text = "Guest";
            textBox.Font = new Font("Microsoft Sans Serif", 13);
            this.Controls.Add(textBox);

            play_button = new Button();
            play_button.Text = "PLAY";
            play_button.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            play_button.AutoSize = true;
            play_button.Enabled = true;
            play_button.Location = new Point(445, 300);
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
        String name;
        private void play_button_Click(object sender, EventArgs e)
        {
            name = textBox.Text;
            play_button.Visible = false;
            label.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            textBox.Visible = false;
            
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
            if (!playing)
            {
                if (e.Button == MouseButtons.Right)
                {
                    sender.Image = shipImages[sender.shipSize + (2 * (sender.direction == 0 ? 1 : -1))];
                    sender.direction = sender.Height == 40 ? 1 : 0;
                    sender.Size = new Size(sender.Height, sender.Width);
                }
            }
        }

        // moving of each ship       
        bool dragging = false;
        int x, y;
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = true;
                    x = e.X;
                    y = e.Y;
                }
            }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                Control c = sender as Control;

                if (dragging && c != null)
                {
                    c.Top += e.Y - y;
                    c.Left += e.X - x;
                }
            }
        }

        private void Picture_MouseUp(dynamic sender, MouseEventArgs e)
        {
            if (!playing)
            {
                Ship p = sender as Ship;
                p.move(ref MyShips);
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
                            if (p.Location.X >= boardSize[i] && p.Location.X < boardSize[i + 1] && p.Location.Y >= boardSize[j] && p.Location.Y < boardSize[j + 1] )
                            {
                                if (i < 11 - size * (1 ^ d) && j < 11 - size * d)
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
                            else if ((p.Location.X >= boardSize[10] && p.Location.Y >= boardSize[j]) && p.Location.Y <= boardSize[j + 1] || (p.Location.Y >= boardSize[10] && p.Location.X >= boardSize[i] && p.Location.X <= boardSize[i + 1]))
                            {
                                int k = (i * d + j * (1 ^ d)) + size - 10; // poso exei bgei exo to ploio
                                lockL(p, i - (k * (1 ^ d)), j - (k * d), size);
                                break;
                            }
                        }
                    }
                }
            }
        }

        // check that the ships don't intersect and lock the ship into position
        private void lockL(Ship p, int x, int y, int size)
        {
            if (check(x, y, p.direction, p.shipSize))
            {
                Console.WriteLine(x + " " + y);
                p.SetPosition(ref MyShips, x, y);
                p.Location = new Point(boardSize[x], boardSize[y]);
            }
            else
                p.Location = new Point(boardSize[0], boardSize[0]);
            print(MyShips);
        }

        // check if there is another ship
        private bool check(int x, int y, int d, int shipSize)
        {
            int z = 0;
            int x1 = x;
            int y1 = y;

            for (int i = 0; i < shipSize; i++)
            {
                if (!MyShips[y1, x1])
                {
                    z++;
                    x1 += 1 ^ d;
                    y1 += d;
                }
            }

            if (z != shipSize)
                return false;
            else
                return true;
        }

        private void print(bool[,] map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string x = " ";
                    if (map[i, j])
                        x = "1";
                    else
                        x = " ";
                    Console.Write(x + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n\n");
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            foreach (Ship s in shipList)
            {
                s.ClearPosition(ref MyShips);
                s.Location = new Point(0, 0);
            }
            print(MyShips);
        }

        // play button 2
        bool playing = false;
        private void Play_Btn_Click(object sender, EventArgs e)
        {
            foreach (Ship s in shipList)
                if (s.getOk())
                    ship_count++;
                else
                {
                    ship_count = 0;
                    break;
                }
            
                if (ship_count == 4)
                {
                    playing = true;
                    tries = 0;
                    timer1.Start();
                    create_enemy_board();
                    enemy.Play(ref MyShips);
                }
                else
                {
                    MessageBox.Show("You must place all ships on the board!");
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        }

        Panel panel6 = new Panel();
        public void create_enemy_board()
        {
            panel3.Visible = false;
            panel4.Location = new Point(0, 0);
            Clear_Btn.Visible = false;
            Play_Btn.Visible = false;

            Panel panel5 = new Panel();
            panel5.Location = new Point(panel4.Location.X + panel4.Width + 20, panel4.Location.Y);
            panel5.Size = panel4.Size;
            panel5.BackColor = panel4.BackColor;
            panel2.Controls.Add(panel5);

            panel6.Location = panel1.Location;
            panel6.Size = panel1.Size;
            panel6.BackgroundImage = panel1.BackgroundImage;
            panel6.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Controls.Add(panel6);
            panel6.MouseClick += new MouseEventHandler(panel6_Click);

            Label label20 = new Label();
            label20.Text = label1.Text;
            label20.Location = label1.Location;
            label20.Size = label1.Size;
            panel5.Controls.Add(label20);

            Label label21 = new Label();
            label21.Text = "Αντίπαλος";
            label21.Location = label13.Location;
            label21.Size = new Size(150, 32);
            panel5.Controls.Add(label21);

            Panel p = new Panel
            {
                Size = panel_abc.Size,
                Location = panel_abc.Location,
                BackgroundImage = panel_abc.BackgroundImage,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = panel_abc.BackColor
            };
            panel5.Controls.Add(p);

            print(enemyShips);  
        }

        // I hit the enemy board
        bool game_end = false;
        bool who_hit;
        private async void panel6_Click(object sender, EventArgs e)
        {
            who_hit = false; //false = emeis xtipisame
            bool b_hit = true; //an exoume paijei
            String win = null;
            PictureBox p = new PictureBox();
            p.Size = new Size(panel6.Width / 12, panel6.Height / 12);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            int hit_x = 0;
            int hit_y = 0;
            MouseEventArgs hit = (MouseEventArgs)e;
            for (int i = 0; i <= 10; i++)
                for (int j = 0; j <= 10; j++)
                    if (hit.X >= boardSize[i] && hit.X < boardSize[i + 1] && hit.Y >= boardSize[j] && hit.Y < boardSize[j + 1])
                    {
                        hit_x = i;
                        hit_y = j;
                    }

            p.Location = new Point(boardSize[hit_x], boardSize[hit_y]);
            if (myHits[hit_y, hit_x] == null && enemyShips[hit_y, hit_x] == true)
            {
                tries++;
                who_hit = false;
                myHits[hit_y, hit_x] = true;
                p.Image = Image.FromFile("Images/Red_X.png");
                panel6.Controls.Add(p);
                if (Hit(hit_y, hit_x, enemy.EnShip))
                {
                    win = "Νίκησες!";
                    wins++;
                    timer1.Stop();
                    SaveData(1);
                    game_end = true;
                }
            }
            else if (myHits[hit_y, hit_x] == null && enemyShips[hit_y, hit_x] == false)
            {
                tries++;
                who_hit = false;
                myHits[hit_y, hit_x] = false;
                p.Image = Image.FromFile("Images/Green_Dash.png");
                panel6.Controls.Add(p);
            }
            else if (myHits[hit_y, hit_x] == true || myHits[hit_y, hit_x] == false)
            {
                b_hit = false;
            }

            // ---------------------------- When enemy hits my ships ----------------------------
            if (b_hit)
            {
                who_hit = true;
                await Task.Delay(500);
                int[] a = enemy.GetMove();
                PictureBox p1 = new PictureBox();
                p1.Size = new Size(panel6.Width / 12, panel6.Height / 12);
                p1.SizeMode = PictureBoxSizeMode.StretchImage;
                p1.BackColor = Color.Transparent;
                p1.Location = new Point(boardSize[a[0]], boardSize[a[1]]);

                if (enemyHits[a[1], a[0]] == null && MyShips[a[1], a[0]] == true)
                {
                    enemyHits[a[1], a[0]] = true;
                    p1.Image = Image.FromFile("Images/Red_X.png");
                }
                else if (enemyHits[a[1], a[0]] == null && MyShips[a[1], a[0]] == false)
                {
                    enemyHits[a[1], a[0]] = false;
                    p1.Image = Image.FromFile("Images/Green_Dash.png");
                }
                panel1.Controls.Add(p1);
                p1.BringToFront();

                if (Hit(a[1], a[0], shipList))
                {
                    win = "Έχασες...";
                    loses++;
                    timer1.Stop();
                    SaveData(0);
                    game_end = true;
                }

                if (game_end)
                {
                    timer1.Stop();
                    Console.WriteLine(name, time.ToString());
                    Form2 form2 = new Form2(win);
                    form2.GetData(time, tries, wins, loses);
                    form2.ShowDialog();
                    Hide();
                }
            }
        }


        private bool Hit(int y, int x, List<Ship> ships)
        {
            bool b = false;
            int dead = 0;
            foreach (Ship s in ships)
            {
                foreach (int[] c in s.coordinates)
                {
                    if (c[0] == x && c[1] == y)
                    {
                        s.SumHits(who_hit);
                        break;
                    }
                }
                if (!s.alive)
                {
                    dead++;
                    if (dead == 4)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SaveData(int win)
        {
            string sqliteString = "Data Source = BattleshipData.db";
            using (var connection = new SQLiteConnection(sqliteString))
            {
                connection.Open();

                string createTable = "CREATE TABLE IF NOT EXISTS Data (Id INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, WIN INTEGER, TIME TEXT);";
                using (var command = new SQLiteCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                string insertData = "INSERT INTO Data (NAME, WIN, TIME) VALUES (@Name, @Win, @Time);";
                using (var command = new SQLiteCommand(insertData, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Win", win);
                    command.Parameters.AddWithValue("@Time", time.ToString() + "sec");
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}