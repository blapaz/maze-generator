using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Noise { get; set; }

        class Point
        {
            public int Y { get; set; } = 0;
            public int X { get; set; } = 0;
        }

        public void Generate()
        {
            bool[,] map = new bool[Height, Width];
            
            // Generates a start point in the top row
            //  * Will not chose a corner as a the point
            Random r = new Random();            
            int startPoint = r.Next(1, Width - 2);

            // Set start and end points to true in map
            Point point = new Point
            {
                X = startPoint
            };
            map[point.Y, point.X] = true;

            // Move the point down one to start
            point = MovePoint(map, point, 0);
            map[point.Y, point.X] = true;

            bool isComplete = false;
            while (!isComplete)
            {
                Point tempPoint = MovePoint(map, point, r.Next(3));

                if (!map[tempPoint.Y, tempPoint.X])
                {
                    map[point.Y, point.X] = true;
                }

                if (point.Y + 1 > Height - 1)
                {
                    isComplete = true;
                }
            }

            // Prints out the map with the guarenteed path
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(map[y, x] ? ". " : "X ");
                }
                Console.WriteLine();
            }

            // Loops through all indexes inside the boarder
            for (int y = 1; y < Height - 1; y++)
            {
                for (int x = 1; x < Width - 1; x++)
                {
                    // Only deal with indexes that are not part of the guarenteed path
                    if (!map[y, x])
                    {
                        int score = 0;

                        if (!map[y - 1, x]) score++;
                        if (!map[y + 1, x]) score++;
                        if (!map[y, x + 1]) score++;
                        if (!map[y, x + 1]) score++;

                        if (score > 2)
                        {
                            if (r.Next(11) > Noise)
                            {
                                map[y, x] = true;
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine();

            // Prints out the map with the guarenteed path
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(map[y, x] ? ", " : "X ");
                }
                Console.WriteLine();
            }
        }

        Point MovePoint(bool[,] map, Point point, int direction)
        {
            switch (direction)
            {
                case 0:
                    // Move down
                    point.Y += 1;
                    break;
                case 1:
                    // Is inside the left wall
                    if (point.X - 1 > 0)
                    {
                        if (!map[point.Y - 1, point.X - 1])
                        {
                            // Move left
                            point.X -= 1;
                        }
                    }
                    break;
                case 2:
                    // Is inside the right wall
                    if (point.X + 1 < Width - 1)
                    {
                        if (!map[point.Y - 1, point.X + 1])
                        {
                            // Move right
                            point.X += 1;
                        }
                    }
                    break;
            }

            return point;
        }

    }
}
