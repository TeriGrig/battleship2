using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace battleship2
{
    internal class Ship : PictureBox
    {
        public readonly int shipSize;
        public List<int[]> coordinates = new List<int[]>();
        private bool m = false;
        bool ok = false;
        // Horizontal 0
        public bool alive;
        public int direction = 0;
        public int sumOfHits = 0;
        public List<string> names = new List<string>() {"Υποβρύχιο", "Πολεμικό", "Αντιτορπιλικό", "Αεροπλανοφόρο"};

        public Ship(int shipSize)
        {
            alive = true;
            this.shipSize = shipSize;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Height = 40;
            Width = 40 * shipSize;
            BackColor = Color.Transparent;
        }

        public bool getOk()
        {
            return ok;
        }


        public void move(ref bool[,] map)
        {
            if (m)
            {
                // if it has been already moved
                foreach (var c in coordinates)
                {
                    map[c[1], c[0]] = false;
                }
                coordinates.Clear();
                ok = false;
            }
        }

        public void SetPosition(ref bool[,] map, int x, int y)
        {
            ok = true;
            m = true;
            coordinates.Add(new int[] { x, y });
            map[y, x] = true;
            for (int i = 1; i < shipSize; i++)
            {
                x += 1 ^ direction;
                y += direction;
                coordinates.Add(new int[] { x, y });
                map[y, x] = true;
            }
        }

        public void ClearPosition(ref bool[,] map)
        {
            foreach (var c in coordinates)
            {
                map[c[1], c[0]] = false;
            }
            coordinates.Clear();
        }

        public void SumHits(bool w)
        {
            sumOfHits++;
            if (sumOfHits == shipSize)
            {
                if (!w)
                    MessageBox.Show("Βύθισες το " + names[shipSize-2] + " του αντιπάλου!");
                else
                    MessageBox.Show("Βυθίστηκε το " + names[shipSize - 2] + " σου!");
                alive = false;
            }
        }
    }
}
