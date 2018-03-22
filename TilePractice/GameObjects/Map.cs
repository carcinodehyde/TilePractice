using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TilePractice.GameObjects
{
    class Map
    {
        Texture2D Tiles;

        int[,] TileMap;

        int TileWidth = 32;
        int TileHeight = 32;

        private ContentManager Content;

        public Map(String name, ContentManager content, String tileName)
        {
            Content = content;

            LoadMapData(name);
            LoadTileTextures(tileName);
        }

        private void LoadTileTextures(String tileName)
        {

            Tiles = Content.Load<Texture2D>("Graphics/" + tileName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int x = 0; x < TileMap.GetLength(0); x++)
            {

                for (int y = 0; y < TileMap.GetLength(1); y++)
                {

                    spriteBatch.Draw(Tiles,
                        new Vector2(x * TileWidth, y * TileHeight),
                        new Rectangle((TileMap[x, y] % 8) * 32, (TileMap[x, y] / 8) * 32, 32, 32),
                        Color.White);
                }
            }
        }

        private void LoadMapData(String name)
        {

            String path = Path.Combine(Environment.CurrentDirectory + "\\MapLayouts\\" + name + ".csv");

            int width = 0;
            int height = File.ReadLines(path).Count();

            StreamReader sr = new StreamReader(path);

            string line = sr.ReadLine();
            string[] tileNo = line.Split(',');

            width = tileNo.Count();

            TileMap = new int[width, height];

            sr = new StreamReader(path);

            for (int y = 0; y < height; y++)
            {

                line = sr.ReadLine();
                tileNo = line.Split(',');

                for (int x = 0; x < width; x++)
                {

                    TileMap[x, y] = Convert.ToInt32(tileNo[x]);
                }
            }

            sr.Close();

        }
    }
}
