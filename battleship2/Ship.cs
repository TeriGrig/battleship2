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

        public bool SetPosition(ref bool[,] map, int y, int x)
        {
            int z = 0;
            int x1 = x;
            int y1 = y;
            bool b = true;
            if (m)
            {
                foreach (var c in coordinates)
                {
                    map[c[1], c[0]] = false;
                }
                coordinates.Clear();
            }
            for (int i = 0; i < shipSize; i++)
            {
                if (!map[y1, x1])
                {
                    z++;
                    x1 += 1 ^ direction;
                    y1 += direction;
                }
            }
            if (z == shipSize)
            {
                for (int i = 0; i < shipSize; i++)
                {
                    coordinates.Add(new int[] { x, y });
                    map[y, x] = true;
                    x += 1 ^ direction;
                    y += direction;
                }
            }
            else if (z != shipSize)
            {
                for (int i = 0; i < shipSize; i++)
                {
                    coordinates.Add(new int[] { x * direction, y * (1 ^ direction) });
                    map[y, x] = true;
                    x += 1 ^ direction;
                    y += direction;
                }
                b = false;
            }
            m = true;
            return b;
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
