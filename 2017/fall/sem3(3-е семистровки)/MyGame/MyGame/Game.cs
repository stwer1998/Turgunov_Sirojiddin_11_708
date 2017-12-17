using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Game
    {
        static Random random = new Random();
        int size;
        int[,] map;
        int spaceX, spaceY;
        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        }
        public void Start()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = coords_to_position(x, y) + 1;
                }
            }            
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }
        public void shift(int position)
        {
            int x, y;
            possition_to_cords(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1) return;
            map[spaceX, spaceY] = map[x,y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y; 
        }
        public void shift_random()
        {
            //shift(random.Next(0, size * size));
            int a = random.Next(0, 4);
            int x = spaceX;
            int y = spaceY;
            switch (a)
            {
                case 0: x--;break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            shift(coords_to_position(x, y));
        }
        public bool check_numbers()
        {
            if (!(spaceX == size - 1 && spaceY == size - 1)) return false;
            for(int x = 0; x < size; x++)
            {
                for (int y = 0; y <size; y++)
                {
                    if (!(x == size - 1 && y == size - 1)) return true;
                    if (map[x, y] != coords_to_position(x, y) + 1) return false;
                }
            }
            return true;
        }
        public int get_number(int position)
        {
            int x, y;
            possition_to_cords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (x < 0 || y >= size) return 0;
            return map[x, y];
        }
        private int coords_to_position (int x,int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;
        }
        private void possition_to_cords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }
    }
}
