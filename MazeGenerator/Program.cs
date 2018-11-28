using CommandLine;
using System;

namespace MazeGenerator
{
    class Program
    {
        public class Options
        {
            [Option('w', "width", Required = false, HelpText = "Set the width of the maze that will be generated.")]
            public string Width { get; set; }

            [Option('h', "height", Required = false, HelpText = "Set the height of the maze that will be generated.")]
            public string Height { get; set; }

            [Option('s', "size", Required = false, HelpText = "Set the size of the maze that will be generated (width,height).")]
            public string Size { get; set; }

            [Option('n', "noise", Required = false, HelpText = "Set the noise of the maze that will be generated.")]
            public string Noise { get; set; }

            [Option('p', "path", Required = false, HelpText = "Set the path where the maze file will be created.")]
            public string Path { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    Console.WriteLine("Path Set: " + o.Path);
                });

            Console.Read();
        }
    }
}
