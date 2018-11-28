using CommandLine;
using System;
using System.IO;

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

            [Option('n', "noise", Required = false, Default = 2, HelpText = "Set the noise of the maze that will be generated.")]
            public int Noise { get; set; }

            [Option('p', "path", Required = false, HelpText = "Set the path where the maze file will be created.")]
            public string Path { get; set; }
        }

        static void Main(string[] args)
        {
            Maze maze = new Maze();
            string path = Directory.GetCurrentDirectory();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    maze.Width = o.Width;
                    maze.Height = o.Height;
                    maze.Noise = o.Noise;

                    if (o.Path.Length > 0)
                        path = o.Path;        
                });

            Console.WriteLine("Generating Maze");
            maze.Generate();
            Console.WriteLine("Generation Complete");

            Console.Read();
        }
    }
}
