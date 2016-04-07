#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion


namespace NoiseDemo.Elements
{
    class TextureMap : Map
    {
        List<Texture> textures;
        Point tileIndex;
        Point tileSize;
        double[,] noise;

        public TextureMap(Point _size, Rectangle _drawRegion, double[,] _noise, List<Elements.Texture> _textures)
            : base(_size, _drawRegion)
        {
            noise = _noise;
            textures = _textures;
            size = _size;
            tileSize = new Point(drawRegion.Width / size.X, drawRegion.Height / size.Y);
            tileIndex = new Point();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {          
            Rectangle sample = new Rectangle(0, 0, tileSize.X, tileSize.Y);
            Rectangle drawRect = sample;
            int t = 0;
            //spriteBatch.Draw(textures[t + 1].sprite, new Rectangle(0, 0, drawRect.Width * size.X, drawRect.Height * size.Y), Color.White);
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    float transparency = (float)(noise[x, y]);
                    spriteBatch.Draw(textures[t].sprite, drawRect, sample, new Color(Color.White, transparency));

                    drawRect.X += tileSize.X;
                }
                drawRect.X = 0;
                drawRect.Y += tileSize.Y;
            }

        }
    }
}
