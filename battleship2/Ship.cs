using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace battleship2
{
    internal class Ship : PictureBox
    {
        public readonly int shipSize;
        private List<int[]> coordinates = new List<int[]>();
        private bool m = false;
        bool ok = false;
        // Horizontal 0
        public int direction = 0;
        int sumOfHits = 0;

        public Ship(int shipSize)
        {
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

        private void SumHits(int sum)
        {
            sum++;
        }
    }
}
