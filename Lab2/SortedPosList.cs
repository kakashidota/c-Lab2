using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab2
{
    public class SortedPosList
    {

        //Props
        private List<Position> posList;
        public List<Position> PosList
        {
            get
            {
                if (posList == null)
                {
                    return new List<Position>();
                }
                return posList;
            }
            set
            {
                //posList = value;
                Console.WriteLine("Cannot set value. Use the Add method");
            }
        }
        private string filePath;
        private StreamWriter stream;
        private bool isConnectedToFile = false;

        //Constructors
        public SortedPosList()
        {
            posList = new List<Position>();
        }
        public SortedPosList(string path)
        {
            posList = new List<Position>();
            filePath = path;
            loadFileToList(path);
            isConnectedToFile = true;
        }

        //File handlers
        private void loadFileToList(string filePath)
        {
            int index = 0;
            string line;
            StreamReader file;
            try
            {
                file = new StreamReader(filePath); /* Loads file */
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find file " + e);
                return;
            }
            while ((line = file.ReadLine()) != null) /* Iterates file */
            {
                //System.Console.WriteLine(line);
                Position pos = parseString(line);
                if (pos != null)
                {
                    posList.Add(pos);
                }
                index++;
            }
            file.Close(); /* Closes file when completed */
        }

        private Position parseString(string line)
        {
            string[] bits = line.Split(',');
            try
            {
                string a = bits[0].Split('(')[1]; /* String value of x */
                string b = bits[1].Split(')')[0]; /* String value of y */
                double x = Convert.ToDouble(a); /* Converted value of x */
                double y = Convert.ToDouble(b); /* Converted value of y */

                return new Position(x, y);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error parsing line: " + e);
                return null;
            }
        }

        private bool SavePosToFile(int index, Position pos)
        {
            List<string> coordList = File.ReadAllLines(filePath).ToList();
            string stringToSave = pos.ToString(); // "(" + pos.X + "," + pos.Y + ")";/U

            //Checks if habibi or not

            //Habibi = true
            using (StreamWriter stream = File.AppendText(filePath))
            {
                //Console.WriteLine("INDEX <= Count: " + coordList.Count() + " Index: " + index);
                if ((coordList.Count() == 0) || (index >= Count()))
                {
                    stream.WriteLine(stringToSave);
                    return true;
                }
            }

            //Inserts new habibi
            if (index >= 0 && index < coordList.Count())
            {
                coordList.Insert(index, stringToSave);
                File.WriteAllLines(filePath, coordList);
                return true;
            }

            return false;
        }

        private bool RemovePosFromFile(Position pos)
        {
            string searchContent = pos.ToString();
            string[] allLines = File.ReadAllLines(filePath);
            List<string> sortedList = new List<string>();
            string line;

            bool didFind = false;
            int index = 0;

            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Equals(searchContent) && didFind == false)
                {
                    didFind = true;
                }
                else
                {
                    sortedList.Add(allLines[index]);
                }
                index++;
            }
            file.Close();
            File.WriteAllLines(filePath, sortedList);

            return didFind;
        }

        //Methods
        public void Add(Position pos)
        {
            double len = pos.Length();
            for (int i = 0; i < posList.Count(); i++)
            {
                if (len < posList[i].Length())
                {
                    posList.Insert(i, pos);
                    if (isConnectedToFile) // Save to file if path is filePath is set
                    {
                        SavePosToFile(i, pos);
                    }
                    return;
                }
            }
            posList.Add(pos); /* Inserted pos len is the biggest number in the list so it's added last */
            if (isConnectedToFile)
            {
                SavePosToFile(posList.Count(), pos);
            }
        }
        public SortedPosList Clone()
        {
            SortedPosList newList = new SortedPosList();
            for (int i = 0; i < posList.Count(); i++)
            {
                newList.Add(posList[i].Clone());
            }
            return newList;
        }
        public int Count()
        {
            return PosList.Count;
        }
        private List<Position> Sort(List<Position> list)
        {
            list.Sort((x, y) => x.Length().CompareTo(y.Length()));
            return list;
        } /* Not used */
        public bool Remove(Position pos)
        {
            for (int i = 0; i < posList.Count(); i++)
            {
                if (posList[i].Equals(pos))
                {
                    if (isConnectedToFile)
                    {
                        RemovePosFromFile(posList[i]);
                    }
                    posList.Remove(posList[i]);
                    return true;
                }
            }
            return false;
        }
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList newList = new SortedPosList();
            for (int i = 0; i < posList.Count(); i++)
            {
                double d = Math.Pow(posList[i].X - centerPos.X, 2) + Math.Pow(posList[i].Y - centerPos.Y, 2);
                double sqR = Math.Pow(radius, 2);

                if (d < sqR)
                {
                    Console.WriteLine("INSIDE CIRCLE. d :" + d + "  sqR: " + sqR);
                    newList.Add(posList[i].Clone());
                }
            }
            return newList;
        }
        public override string ToString()
        {
            return string.Join(", ", posList);
        }


        // Operators
        public Position this[int i]
        {
            get
            {
                return posList[i];
            }
        }
        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                newList.Add(sp2[i].Clone());
            }
            return newList;
        }
        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            foreach (Position pos1 in sp1.posList.Reverse<Position>())
            {
                foreach (Position pos2 in sp2.posList.Reverse<Position>())
                {
                    if (pos1.Equals(pos2))
                    {
                        sp1.Remove(pos1);
                    }
                }
            }
            return sp1.Clone();
        }
    }
}
