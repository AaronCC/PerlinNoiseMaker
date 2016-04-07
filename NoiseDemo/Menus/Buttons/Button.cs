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
namespace NoiseDemo.Menus.Buttons
{
    public class Button
    {
        public bool flagged;

        public Vector2 position;

        public Rectangle hitBox;

        public string name;

        public Elements.Texture texture;

        public Button(Vector2 _position, string _name)
        {
            name = _name;
            position = _position;
            flagged = false;
            texture = Managers.AssetManager.GetTextureAsset(name);
            hitBox = new Rectangle((int)position.X, (int)position.Y, texture.sprite.Width, texture.sprite.Height);
        }
        public virtual void ClickEvent()
        {

        }
    }
}
