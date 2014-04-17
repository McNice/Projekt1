﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor
{
    public class Map
    {

        public readonly string dir = "../../../../../../Maps/";
        public int width, height;
        public Tile[,] tileArray;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            tileArray = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (tileArray[x, y] == null)
                        tileArray[x, y] = new Tile(new Vector2(x * Game1.tileSize, y * Game1.tileSize), Game1.BLANK);
                }
            }
        }

        public void EditTile(int x, int y, int type)
        {
            tileArray[x, y].SetType(type);
        }

        public void Draw(SpriteBatch sB)
        {
            foreach (Tile tile in tileArray)
            {
                if (tile != null)
                    tile.Draw(sB);
            }
        }

        public string[,] LoadMap(string mapName)
        {
            string[,] tempMap = new string[1, 1];
            int line = 0;

            try
            {
                StreamReader sR = new StreamReader(dir + mapName + ".txt");


                while (!sR.EndOfStream)
                {
                    string temp = sR.ReadLine();
                    if (temp.Contains('[') || temp.Contains(']'))
                    {
                        string[] arrayTemp = temp.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                        width = Convert.ToInt32(arrayTemp[0]);
                        height = Convert.ToInt32(arrayTemp[1]);
                        tempMap = new string[width, height];
                    }
                    else
                    {
                        string[] arrayTemp = temp.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int x = 0; x < width; x++)
                        {
                            tempMap[x, line] = arrayTemp[x];
                        }
                        line++;
                    }
                }
                sR.Close();
            }
            catch (FileNotFoundException e)
            {
                return null;
            }

            return tempMap;
        }
    }
}
