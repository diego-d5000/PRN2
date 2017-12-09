using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    class PGMFile
    {
        private byte[,] pixels;

        public PGMFile()
        {
        }

        public PGMFile(PGMType type, int height, int width, byte[,] pixels)
        {
            this.pixels = pixels;
            Type = type;
            Height = height;
            Width = width;
        }

        public PGMType Type
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public long ImageSize => Width * Height;

        public int Colors => 255;

        public byte[,] Pixels
        {
            get => pixels;
            set => pixels = value;
        }

        public void IncreaseBrightness(byte nColor)
        {
            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    byte sum = Pixels[i, j] + nColor < 256 ? (byte) (Pixels[i, j] + nColor) : (byte) 255;
                    Pixels[i,j] = sum;
                }
            }
        }

        public void IncreaseBrightness()
        {
            IncreaseBrightness(10);
        }
    }
}
