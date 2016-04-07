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
    public class Map
    {
        public Rectangle drawRegion;
        public Point size;

        public Map(Point _size, Rectangle _drawRegion)
        {
            size = _size;
            drawRegion = _drawRegion;
        }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
