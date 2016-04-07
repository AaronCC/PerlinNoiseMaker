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

namespace NoiseDemo.Managers
{
    public static class User
    {
        public static KeyboardState kState;
        public static MouseState mState;
        public static KeyboardState old_kState;
        public static MouseState old_mState;
        public static Point mousePos;
        public static Rectangle mHitBox;

        public static void Initialize()
        {
            kState = new KeyboardState();
            old_kState = new KeyboardState();
            mState = new MouseState();
            old_mState = new MouseState();
            mState = Mouse.GetState();
            kState = Keyboard.GetState();
            mousePos.X = (int)(mState.Position.X / Managers.ScreenManager.scalingFactor.X);
            mousePos.Y = (int)(mState.Position.Y / Managers.ScreenManager.scalingFactor.Y);
            mHitBox = new Rectangle(mousePos.X, mousePos.Y, 2, 2);
        }

        public static void Update()
        {
            old_mState = mState;
            old_kState = kState;
            mState = Mouse.GetState();
            kState = Keyboard.GetState();
            mousePos.X = (int)(mState.Position.X / Managers.ScreenManager.scalingFactor.X);
            mousePos.Y = (int)(mState.Position.Y / Managers.ScreenManager.scalingFactor.Y);
            mHitBox = new Rectangle(mousePos.X, mousePos.Y, 1, 1);

        }
    }
    
}
