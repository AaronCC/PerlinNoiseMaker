#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace NoiseDemo.Menus
{
    public class GameMenu
    {
        public List<Buttons.Button> buttons;
        public Elements.Texture texture;
        public string name;
        public bool themePlaying;
        
        public GameMenu(string _name, List<Buttons.Button> _buttons)
        {
            name = _name;
            buttons = _buttons;
            texture = Managers.AssetManager.GetTextureAsset(name);
        }
        public void Update()
        {
            foreach(Buttons.Button btn in buttons)
            {
                if (Managers.User.mHitBox.Intersects(btn.hitBox) && !btn.flagged)
                {
                    btn.flagged = true;
                }
                else if (!Managers.User.mHitBox.Intersects(btn.hitBox))
                    btn.flagged = false;
                
                if(Managers.User.mState.LeftButton == ButtonState.Pressed
                    && Managers.User.old_mState.LeftButton == ButtonState.Released
                    && btn.flagged)
                {
                    btn.ClickEvent();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture.sprite, new Vector2(0, 0), Color.White);
            foreach(Buttons.Button btn in buttons)
            {
                if (btn.flagged)
                    spriteBatch.Draw(btn.texture.sprite, btn.position, Color.White);
                else
                    spriteBatch.Draw(btn.texture.sprite, btn.position, Color.White * 0.6f);
            }
        }
    }
}
