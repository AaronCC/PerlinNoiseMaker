#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion
namespace NoiseDemo.Managers
{
    public static class Executive
    {
        public static Stack<Menus.GameMenu> menuStack;
        public static Dictionary<string, Elements.Map> maps;
        static Noise.Noise noiseMaker;

        public static Dictionary<string, Menus.GameMenu> menus;
        public static Menus.GameMenu GetMenu(string name) { return menus[name]; }

        public static void Initialize()
        {
            noiseMaker = new Noise.Noise();
            menus = new Dictionary<string, Menus.GameMenu>();
            maps = new Dictionary<string, Elements.Map>();
            menuStack = new Stack<Menus.GameMenu>();
        }
        public static void Update()
        {
            if (menuStack.Count > 0)
                menuStack.Peek().Update();
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (menuStack.Count > 0)
                menuStack.Peek().Draw(spriteBatch);
            foreach (KeyValuePair<string, Elements.Map> pair in maps)
            {
                pair.Value.Draw(spriteBatch);
            }
        }

        public static void NewMap(string name, List<Elements.Texture> textures, Point size, Rectangle drawRegion, int oc)
        {
            maps.Add(name, noiseMaker.MakeTextureMap(textures, size, drawRegion, oc));
        }

    }
}
