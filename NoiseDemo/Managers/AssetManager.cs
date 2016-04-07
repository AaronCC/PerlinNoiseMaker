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
    public static class AssetManager
    {
        static Dictionary<string, Elements.Texture> textures;

        static Elements.Texture texture;
        static string[] split;

        public static void Initialize()
        {
            textures = new Dictionary<string, Elements.Texture>();
        }

        public static void CreateTextureAsset(string name, string data, Texture2D sprite)
        {
            int i = 0;
            int[] vertData = new int[3];
            split = data.Split(',');
            foreach (string csv in split)
            {
                vertData[i] = Convert.ToInt32(csv);
                i++;
            }
            texture = new Elements.Texture(name, sprite, vertData[0], vertData[1], vertData[2]);
            textures.Add(name, texture);
        }
        public static Elements.Texture MakeTexture(string name, Texture2D texture, int row, int col, int mpf)
        {
            Elements.Texture newTexture = new Elements.Texture(name, texture, row, col, mpf);
            textures.Add(newTexture.name, newTexture);
            return newTexture;
        }
        public static Elements.Texture GetTextureAsset(string name) { return textures[name]; }

        
    }
}
