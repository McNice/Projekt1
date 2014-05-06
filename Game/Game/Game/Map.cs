using System;
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

        public void LoadMap(string mapName, List<string> bricks, Random rng)
        {
            string[,] tempMap = new string[1, 1];
            int line = 0;

            try
            {
                using (StreamReader sR = new StreamReader(dir + mapName + ".txt"))
                {

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
                }
            }
            catch (FileNotFoundException e) { }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (tempMap[x, y] == "1")
                    {
                        mapArray[x, y] = new SolidBlock(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Black Tile");
                    }
                    else if (tempMap[x, y] == "2")
                    {
                        mapArray[x, y] = new SolidBlock(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), bricks[rng.Next(bricks.Count)]);
                    }
                    else if (tempMap[x, y] == "3")
                    {
                        mapArray[x, y] = new Ladder(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Ladder");
                    }
                    else if (tempMap[x, y] == "4")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Roof-L", 3);
                    }
                    else if (tempMap[x, y] == "5")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Roof-R", 1);
                    }
                    else if (tempMap[x, y] == "6")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "TunnelRoof-R", 4);
                    }
                    else if (tempMap[x, y] == "7")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "TunnelRoof-L", 2);                      
                    }
                    else if (tempMap[x, y] == "8")
                    {
                        mapArray[x, y] = new Animated(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Swinging Lamp-spritesheet", 200f);
                    }
                    else if (tempMap[x, y] == "9")
                    {
                        mapArray[x, y] = new Tile(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Low Grass");
                    }
                    else if (tempMap[x, y] == "10")
                    {
                        mapArray[x, y] = new Tile(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Tall Grass");
                    }
                    else if (tempMap[x, y] == "11")
                    {
                        //Left Button
                    }
                    else if (tempMap[x, y] == "12")
                    {     
                        //Right Button
                    }
                    else if (tempMap[x, y] == "13")
                    {
                        //Door
                    }
                    else if (tempMap[x, y] == "14")
                    {
                        //Lever
                    }
                    else if (tempMap[x, y] == "15")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Roof-R", 2);
                    }
                    else if (tempMap[x, y] == "16")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "Roof-L", 2);
                    }
                    else if (tempMap[x, y] == "17")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "TunnelRoof-L", 2);
                    }
                    else if (tempMap[x, y] == "18")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game1.TILESIZE, y * Game1.TILESIZE), "TunnelRoof-R", 2);
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
