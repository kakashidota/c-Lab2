using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //broTest();
            //test();
            //pathTest();

            Console.ReadLine();
        }
        private static void pathTest()
        {
       
            SortedPosList broList = new SortedPosList(@"/Users/Kakashi/desktop/hello");
            Position posM = new Position(123, 37);
            Position posN = new Position(14, 55);
            Position posK = new Position(3, 69);
            broList.Add(posM);
               broList.Add(posN);
            broList.Add(posK);

            Console.WriteLine("List with path: ");
            for (int i = 0; i < broList.Count(); i++)
            {
                Console.WriteLine(broList[i].ToString());
            }
            broList.Remove(posM);
            Console.WriteLine("List with path after remove: ");
            for (int i = 0; i < broList.Count(); i++)
            {
                Console.WriteLine(broList[i].ToString());
            }

            //List without path bro set
            SortedPosList cousinList = new SortedPosList();
            Position poss = new Position(100, 100);
            cousinList.Add(new Position(110, 900));
            cousinList.Add(new Position(50, 10));
            cousinList.Add(poss);
            cousinList.Remove(poss);

            Console.WriteLine("Without Path: ");
           
            for (int i = 0; i < cousinList.Count(); i++)
            {
                Console.WriteLine(cousinList[i].ToString());
            }
        }
        private static void broTest()
        {
            //Egna tester. Operatorer
            Position pos1 = new Position(47, 14);
            Position pos2 = new Position(10, 18);
            Position pos3 = new Position(80, 64);
            Position pos4 = new Position(12, 5);
            Position pos5 = new Position(52, 14);

            Position pos6 = new Position(90, 14);
            Position pos7 = new Position(10, 18);
            Position pos8 = new Position(80, 64);
            Position pos9 = new Position(122, 5);
            Position pos10 = new Position(13, 14);


            SortedPosList habibiList = new SortedPosList();
            habibiList.Add(pos1);
            habibiList.Add(pos2);
              habibiList.Add(pos3);
            habibiList.Add(pos4);
            habibiList.Add(pos5);

            SortedPosList habibtiList = new SortedPosList();
            habibtiList.Add(pos6);
            habibtiList.Add(pos7);
            habibtiList.Add(pos8);
            habibtiList.Add(pos9);
            habibtiList.Add(pos10);

            SortedPosList list3 = habibiList - habibtiList;
            SortedPosList list4 = habibtiList + habibiList;

            habibiList.Remove(new Position(80, 64));
            habibiList.Remove(new Position(10, 11));

            // skriver ut habib - habibiti
            Console.WriteLine("list - list2 : ");
            for (int i = 0; i < list3.Count(); i++)
            {
                Console.WriteLine(list3[i].ToString() + ". Length: " + list3[i].Length());
            }
            Console.WriteLine("list2 + list : ");
            for (int i = 0; i < list4.Count(); i++)
            {
                Console.WriteLine(list4[i].ToString() + ". Length list 2 : " + list4[i].Length());
            }
        }
        private static void test()
        {
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
        }
    }
}
