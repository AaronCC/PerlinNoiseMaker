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

namespace NoiseDemo.Managers
{
    public static class Parser
    {
        public static void Initialize()
        {

        }
        public static Menus.GameMenu ParseMenuData(StreamReader file)
        {
            List<Menus.Buttons.Button> buttons = new List<Menus.Buttons.Button>();
            Menus.GameMenu menu;
            string name, line, bName;
            Vector2 position;
            string[] split;

            name = file.ReadLine().Split(':')[1];
            while ((line = file.ReadLine()) != null)
            {
                split = line.Split(':');
                bName = split[0];
                split = split[1].Split(',');
                position = new Vector2(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
                switch (bName)
                {
                    //Create buttons 'buttons.Add(button)'
                    case "GenerateButton":
                        buttons.Add(new Menus.Buttons.GenerateButton(position, bName));
                        break;
                    default:
                        buttons.Add(new Menus.Buttons.Button(position, bName));
                        break;
                }
            }
            file.Close();
            switch (name)
            {
                //Create menus 'menu = new...'
                default:
                    menu = new Menus.GameMenu(name, buttons);
                    break;
            }
            return menu;
        }
        public static Dictionary<string,string> ParseAsset(StreamReader file)
        {
            string line;
            Dictionary<string, string> assetDict = new Dictionary<string, string>();
            while ((line = file.ReadLine()) != null)
            {
                assetDict.Add(line.Split(':')[0], line.Split(':')[1]);
            }
            file.Close();
            return assetDict;
        }

    }
}
