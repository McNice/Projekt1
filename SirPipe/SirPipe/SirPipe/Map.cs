using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Map
    {
        public int width, height;
        public Tile[,] mapArray;
        public string dir = "../../../../../../Maps/";
        public Vector2 spawnPoint, spawnPoint2;
        Random rng;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            mapArray = new Tile[width, height];
            rng = new Random();
        }

        public void LoadMap(string mapName, List<string> bricks, List<string> grass, Random rng)
        {
            mapArray = null;
            spawnPoint = new Vector2(600);
            spawnPoint2 = new Vector2(600);
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
                            mapArray = new Tile[width, height];
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
                        mapArray[x, y] = new SolidBlock(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Black Tile");
                    }
                    else if (tempMap[x, y] == "2")
                    {
                        mapArray[x, y] = new SolidBlock(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), bricks[rng.Next(bricks.Count)]);
                    }
                    else if (tempMap[x, y] == "3")
                    {
                        mapArray[x, y] = new Ladder(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Ladder");
                    }
                    else if (tempMap[x, y] == "4")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Roof-L", 3);
                    }
                    else if (tempMap[x, y] == "5")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Roof-R", 1);
                    }
                    else if (tempMap[x, y] == "6")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "TunnelRoof-R", 4);
                    }
                    else if (tempMap[x, y] == "7")
                    {
                        mapArray[x, y] = new Slope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "TunnelRoof-L", 2);
                    }
                    else if (tempMap[x, y] == "8")
                    {
                        mapArray[x, y] = new Animated(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Swinging Lamp-spritesheet", (float)rng.Next(100, 150), null);
                    }
                    else if (tempMap[x, y] == "9")
                    {
                        mapArray[x, y] = new Tile(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), grass[rng.Next(grass.Count)]);
                    }
                    else if (tempMap[x, y] == "10")
                    {
                        mapArray[x, y] = new Tile(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Tall Grass");
                    }

                    #region Interact
                    else if (Convert.ToInt32(tempMap[x, y]) >= 500 && Convert.ToInt32(tempMap[x, y]) < 550)
                    {
                        int channel = (Convert.ToInt32(tempMap[x, y]) - 500);
                        mapArray[x, y] = new ButtonLever(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Button - L", 100f, channel, ButtonLever.BUTTON);
                    }
                    else if (Convert.ToInt32(tempMap[x, y]) >= 550 && Convert.ToInt32(tempMap[x, y]) < 600)
                    {
                        int channel = (Convert.ToInt32(tempMap[x, y]) - 550);
                        mapArray[x, y] = new ButtonLever(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Button - R", 100f, channel, ButtonLever.BUTTON);
                    }
                    else if (Convert.ToInt32(tempMap[x, y]) >= 600 && Convert.ToInt32(tempMap[x, y]) < 800)
                    {
                        int temp = Convert.ToInt32(tempMap[x, y]);
                        if (temp < 700)
                            mapArray[x, y] = new Door(new Vector2(x * Game.TILESIZE - (Game.TILESIZE / 2) + 2, y * Game.TILESIZE), "Door-spritesheet", 50f, Convert.ToInt32(tempMap[x, y]) - 600, false);
                        else if (temp >= 700)
                            mapArray[x, y] = new Door(new Vector2(x * Game.TILESIZE - (Game.TILESIZE / 2) + 2, y * Game.TILESIZE), "Door-spritesheet", 50f, Convert.ToInt32(tempMap[x, y]) - 700, true);
                    }
                    else if (Convert.ToInt32(tempMap[x, y]) >= 800 && Convert.ToInt32(tempMap[x, y]) < 900)
                    {
                        int channel = (Convert.ToInt32(tempMap[x, y]) - 800);
                        mapArray[x, y] = new ButtonLever(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Levers", 20f, channel, ButtonLever.LEVER);
                    }
                    else if (Convert.ToInt32(tempMap[x, y]) >= 900 && Convert.ToInt32(tempMap[x, y]) < 1000)
                    {
                        int channel = (Convert.ToInt32(tempMap[x, y]) - 900);
                        mapArray[x, y] = new HellDoor(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Hell-door", 100f, channel);
                    }
                    #endregion

                    else if (tempMap[x, y] == "15")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Roof-R", 1);
                    }
                    else if (tempMap[x, y] == "16")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Roof-L", 3);
                    }
                    else if (tempMap[x, y] == "17")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "TunnelRoof-L", 2);
                    }
                    else if (tempMap[x, y] == "18")
                    {
                        mapArray[x, y] = new BlackSlope(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "TunnelRoof-R", 4);
                    }
                    else if (tempMap[x, y] == "19")
                    {
                        spawnPoint = new Vector2(x * Game.TILESIZE, (y * Game.TILESIZE));
                    }
                    else if (tempMap[x, y] == "21")
                    {
                        spawnPoint2 = new Vector2(x * Game.TILESIZE, (y * Game.TILESIZE));
                    }
                    else if (tempMap[x, y] == "22")
                    {
                        mapArray[x, y] = new Chimney(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "SmokeChimney2");
                    }
                    else if (tempMap[x, y] == "24")
                    {
                        mapArray[x, y] = new Lava(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "Lava", 50f);
                    }
                    else if (tempMap[x, y] == "25")
                    {
                        mapArray[x, y] = new ArrowTrap(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "ArrowTrapU", 270);
                    }
                    else if (tempMap[x, y] == "26")
                    {
                        mapArray[x, y] = new ArrowTrap(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "ArrowTrapL", 180);
                    }
                    else if (tempMap[x, y] == "27")
                    {
                        mapArray[x, y] = new ArrowTrap(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "ArrowTrapD", 90);
                    }
                    else if (tempMap[x, y] == "28")
                    {
                        mapArray[x, y] = new ArrowTrap(new Vector2(x * Game.TILESIZE, y * Game.TILESIZE), "ArrowTrapR", 0);
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (Tile dom in mapArray)
            {
                if (dom != null)
                    dom.Draw();
            }
        }
    }
}