using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapEditor
{
    class Map
    {

        readonly string dir = "../../../../../../Maps/";
        public int width, height;

        public Map()
        {

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
