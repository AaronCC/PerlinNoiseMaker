#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
#endregion


namespace NoiseDemo.Menus.Buttons
{
    public class GenerateButton : Button
    {
        public GenerateButton(Vector2 _position, string _name)
            : base(_position, _name)
        {

        }

        public override void ClickEvent()
        {
            string name;
            List<Elements.Texture> textures = new List<Elements.Texture>();
            Point size;
            Rectangle drawRegion;
            int oc;
            name = "Basic";
            textures.Add(Managers.AssetManager.GetTextureAsset("BlackBack"));
            size = new Point(500, 500);
            drawRegion = new Rectangle(0, 0,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            oc = 5;
            if (Managers.Executive.menuStack.Peek() != null)
            {
                Managers.Executive.menuStack.Pop();
            }
            Managers.Executive.NewMap(name, textures, size, drawRegion, 5);
            
        }
    }
}
