#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace NoiseDemo.Noise
{
    public class Noise
    {
        Random random;
        public double[,] GeneratePerlinNoise(double[,] baseNoise, int octaveCount)
        {
            int width = baseNoise.GetLength(0);
            int height = baseNoise.GetLength(1);

            double[][,] smoothNoise = new double[octaveCount][,];

            double persistance = 0.5;

            for (int i = 0; i < octaveCount; i++)
            {
                smoothNoise[i] = GenerateSmoothNoise(baseNoise, i);
            }

            double[,] perlinNoise = new double[width, height];
            double amplitude = 1.0;
            double totalAmplitude = 0.0;

            for (int octave = octaveCount - 1; octave >= 0; octave--)
            {
                amplitude *= persistance;
                totalAmplitude += amplitude;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        perlinNoise[i, j] += smoothNoise[octave][i, j] * amplitude;
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    perlinNoise[i, j] /= totalAmplitude;
                }
            }
            return perlinNoise;
        }
        public double[,] GenerateWhiteNoise(int width, int height)
        {
            random = new Random(Guid.NewGuid().GetHashCode());
            double[,] whiteNoise = new double[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    whiteNoise[i, j] = random.NextDouble() % 1;
                }
            }
            return whiteNoise;
        }
        public double[,] GenerateSmoothNoise(double[,] baseNoise, int octave)
        {
            int width = baseNoise.GetLength(0);
            int height = baseNoise.GetLength(1);
            double[,] smoothNoise = new double[width, height];
            int samplePeriod = 1 << octave;
            double sampleFrequency = 1.0 / samplePeriod;

            for (int i = 0; i < width; i++)
            {
                int i0 = (i / samplePeriod) * samplePeriod;
                int i1 = (i0 + samplePeriod) % width;
                double horizontal_blend = (i - i0) * sampleFrequency;
                for (int j = 0; j < height; j++)
                {
                    int j0 = (j / samplePeriod) * samplePeriod;
                    int j1 = (j0 + samplePeriod) % height;
                    double vertical_blend = (j - j0) * sampleFrequency;

                    double top = Interpolate(baseNoise[i0, j0], baseNoise[i1, j0], horizontal_blend);
                    double bottom = Interpolate(baseNoise[i0, j1], baseNoise[i1, j1], horizontal_blend);

                    smoothNoise[i, j] = Interpolate(top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        public double Interpolate(double x0, double x1, double alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }

        public Elements.Map MakeTextureMap(List<Elements.Texture> textures, Point size, Rectangle drawRegion, int octaveCount)
        {
            Elements.TextureMap map = new Elements.TextureMap(
                size,
                drawRegion,
                GeneratePerlinNoise(GenerateWhiteNoise(size.X, size.Y), octaveCount),
                textures);
            return map;
        }
    }
}
