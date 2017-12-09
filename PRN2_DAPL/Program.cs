using System;
using System.Collections.Generic;
using System.IO;

namespace PRN2_DAPL
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = args[0];
            PGMFile pgmFile = new PGMFile();

            using (var imageFile = new StreamReader(imagePath))
            {
                try
                {
                    pgmFile.Type = (PGMType)Enum.Parse(typeof(PGMType), imageFile.ReadLine());
                    string sizeLine = imageFile.ReadLine();
                    sizeLine = sizeLine[0] == '#' ? imageFile.ReadLine() : sizeLine;
                    string[] size = sizeLine.Split("  ");
                    pgmFile.Width = int.Parse(size[0]);
                    pgmFile.Height = int.Parse(size[1]);
                    imageFile.ReadLine(); // skip line with max pixel value
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de imagen invalido");
                    Environment.Exit(1);
                }

                string line;
                byte[,] pixels = new byte[pgmFile.Width, pgmFile.Height];
                int helperCounterI = 0;
                int helperCounterJ = 0;

                while ((line = imageFile.ReadLine()) != null)
                {
                    string[] values = line.Split("  ");
                    foreach (string value in values)
                    {
                        try
                        {
                            pixels[helperCounterI, helperCounterJ] = byte.Parse(value);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato de imagen invalido");
                            Environment.Exit(1);
                        }
                        helperCounterJ = (helperCounterJ + 1) % pgmFile.Height;
                        if (helperCounterJ == 0)
                        {
                            helperCounterI++;
                        }
                    }
                }

                pgmFile.Pixels = pixels;
            }

            string imagePathNoExtension = Path.GetFileNameWithoutExtension(imagePath);
            string imageExtension = Path.GetExtension(imagePath);

            string nextImagePath = imagePathNoExtension + "_brighter" + imageExtension;

            pgmFile.IncreaseBrightness();

            using (var nextFile = new StreamWriter(nextImagePath))
            {
                nextFile.WriteLine(pgmFile.Type.ToString());
                nextFile.WriteLine(pgmFile.Width + "  " + pgmFile.Height);
                nextFile.WriteLine(pgmFile.Colors);

                for (int i = 0; i < pgmFile.Pixels.GetLength(0); i++)
                {
                    string line = "";
                    for (int j = 0; j < pgmFile.Pixels.GetLength(1); j++)
                    {
                        line += pgmFile.Pixels[i, j].ToString() + "  ";
                    }
                    nextFile.WriteLine(line);
                }
            }

            Console.WriteLine("Hecho!!");
            Console.ReadLine();
        }
    }
}
