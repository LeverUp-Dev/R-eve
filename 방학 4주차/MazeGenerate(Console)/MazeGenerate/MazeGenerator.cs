using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeGenerate
{
    class MazeGenerator
    {
        Stage[,] map;
        private readonly int xRange, yRange;
        public MazeGenerator(Stage[,] map)
        {
            this.map = map;
            xRange = map.GetLength(0) - 3;
            yRange = map.GetLength(1) - 2;

            Task Horizontal = new Task(() =>
            {
                for (int i = 0; i < xRange; i += 2)
                {
                    if (i > 2 && (i / 2) % 2 == 0)
                    {
                        for (int j = 0; j < yRange; j++)
                        {
                            map[i, j] = Stage.Wall;
                            map[i + 1, j] = Stage.Wall;
                        }
                    }
                    else
                    {
                        map[i, 0] = Stage.Wall;
                        map[i + 1, 0] = Stage.Wall;
                    }
                }
            });
            Task Vertical = new Task(() =>
            {
                for (int i = 0; i <= yRange; i++)
                {
                    map[0, i] = Stage.Wall;
                    map[1, i] = Stage.Wall;
                    if (i > 0 && i % 2 == 0) for (int j = 2; j < xRange; j++) map[j, i] = Stage.Wall;
                }
            });
            Horizontal.Start();
            Vertical.Start();
            Task.WaitAll(Horizontal, Vertical);

            map[2, 0] = Stage.Start;
            map[3, 0] = Stage.Start;
            map[xRange - 2, yRange] = Stage.Goal;
            map[xRange - 3, yRange] = Stage.Goal;
        }

        private struct Point
        {
            public int x, y;
            public void Censor(int x, int y)
            {
                this.x = x; this.y = y;
            }
        }

        // 첫번째 방법, 가지 치기(BinaryTree).
        public void BinaryTree()
        {    
            Random rand = new Random();
            for (int i = xRange - 3; i > 4; i -= 4)
            {
                for (int j = yRange - 1; j > 1; j -= 2)
                {
                    if (rand.Next(2) == 1)
                    {
                        map[i - 1, j] = Stage.Room;
                        map[i - 2, j] = Stage.Room;

                    }
                    else
                    {
                        map[i, j - 1] = Stage.Room;
                        map[i + 1, j - 1] = Stage.Room;
                    }
                }
            }
            for (int i = 4; i < xRange - 3; i += 4)
            {
                map[i, 1] = Stage.Room;
                map[i + 1, 1] = Stage.Room;
            }
            for (int i = 2; i < yRange - 1; i += 2)
            {
                map[2, i] = Stage.Room;
                map[3, i] = Stage.Room;
            }
        }

        public void BackTracking()
        {
            int x = 2, y = 1;
            List<Point> track = new List<Point>();
            HashSet<Point> visited = new HashSet<Point>();
            Random rand = new Random();
            Point p = new Point();
            bool[] isBlock = new bool[4];

            p.Censor(x, y);
            track.Add(p);
            while (true)
            {
                if (IsAllTrue(isBlock))
                {
                    visited.Add(track[track.Count - 1]);
                    track.RemoveAt(track.Count - 1);
                    if (track.Count < 1) break;

                    x = track[track.Count - 1].x;
                    y = track[track.Count - 1].y;
                    Clear(isBlock);
                }
                int r = rand.Next(4); // 방향을 무작위 할당

                if (r == 0)
                {
                    p.Censor(x, y + 2);
                    if (p.y > yRange || track.Contains(p) || visited.Contains(p)) isBlock[r] = true;
                    else
                    {
                        map[x, y + 1] = Stage.Room;
                        map[x + 1, y + 1] = Stage.Room;

                        track.Add(p);
                        y = p.y;
                        Clear(isBlock);
                    }
                }
                else if (r == 1)
                {
                    p.Censor(x + 4, y);
                    if (p.x > xRange || track.Contains(p) || visited.Contains(p)) isBlock[r] = true;
                    else
                    {
                        map[x + 2, y] = Stage.Room;
                        map[x + 3, y] = Stage.Room;

                        track.Add(p);
                        x = p.x;
                        Clear(isBlock);
                    }
                }
                else if (r == 2)
                {
                    p.Censor(x, y - 2);
                    if (p.y < 0 || track.Contains(p) || visited.Contains(p)) isBlock[r] = true;
                    else
                    {
                        map[x, y - 1] = Stage.Room;
                        map[x + 1, y - 1] = Stage.Room;

                        track.Add(p);
                        y = p.y;
                        Clear(isBlock);
                    }
                }
                else if (r == 3)
                {
                    p.Censor(x - 4, y);
                    if (p.x < 0 || track.Contains(p) || visited.Contains(p)) isBlock[r] = true;
                    else
                    {
                        map[x - 1, y] = Stage.Room;
                        map[x - 2, y] = Stage.Room;

                        track.Add(p);
                        x = p.x;
                        Clear(isBlock);
                    }
                }
            }
        }

        void Clear(bool[] isBlock){ for (int j = 0; j < isBlock.Length; ++j) isBlock[j] = false; }
        bool IsAllTrue(bool[] isBlock) { for (int j = 0; j < isBlock.Length; ++j) if (!isBlock[j]) return false; return true; }
    }
}