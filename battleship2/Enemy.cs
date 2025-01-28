using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship2
{
    internal class Enemy
    {
        private Queue<int[]> moves = new Queue<int[]>();
        public List<Ship> EnShip = new List<Ship>();

        public Enemy(ref bool[,] enemyShip)
        {
            Random random = new Random();
            int x;
            int y;
            int d = 0;

            for (int size = 2; size <= 5; size++)
            {
                do
                {
                    x = random.Next(0, 10);//[0, 10)
                    y = random.Next(0, 10);//[0, 10)
                    d = random.Next(0, 2);//[0, 2)
                    if ((x + (size * (1 ^ d)) <= 9) && (y + (size * d) <= 9) && CheckOver(ref enemyShip, x, y, ref d, ref size))
                    {
                        Ship ship = new Ship(size);
                        ship.direction = d;
                        ship.SetPosition(ref enemyShip, x, y);
                        EnShip.Add(ship);
                        break;
                    }
                } while (true);
            }
        }

        private bool CheckOver(ref bool[,] map, int x, int y, ref int d, ref int size)
        {
            for (int i = 1; i <= size; i++)
            {
                if (map[y, x])
                    return false;
                x += 1 ^ d;
                y += d;
            }
            return true;
        }

        public void Play(ref bool[,] mySh)
        {
            Random r = new Random();
            List<int[]> list = new List<int[]>();
            int x, y;
            int sumW = 0;
            int m3 = 0;
            do
            {
                do
                {
                    x = r.Next(0, 10);
                    y = r.Next(0, 10);
                } while (where(x, y, list) && sumW < 14 && m3 <= 100);
                list.Add(new int[] { x, y });
                m3++;
                Console.WriteLine(m3 + ": " + x + " " + y);
                moves.Enqueue(new int[] { x, y });
                if (mySh[y, x])
                {
                    sumW++;
                    Console.WriteLine(x + " " + y);
                }
            } while (sumW <= 14 && m3 <= 100);
            Console.WriteLine("Win! sum: " + sumW + " m3: " + m3);
        }

        private bool where(int x, int y, List<int[]> l)
        {
            foreach (int[] i in l)
                if (x == i[0] && y == i[1])
                    return true;
            return false;
        }

        public int[] GetMove()
        {
            return moves.Dequeue();
        }
    }
}