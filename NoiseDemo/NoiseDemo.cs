#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
#endregion

namespace NoiseDemo
{
    
    public class NoiseDemo : Game
    {
        #region TempVars
        #endregion
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 virtualResolution;
        public static int state;
        public NoiseDemo()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            state = 0;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = false;
            virtualResolution = new Vector2(1920, 1080);
            Managers.ScreenManager.Initialize(virtualResolution, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            #region TestMap
            //Texture2D back_1;
            //Texture2D back_2;
            //back_1 = Content.Load<Texture2D>("Textures/BlackBack.png");
            //back_2 = Content.Load<Texture2D>("Textures/WhiteBack.png");
            //Managers.AssetManager.Initialize();

            //List<Elements.Texture> tempTextures = new List<Elements.Texture>();
            //tempTextures.Add(Managers.AssetManager.MakeTexture("back_1", back_1, 1, 1, 1));
            //tempTextures.Add(Managers.AssetManager.MakeTexture("back_2", back_2, 1, 1, 1));
            //Managers.Executive.NewMap(
            //    "test",
            //    tempTextures,
            //    new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 5, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 5),
            //    new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height),
            //    5);
            #endregion

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Managers.AssetManager.Initialize();
            Managers.Executive.Initialize();
            Managers.User.Initialize();
            System.IO.StreamReader reader;
            string[] files;
            
            files = Directory.GetFiles("../../../Content/TextureData");
            foreach(string fileName in files)
            {
                reader = new System.IO.StreamReader(fileName);
                foreach(KeyValuePair<string,string> csv in Managers.Parser.ParseAsset(reader))
                {
                    Texture2D texture;
                    string data;
                    texture = Content.Load<Texture2D>("Textures/" + csv.Value.Split('_')[0]);
                    data = csv.Value.Substring(csv.Value.IndexOf('_') + 1, (csv.Value.Length - csv.Value.IndexOf('_')) - 1);
                    Managers.AssetManager.CreateTextureAsset(csv.Key, data, texture);
                }
            }
            files = Directory.GetFiles("../../../Content/MenuData");
            foreach (string fileName in files)
            {
                Menus.GameMenu menu;
                reader = new System.IO.StreamReader(fileName);
                menu = Managers.Parser.ParseMenuData(reader);
                Managers.Executive.menus.Add(menu.name, menu);
            }
            newDemo();
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Managers.User.Update();
            Managers.Executive.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Managers.ScreenManager.scale);
            Managers.Executive.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void newDemo()
        {
            Managers.Executive.menuStack.Push(Managers.Executive.GetMenu("MainMenu"));
        }
    }
}
