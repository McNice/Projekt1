﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace Game
{
    public class Map
    {
        public int width, height;
        public Tile[,] mapArray;
        public string dir = "../../../../../../Maps/";

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            mapArray = new Tile[width, height];
        }

        public void LoadMap(string mapName)
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
            catch (FileNotFoundException e) { }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (tempMap[x, y] == "1")
                    {
                        mapArray[x, y] = new Block(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Inomhusgolv");
                    }
                    if (tempMap[x, y] == "2")
                    {

                    }
                    if (tempMap[x, y] == "3")
                    {

                    } 
                    if (tempMap[x, y] == "4")
                    {

                    } 
                    if (tempMap[x, y] == "5")
                    {

                    } 
                    if (tempMap[x, y] == "6")
                    {

                    }
                    if (tempMap[x, y] == "7")
                    {

                    } 
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile dom in mapArray)
            {
                if (dom != null)
                    dom.Draw(sb);
            }
        }
    }
}
