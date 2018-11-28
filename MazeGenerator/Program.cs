using CommandLine;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace MazeGenerator
{
    class Program
    {
        public class Options
        {
            [Option('w', "width", Required = false, Default = 10, HelpText = "Set the width of the maze that will be generated.")]
            public int Width { get; set; }

            [Option('h', "height", Required = false, Default = 10, HelpText = "Set the height of the maze that will be generated.")]
            public int Height { get; set; }

            [Option('n', "noise", Required = false, Default = 5, HelpText = "Set the noise of the maze that will be generated.")]
            public int Noise { get; set; }

            [Option('p', "path", Required = false, HelpText = "Set the path where the maze file will be created.")]
            public string Path { get; set; }

            [Option('d', "debug", Required = false, Default = false, HelpText = "If enabled output will show in the console and remain open.")]
            public bool Debug { get; set; }
        }

        static void Main(string[] args)
        {
            Maze maze = new Maze();
            string path = Directory.GetCurrentDirectory();
            bool isDebug = false;
            bool shouldView = false;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    maze.Width = o.Width;
                    maze.Height = o.Height;
                    maze.Noise = o.Noise;

                    if (o.Path != null)
                        path = o.Path;

                    isDebug = o.Debug;
                    shouldView = o.View;
                });

            if (isDebug)
                Console.WriteLine("Generating Maze");

            bool[,] map = maze.Generate(isDebug); 

            Bitmap bmp = new Bitmap(maze.Width, maze.Height);

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    bmp.SetPixel(x, y, map[y, x] ? Color.White : Color.Black);
                }
            }

            string img = Path.Combine(path, "maze-" + maze.Height + "_" + maze.Width + ".png");
            bmp.Save(img, System.Drawing.Imaging.ImageFormat.Png);

            if (isDebug)
            {
                Console.WriteLine("Generation Complete");
                Console.Read();
            }
        }
    }
}
